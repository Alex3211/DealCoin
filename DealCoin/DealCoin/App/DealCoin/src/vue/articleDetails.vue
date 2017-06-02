<template>
<div class="row">
  <div class="col-md-4"></div>
  <div class="col-md-4">
      <div class="articles">
        <router-link to="/articles">
            <p>{{Articleid.title}}</p>
            <p>{{Articleid.photo}}</p>
            <p>Catégorie : {{Articleid.categoriesId}}</p>
            <p>Crée le {{Articleid.created}}</p>
            <p>{{Articleid.price}}</p>
            <p>Mis a jour le {{Articleid.updated}}</p>
        </router-link>
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

export default {
  data() {
    return {
      Articleid: 'null'
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'connexion': Connexion
  },       
  mounted: function() {
  var q = this.$route.query.article
  this.Articleid = q
  }
}
</script>