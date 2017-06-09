<template>
  <div class="hello">
        <div class="container">
        <img src="../assets/logo.png">
        <div class="row">
            <h1 id="error">Article en cours de suppression</h1>
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
import AuthService from '../services/AuthService.js'
import CategoryApiService from '../services/CategoryService.js'
import articleApiService from '../services/ArticleServices.js'

export default {
  data() {
    return {
      error: '',
      model: {
            userId : null,
            categoriesId : this.$route.query.article.categoriesId,
            productsId : this.$route.query.article.productsId,
            title : this.$route.query.article.title,
            photo :this.$route.query.article.photo,
            desc1:this.$route.query.article.desc1,
            price : this.$route.query.article.price,
        },
        model1:{}
    }
  },
  async mounted(){
      this.test = await articleApiService.deleteArticleListAsync(this.$route.query.article.productsId);
      if(await articleApiService.deleteArticleListAsync(this.$route.query.article.productsId)) this.$router.replace('/MyArticles');
      else document.getElementById('error').innerHTML = 'error';
  }
}        

</script>