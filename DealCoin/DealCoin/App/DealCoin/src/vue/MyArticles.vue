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
            <div class="row">
              <br><div v-for="i in article" class="col-md-3">
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
      article: [],
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
    this.loadArticle();
  },
  methods: {
    loadArticle: async function(){
      var e = await articleApiService.GetArticleListByIdAsync(this.model1.content.userId);
      this.article = e.content;
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
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'ArticlePage': article
  }
}
</script>