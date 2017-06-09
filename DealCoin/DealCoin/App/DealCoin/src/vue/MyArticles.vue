<template>
  <div class="hello">
        <div class="container">
        <img src="../assets/logo.png">
        <div class="row">
            <div class="col-lg-12 text-center">
            <router-link to="/InsertArticle"><button>Add</button></router-link>
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
import UserService from '../services/UserService.js'
import article from './C_article.vue'
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
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'ArticlePage': article
  }
}
</script>