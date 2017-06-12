<template>
<div class="row">
  <div class="col-md-4"></div>
  <div class="col-md-4">
      <div class="articles">
        <router-link to="/articles">
            <p>{{Articleid.productsId}}</p>
            <p>{{Articleid.title}}</p>
            <p>{{Articleid.photo}}</p>
            <p>Catégorie : {{Articleid.categoriesId}}</p>
            <p>Crée le {{Articleid.created}}</p>
            <p>{{Articleid.price}}</p>
            <p>Mis a jour le {{Articleid.updated}}</p>
        </router-link>
        <iframe
          width="600"
          height="450"
          frameborder="0" style="border:0"
          src="https://www.google.com/maps/embed/v1/place?key=AIzaSyB_yRoeiBszCEHDf88Rnv0c9tX_eilmL7o&q=Space+Needle,Seattle+WA" allowfullscreen>
        </iframe>
      </div>
  <div class="col-md-4"></div>
  </div>
</div>
</template>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.articles{
    width: 250px;
    height: 250px;
  border: 1px solid black;
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
import Connexion from './connexion.vue'
import AuthService from '../services/AuthService.js'
import UserService from '../services/UserService.js'

export default {
  data() {
    return {
      Articleid: 'null',
      user: {}
    }
  },
  async mounted(){
    var q = this.$route.query.article
    this.Articleid = q
    this.loadModelUser();
  }, 
  methods: {
    loadModelUser: async function() {
  var Model2= await UserService.getUserByIdAsync(this.Articleid.userId);
  this.user=Model2.content;
  //this.model.userId = this.model.content.userId;
  },
  components: {
    // <my-component> will only be available in parent's template
    'connexion': Connexion
  }
}
};
</script>