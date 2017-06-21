<template>
  <div class="container">
        <div class="container">
            <div class="btn-group drop" v-for="category in parentCategory" :key="category.categoriesId">
              <button class="btn btn-default  dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" v-on:mouseover="menuHover" v-on:mouseout="menuOut">
                {{category.title}}
                <span class="caret"></span>
              </button>
              <ul class="dropdown-menu" >
                <!--<li v-on:click="DoCategory(category.categoriesId)"><a href="#" class="categ">{{category.title}}</a></li>-->
                <li v-for="children in category.children" v-on:click="DoCategory(children.categoriesId)"><a href="#" class="categ">{{children.name}}</a></li>
              </ul>
            </div>

          <div class="row">
            <button class="btn btn-default dropdown-toggle" v-if="this.categorySearched != '' " v-on:click="DoCategory('')" type="button">
              Rechercher sur toute les catégories
            </button>
            <div class="btn-group" role="group" aria-label="..." v-if="this.BoolSearch == false">
              <button type="button" class="btn btn-default" v-on:click="ShowSearchArticle()">Rechercher un article</button>
            </div>
            <div class="btn-group" role="group" aria-label="..." v-else-if="this.BoolSearch == true">
              <button type="button" class="btn btn-default" v-on:click="ShowSearchArticle()">Arrêter la recherche</button>
            </div>
          </div>

            
            <div class="col-md-1"></div>
            <div style='display:none;' class="col-md-10" id='invisible'>
              <br>
              <div class="input-group input-group-lg">
                <span class="input-group-addon" id="sizing-addon1">Recherche d'article</span>
                <input type="text" v-model="searchString" placeholder="Rechercher un article..." class="form-control"  aria-describedby="sizing-addon1"/>
              </div>
              <br><br>
            </div>       
        </div>
        <div v-if="this.BoolSearch == true">
          <div class="row">
            <div v-for="article in filteredArticles" :key="article.productsId" class="col-md-3">
              <ArticlePage :id="article"></ArticlePage><br>
            </div>
          </div>
        </div>

        <div v-if="this.BoolSearch == false">
          <br>
          <div class="row">
            <div v-for="i in PaginatedArticleList" :key="i.productsId"  class="col-md-3 ">
              <ArticlePage :id="i"></ArticlePage><br>
            </div>
            <div v-if="PaginatedArticleList == 0"> Pas d'article pour le moment </div>
          </div>
          <nav aria-label="Page navigation">
            <ul class="pagination">
              <li v-if="this.itemPage > 1" @click="pagDoUp(false)">
                <a href="#" aria-label="Previous">
                  <span aria-hidden="true" >&laquo;</span>
                </a>
              </li>
              <li v-for="n in (Math.ceil(article.length/this.itemPerPage))" @click="pagi(n)">
                <a href="#" >{{n}}</a>
              </li>
              <li v-if=" this.itemPage < (Math.ceil(article.length/this.itemPerPage)) " @click="pagDoUp(true)">
                <a href="#" aria-label="Next">
                  <span aria-hidden="true" >&raquo;</span>
                </a>
              </li>
            </ul>
          </nav>
      </div>
  </div>
</template>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.categ:hover{
  background-color:black;
}
.thumbnail{
  width:250px;
  height:300px;
}
a {
  color: #42b983;
}
</style>

<script>
import article from './article.vue'
import articleApiService from '../services/ArticleServices.js'
import CategoryApiService from '../services/CategoryService.js'
import $ from 'jquery'

export default {
  data() {
    return {
      article: [],
      category: [],
      parentCategory:[],
      childCategory:[],
      PaginatedArticleList: [],
      itemPerPage: 8,
      itemPage: 1,
      searchString:"",
      BoolSearch : false,
      categorySearched: "",
      categoryBool :false
    }
  },
  async mounted(){
    await this.loadArticle();
    await this.TempTab();
    await this.loadCategory();
    this.afficheChildCategory();
  },
  computed: {
    // A computed property that holds only those articles that match the searchString.
    filteredArticles: function () {
      var articles_array = this.article,
          searchString = this.searchString;
      if(!searchString){
          return articles_array;
      }
      searchString = searchString.trim().toLowerCase();
      articles_array = articles_array.filter(function(item){
          if(item.title.toLowerCase().indexOf(searchString) !== -1){
              return item;
          }
      })
      // Return an array with the filtered data.
      console.log(articles_array);
      return articles_array.slice(0,8);
    },
  },
  methods: {
    menuHover: function(event) {
      if (!(event.target.parentElement.classList.contains('open'))) {
        this.categoryBool = !this.categoryBool;
        event.target.click();
      }
    },
    menuOut: function(event) {
      console.log(event);

      if (event.target.parentElement.classList.contains('open') && this.categoryBool) {
        event.target.click();
      }
    },
    loadArticle: async function(){
      var e = await articleApiService.getArticleListAsync();
      this.article = e.content;
    },
    loadCategory: async function(){
      var e = await CategoryApiService.getCategoryListAsync();
      this.category = e.content;
  },
  afficheChildCategory: function(){
    var category = this.category;
    for(var i=0; i<category.length;i++)
    {
      if(category[i].parentId==0)
      {
        var parentCategory = {};
        parentCategory.title = category[i].name;
        console.log(category[i]);
        parentCategory.id = category[i].categoriesId;
        parentCategory.children = [];
        for(var j=0;j<category.length;j++)
        {
          if(category[j].parentId==category[i].categoriesId && category[j].parentId!==0)
          {
            parentCategory.children.push(category[j]);
          }
        }
        this.parentCategory.push(parentCategory);
      }
    }
  },
    ShowSearchArticle: async function(){
      this.BoolSearch = !this.BoolSearch;
      if(document.getElementById('invisible').style.display == 'none'){
        document.getElementById('invisible').style.display = 'block';
        }
        else {
        document.getElementById('invisible').style.display = 'none';
      }      
    },
    pagi: function(page){
      this.itemPage = page;
      this.TempTab();
    },
    TempTab: function(){
        var paginatedArticleList = [];
      if(this.itemPage == 1 ) { 
        var i = this.itemPage - 1;
      } else { 
        var i = (this.itemPage-1)*this.itemPerPage;
      }
      if(this.categorySearched == "") {
        for(var u = i; u < (this.itemPerPage*this.itemPage); u++ ){
          if(this.article[u]) paginatedArticleList.push(this.article[u]);
        }
      } else {
        for(var u = i; u < (this.itemPerPage*this.itemPage); u++ ){
          if(this.article[u] && this.article[u].categoriesId == this.categorySearched) paginatedArticleList.push(this.article[u]);
        }
      }

      this.PaginatedArticleList = paginatedArticleList;
    },
    pagDoUp: function(bool){
      if(bool) {
        this.itemPage = this.itemPage + 1;
      }
      else {
        this.itemPage = this.itemPage - 1;
      }
      this.TempTab();
    },
    DoCategory: function(categ){
        this.pagi(1);
        this.categorySearched = categ;
        this.TempTab();
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'ArticlePage': article,
  }
}
</script>