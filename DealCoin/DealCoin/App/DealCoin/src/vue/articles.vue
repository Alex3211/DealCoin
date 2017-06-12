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
              <br>
              <div class="row">
                <div v-for="i in PaginatedArticleList" :key="i.productsId" class="col-md-3">
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
      article: [],
      PaginatedArticleList: [],
      itemPerPage: 4,
      itemPage: 1
    }
  },
  async mounted(){
    await this.loadArticle();
    this.TempTab();
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
      for(var u = i; u < (this.itemPerPage*this.itemPage); u++ ){
          if(this.article[u]) paginatedArticleList.push(this.article[u]);
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
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'ArticlePage': article
  }
}
</script>