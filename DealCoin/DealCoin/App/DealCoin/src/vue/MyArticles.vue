<template>
  <div class="hello">
        <div class="container">
        <img src="../assets/logo.png">
        <div class="row">
            <div class="col-lg-12 text-center">
            <div class="row">
              <h1>Vos articles</h1>
            </div>
            <div class="row">
              <br><div class="btn-group" role="group" aria-label="...">
                <router-link to="/InsertArticle"><button type="button" class="btn btn-default">Ajouter un article</button></router-link>
                <button type="button" class="btn btn-default" v-on:click="ShowSearchArticle()">Rechercher un article</button>
              </div><br>
              <div class="col-md-1"></div>
              <div style='display:none;' class="col-md-10" id='invisible'>
                <br><div class="input-group input-group-lg">
                  <span class="input-group-addon" id="sizing-addon1">Recherche d'article</span>
                  <input type="text" class="form-control" placeholder="Titre de l'article" aria-describedby="sizing-addon1">
                </div><br>
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
            <div class="row">
              <br><div v-for="i in PaginatedArticlesList" :key="i.productsId" class="col-md-3">
                  <ArticlePage :id="i"></ArticlePage><br>
              </div>
            </div>
            
            </div>
        </div>
    </div>
  </div>
</template>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
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
      itemPerPage: 4,
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
        email : null
    }
  },
  async mounted(){
    this.email = AuthService.hisEmail();
    await this.LoadModelUser(this.email);
    await this.loadArticle();
    this.TempTab();
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