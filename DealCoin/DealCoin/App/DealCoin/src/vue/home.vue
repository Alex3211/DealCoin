<template>
      <div class="container">
        <img src="../assets/logo_sf.png">
        <img src="../bitcoinlogo.png" style="width:10%;" >
        <div class="row">
            <div class="col-lg-12 text-center">
                <p class="lead">Avec l’ascension du e-commerce ainsi que les problèmes de paiements, nous avons décidé de créer DealCoin. C’est un site de e-commerce sécurisé et anonyme grâce à notre méthode de paiement en bitcoins. Cela permet à un utilisateur d’acheter ou vendre un article et de pouvoir se faire livrer à domicile. L’avantage de notre méthode de paiement est de remplacer la carte de crédit qui est traçable et piratable.</p>
            </div>
            <!--<connexion></connexion>-->
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
import App from '../App.vue'
import { mapGetters } from 'vuex'

export default {
  data() {
    return {
      list: [1, 2, 3, 4]
    }
  },
  computed: {
    // mix the getters into computed with object spread operator
    ...mapGetters([
      'isLoading',
    ])
  },
  components: {
    // <my-component> will only be available in parent's template
    'app': App
  }
}
</script>