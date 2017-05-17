<template>
  <div class="hello">
        <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h1>DealCoin</h1>

                <div v-for="i in list" class="row">
                  <div v-for="i in list" class="col-md-3">
                    <ArticlePage></ArticlePage>
                  </div>
                  <br>
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

export default {
  data() {
    return {
      list: [1, 2, 3, 4]
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'ArticlePage': article
  }
}
</script>