<template>
      <div class="container">
        <img src="../assets/logo_sf.png" style="margin-top:-70px;margin-bottom:-70px;">
        <div class="row">
        <div class="container">
            <div class="col-md-12 text-center">
                             
            <p class="lead">Avec l’ascension du e-commerce ainsi que les problèmes de paiements, nous avons décidé de créer DealCoin. C’est un site de e-commerce sécurisé et anonyme grâce à notre méthode de paiement en bitcoins. Cela permet à un utilisateur d’acheter ou vendre un article et de pouvoir se faire livrer à domicile. L’avantage de notre méthode de paiement est de remplacer la carte de crédit qui est traçable et piratable.</p>
          
            </div>
            <div v-if="services.isConnected && model !== null && model.city == ''">
              <router-link to="/Account"><button  type="button" class="btn btn-default buttonCategory">Finaliser les informations de mon compte</button></router-link> 
            </div>
        </div>
    </div>
  </div>
</template>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

.buttonCategory:focus, .btn:hover{
background-color: #402E22!important;
color:white!important;
-moz-box-shadow: 5px 5px 5px -5px #402E22;
-webkit-box-shadow: 5px 5px 5px -5px #402E22;
-o-box-shadow: 5px 5px 5px -5px #402E22;
box-shadow: 5px 5px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
}
.btn-default:active, .btn-default.active, {
background-color: #BFA077;
border:none;
 margin-left:5px;
 margin-right:5px;
 -moz-box-shadow: 5px 5px 5px -5px #402E22;
-webkit-box-shadow: 5px 5px 5px -5px #402E22;
-o-box-shadow: 5px 5px 5px -5px #402E22;
box-shadow: 5px 5px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
}
.btn{
 background-color:#BFA077;
 border-radius:5px;
}
h1, h2 {
  font-weight: normal;
}
.imageT{
  padding-left:425px;
}
.colorI{
  color:black!important;
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
import App from '../App.vue'
import { mapGetters } from 'vuex'
import AuthService from '../services/AuthService.js'
import UserService from '../services/UserService.js'
import article from './article.vue'
import articleApiService from '../services/ArticleServices.js'
import CategoryApiService from '../services/CategoryService.js'
import $ from 'jquery'

export default {
  data() {
    return {
      model: {},
      services: AuthService,
      article: [],
      category: [],
      parentCategory:[],
      childCategory:[],
      PaginatedArticleList: [],
      itemPerPage: 5,
      itemPage: 1,
    }
  },
    async mounted() {
       if(AuthService.isConnected){
        this.email = AuthService.hisEmail();
        this.loadModelUser(this.email);
        await this.loadArticle();
        await this.TempTab();
      }
        },
         methods: {
            loadModelUser: async function(email) {
              
              var Model= await UserService.getUserAsync(email);
              this.model=Model.content;
            },
            loadArticle: async function(){
              var e = await articleApiService.getArticleListAsync();
              this.article = e.content;
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
            }
          },
  computed: {
    // mix the getters into computed with object spread operator
    ...mapGetters([
      'isLoading',
    ]),
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
      return articles_array.slice(0,5);
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'app': App,
    'ArticlePage': article
  }
}
</script>