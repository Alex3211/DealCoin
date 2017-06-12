<template>
    <div class="articles" v-if="this.$route.fullPath == '/articles' ">
        <router-link v-bind:to="{ path: 'articleDetails', query: { article: Articleid }}">
            <p>{{Articleid.title}}</p>
        </router-link>
        <p>{{Articleid.price}}</p>
        <p>{{Articleid.posted_date}}</p>  
    <Increment></Increment>
    </div>
    <div class="articles" v-else-if="this.$route.fullPath == '/MyArticles' ">
      <p>{{Articleid.title}}</p>
      <p>{{Articleid.price}}</p>
      <p>{{Articleid.posted_date}}</p>
      <div class="btn-group" role="group" aria-label="...">
        <router-link v-bind:to="{ path: 'EditArticle', query: { article: Articleid }}">
          <button type="button" class="btn btn-default">Modifier</button>
        </router-link>
        <router-link v-bind:to="{ path: 'DelArticle', query: { article: Articleid }}">
          <button type="button" class="btn btn-default">Supprimer</button>
        </router-link>
      </div>
    </div>
</template>

<script>
import Increment from './Increment.vue'

export default {
   components: {
    Increment
  },
  props:["id"],
  data() {
    return {
           Articleid: this.id
    }

  }
}
</script>


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
