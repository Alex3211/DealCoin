<template>
    <div class="thumbnail">
      <router-link v-bind:to="{ path: 'articleDetails', query: { article: Articleid }}">
        <img width="150" v-bind:src="Articleid.photo" />
      </router-link>
      <div class="caption">
        <router-link v-bind:to="{ path: 'articleDetails', query: { article: Articleid }}"><h3>{{Articleid.title}}</h3></router-link>
        <p>{{Articleid.desc1}}</p>
        <p>{{Articleid.price}}</p>
      </div>
    </div>
</template>

<script>
import Vue from 'vue'
import $ from 'jquery'
import { mapGetters,mapActions } from 'vuex'

export default {
  props:["id"],
  data() {
    return {
           Articleid: this.id
    }
  },
  mounted() {
            
  },
  methods: {
    ...mapActions(['increment']),
    ...mapActions(['setArticle']),
    addarticle: function (article) {
      this.increment()
      this.setArticle(article)
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
