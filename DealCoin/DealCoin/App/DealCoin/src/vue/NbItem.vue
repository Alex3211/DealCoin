<template>
  <div>
    <h3>Vos articles ( {{ getCount }} )</h3>
  </div>
</template>

<script>
import {mapGetters} from 'vuex'

export default {
  name: 'nbitem',
  computed:{
    ...mapGetters(
      [
        'getCount'
    ])
  }
}
</script>

<style lang="css" scoped>
</style>
