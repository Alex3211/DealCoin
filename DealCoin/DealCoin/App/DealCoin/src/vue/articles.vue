<template>
  <div class="hello">
        <div class="container">
        <img src="../assets/logo.png">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h1>DealCoin</h1>
                <div v-for="i in article" class="col-md-3">
                    <ArticlePage :id="i"></ArticlePage>
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
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'ArticlePage': article
  }
}
</script>