<template>
    <div class="articles"><router-link v-bind:to="{ path: 'articleDetails', query: { article: Articleid }}">
        <p>{{Articleid.title}}</p>
    </router-link>
        <p>{{Articleid.price}}</p>
        <p>{{Articleid.posted_date}}</p>  
    <Increment></Increment>


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
