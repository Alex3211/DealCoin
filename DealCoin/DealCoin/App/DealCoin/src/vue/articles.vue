<template>

  <div class="container"><br>
        <div class="container">
          <div class="row">
            <div class="btn-group drop" v-for="category in parentCategory" :key="category.categoriesId">
              <button class="btn btn-default  dropdown-toggle buttonCategory" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" v-on:mouseover="menuHover" v-on:mouseout="menuOut">
                {{category.title}}
                <span class="caret"></span>
              </button>
              <ul class="dropdown-menu" >
                <!--<li v-on:click="DoCategory(category.categoriesId)"><a href="#" class="categ">{{category.title}}</a></li>-->
                <li v-for="children in category.children" v-on:click="DoCategory(children.categoriesId, children.name)"><a href="#" class="categ">{{children.name}}</a></li>
              </ul>
            </div>
          </div>
          <br>
          <div class="row">

            <button class="btn btn-default dropdown-toggle" v-if="this.categorySearched != '' " v-on:click="DoCategory('')" type="button">
              Rechercher sur toute les catégories
            </button>
            <div class="btn-group" role="group" aria-label="..." v-if="this.BoolSearch == false">
              <button type="button" class="btn btn-default buttonCategory" v-on:click="ShowSearchArticle()">Rechercher un article</button>
            </div>
            <div class="btn-group" role="group" aria-label="..." v-else-if="this.BoolSearch == true">
              <button type="button" class="btn btn-default buttonCategory" v-on:click="ShowSearchArticle()">Arrêter la recherche</button>
            </div>
            <div class="btn-group">
              <button id="tri" class="btn btn-default dropdown-toggle buttonCategory" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                Trier <span class="caret"></span>
              </button>
              <ul class="dropdown-menu">
                <li><a href="#" v-on:click="tri('Prix croissant')">Prix croissant</a></li>
                <li><a href="#" v-on:click="tri('Prix décroissant')">Prix décroissant</a></li>
                <li><a href="#" v-on:click="tri('De A-Z')">De A a Z</a></li>
                <li><a href="#" v-on:click="tri('De Z-A')">De Z a A</a></li>
              </ul>
            </div>
            <br><br>
            <h4 v-if="categorySearched !== ''">
              Vous êtes dans la catégorie <b>{{NameOfCategory}}</b>.
            </h4>
          </div>
                      
            
            <div class="col-md-1"></div>
            <div style='display:none;' class="col-md-10" id='invisible'>
              <br>
              <div class="input-group input-group-lg">
                <span class="input-group-addon LeftColorForSearch" id="sizing-addon1">Recherche d'article</span>
                <input type="text" v-model="searchString" placeholder="Rechercher un article..." class="form-control RightColorForSearch"  aria-describedby="sizing-addon1"/>
              </div>
              <br><br>
            </div>       
        </div>
        <div v-if="this.BoolSearch == true && searchString !== ''">
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
            <div v-if="PaginatedArticleList == 0"> Aucun article pour le moment </div>
          </div>
          <nav aria-label="Page navigation" v-if="!this.SearchWithCategoryBool">
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

          <nav aria-label="Page navigation" v-else-if="this.SearchWithCategoryBool">
            <ul class="pagination">
              <li v-if="this.itemPage > 1" @click="pagDoUp(false)">
                <a href="#" aria-label="Previous">
                  <span aria-hidden="true" >&laquo;</span>
                </a>
              </li>
              <li v-for="n in (Math.ceil(PaginatedArticleList.length/this.itemPerPage))" @click="pagi(n)">
                <a href="#" >{{n}}</a>
              </li>
              <li v-if=" this.itemPage < (Math.ceil(PaginatedArticleList.length/this.itemPerPage)) " @click="pagDoUp(true)">
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
::-webkit-input-placeholder {
   color: white;
}

:-moz-placeholder { /* Firefox 18- */
   color: white;  
}

::-moz-placeholder {  /* Firefox 19+ */
   color: white;  
}

:-ms-input-placeholder {  
   color: white;  
}
.btn-default:active, .btn-default.active, .open > .btn-default.dropdown-toggle {
  background-color: #BFA077;
  border:none;
}
.btn{
    color:white !important;
    text-decoration: none !important;
}
.RightColorForSearch:focus, .RightColorForSearch:hover, .buttonCategory:focus, .btn:hover{
background-color: #402E22!important;
color:white!important;
-moz-box-shadow: 5px 5px 5px -5px #402E22;
-webkit-box-shadow: 5px 5px 5px -5px #402E22;
-o-box-shadow: 5px 5px 5px -5px #402E22;
box-shadow: 5px 5px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
}
.RightColorForSearch, .LeftColorForSearch{
background-color: #BFA077!important;
border:none;
color:white;
}
button:hover{
  background-color:#BFA077!important;
}
.btn{
  background-color:#BFA077;
  border:none;
}
.categ:hover{
  background-color:black;
}
li a:hover,.pagination > li > a:hover,.pagination > li > a:hover, .pagination > li > a:focus, .pagination > li > span:hover, .pagination > li > span:focus{
  background-color:#402E22!important;
}
.thumbnail{
  background-color: #BFA077;
  border:none;
  width:250px;
  height:350px;
  -moz-border-radius: 7px;
  -webkit-border-radius: 7px;
  border-radius: 7px;
  -moz-box-shadow: 10px 10px 5px -5px #402E22;
  -webkit-box-shadow: 10px 10px 5px -5px #402E22;
  -o-box-shadow: 10px 10px 5px -5px #402E22;
  box-shadow: 10px 10px 5px -5px #402E22;
  filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=315, Strength=5);
}
li a {
  color: white;
  background-color:#BFA077;
  border:none;
  -moz-box-shadow: 5px 5px 5px -5px #402E22;
-webkit-box-shadow: 5px 5px 5px -5px #402E22;
-o-box-shadow: 5px 5px 5px -5px #402E22;
box-shadow: 5px 5px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
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
      NameOfCategory:'',
      BoolSearch : false,
      categorySearched: "",
      categoryBool :false,
      SearchWithCategoryBool : false
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
    tri: function(sorteDeTri){
      switch (sorteDeTri) {
        case "Prix croissant":
            var ascending = this.article.sort((a, b) => parseInt(a.price) - parseInt(b.price));
            break;
        case "Prix décroissant":
            var ascending = this.article.sort((a, b) => parseInt(b.price) - parseInt(a.price));
            break;
        case "De A-Z":
            var ascending = this.article.sort(function(a, b){
              if(a.title < b.title) return -1;
              if(a.title > b.title) return 1;
              return 0;
            })
            break;
        case "De Z-A":
            var ascending = this.article.sort(function(a, b){
              if(a.title > b.title) return -1;
              if(a.title < b.title) return 1;
              return 0;
            })
            break;
      }
      if(ascending){
        this.article = ascending;
        document.getElementById("tri").innerHTML = sorteDeTri;
      }
      this.TempTab();
    },
    menuOut: function(event) {
      //console.log(event);

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
        this.SearchWithCategoryBool = false;
        for(var u = i; u < (this.itemPerPage*this.itemPage); u++ ){
          if(this.article[u]) paginatedArticleList.push(this.article[u]);
        }
      } else {
        this.SearchWithCategoryBool = true;
        for(var u = 0; u < this.article.length; u++ ){
          if(this.article[u] && (this.article[u].categoriesId == this.categorySearched)){
              paginatedArticleList.push(this.article[u]);
          } 
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
    DoCategory: function(categ, name){
        this.pagi(1);
        this.NameOfCategory = name;
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