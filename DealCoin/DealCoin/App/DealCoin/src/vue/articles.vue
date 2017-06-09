<template>
  <div class="hello">
        <div class="container">
        <img src="../assets/logo.png">
        <div class="row">
            <div class="col-lg-12 text-center">
              <div class="row">
                  <h1>DealCoin</h1>
                  <div class="btn-group" role="group" aria-label="...">
                    <button type="button" class="btn btn-default" v-on:click="ShowSearchArticle()">Rechercher un article</button>
                  </div>
                  <br>
                  <div class="col-md-1"></div>
                  <div style='display:none;' class="col-md-10" id='invisible'>
                    <br><div class="input-group input-group-lg">
                      <span class="input-group-addon" id="sizing-addon1">Recherche d'article</span>
                      <input type="text" class="form-control" placeholder="Titre de l'article" aria-describedby="sizing-addon1">
                    </div>
                  </div>       
              </div>
              <br>
              <div class="row">
                <div v-for="i in article" class="col-md-3">
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
import article from './article.vue'
import articleApiService from '../services/ArticleServices.js'

export default {
  data() {
    return {
      article: [] 
    }
  },
  async mounted(){
    await this.loadArticle();
  },
  methods: {
    loadArticle: async function(){
      var e = await articleApiService.getArticleListAsync();
      this.article = e.content;
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