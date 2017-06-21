<template>
  <div class="container">
      <div class="container">
        <div class="row">
            <router-link to="/InsertArticle"><button type="button" class="btn btn-default">Ajouter un article</button></router-link> 
            <div class="btn-group" role="group" aria-label="..." v-if="this.BoolSearch == false">
              <button type="button" class="btn btn-default" v-on:click="ShowSearchArticle()">Rechercher un article</button>
            </div>
            <div class="btn-group" role="group" aria-label="..." v-else-if="this.BoolSearch == true">
              <button type="button" class="btn btn-default" v-on:click="ShowSearchArticle()">Arrêter la recherche</button>
            </div>
            <br>
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
          <br>
          <div v-for="i in PaginatedArticlesList" :key="i.productsId" class="col-md-3">
              <ArticlePage :id="i"></ArticlePage><br>
          </div>
        </div>
        <nav aria-label="Page navigation">
          <ul class="pagination">
            <li v-if="this.itemPage > 1" @click="pagDoUp(false)">
              <a href="#" aria-label="Previous">
                <span aria-hidden="true" >&laquo;</span>
              </a>
            </li>
            <li v-for="n in (Math.ceil(articleL.length/this.itemPerPage))" @click="pagi(n)">
              <a href="#" >{{n}}</a>
            </li>
            <li v-if=" this.itemPage < (Math.ceil(articleL.length/this.itemPerPage)) " @click="pagDoUp(true)">
              <a href="#" aria-label="Next">
                <span aria-hidden="true" >&raquo;</span>
              </a>
            </li>
          </ul>
        </nav>
      </div>
    </div>
  </div>
</template>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.thumbnail{
  width:250px;
  height:300px;
}
h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>

<script>
import UserService from '../services/UserService.js'
import article from './article.vue'
import articleApiService from '../services/ArticleServices.js'
import AuthService from '../services/AuthService.js'

export default {
  data() {
    return {
      articleL: [],
      PaginatedArticlesList: [],
      itemPerPage: 8,
      itemPage: 1,
      model: {
            userId : null,
            productsId: null,
            title : null,
            photo :null,
            desc1:null,
            price : null,
        },
        model1:{},
        email : null,
        BoolSearch: false,
        searchString:""
    }
  },
  async mounted(){
    this.email = AuthService.hisEmail();
    await this.LoadModelUser(this.email);
    await this.loadArticle();
    this.TempTab();
  },
  computed: {
    // A computed property that holds only those articles that match the searchString.
        filteredArticles: function () {
            var articles_array = this.articleL,
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
            return articles_array;
        }
  },
  methods: {
    loadArticle: async function(){
      var e = await articleApiService.GetArticleListByIdAsync(this.model1.content.userId);
      this.articleL = e.content;
    },
    TempTab: function(){
      this.PaginatedArticlesList = [];
      if(this.itemPage == 1 ) { 
        var i = this.itemPage - 1;
      } else { 
        var i = (this.itemPage-1)*this.itemPerPage;
      }
      for(var u = i; u < (this.itemPerPage*this.itemPage); u++ ){
          if(this.articleL[u])this.PaginatedArticlesList.push(this.articleL[u]);
      }
    },
    pagi: function(page){
      this.itemPage = page;
      this.TempTab();
    },
    LoadModelUser: async function(email){
        this.model1 = await UserService.getUserAsync(email);
        this.model.userId = this.model1.content.userId;
        this.model.productsId = this.model1.content.productsId;
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
    pagDoUp: function(bool){
      if(bool) {
        this.itemPage = this.itemPage + 1;
        this.TempTab();
      }
      else {
        this.itemPage = this.itemPage - 1;
        this.TempTab();
      }
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'ArticlePage': article
  }
}
</script>