<template>
  <div>
    <button v-on:click="increment">Ajouter au panier</button>
  </div>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  name: 'increment',
  data() {
            return {
            
            }
        },
        mounted() {
            
        },
  methods:{
    ...mapActions(['increment'])

  }
}
</script>

<style lang="css" scoped>
</style>
