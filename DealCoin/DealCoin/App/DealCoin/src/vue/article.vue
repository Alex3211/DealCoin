<template>
    <div class="articles"><router-link to="/articleDetails">
        <p>toto</p>
        <p>titi</p>
        <p>tutu</p>
    </router-link></div>
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
      list: [1, 2, 3, 4]
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'connexion': Connexion
  }
}
</script>