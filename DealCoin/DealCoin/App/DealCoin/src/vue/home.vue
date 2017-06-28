<template>
      <div class="container">
        <img src="../assets/logo_sf.png">
        <img src="../bitcoinlogo.png" style="width:10%;" >
        <div class="row">
            <div class="col-lg-12 text-center">
                <p class="lead">Avec l’ascension du e-commerce ainsi que les problèmes de paiements, nous avons décidé de créer DealCoin. C’est un site de e-commerce sécurisé et anonyme grâce à notre méthode de paiement en bitcoins. Cela permet à un utilisateur d’acheter ou vendre un article et de pouvoir se faire livrer à domicile. L’avantage de notre méthode de paiement est de remplacer la carte de crédit qui est traçable et piratable.</p>
            </div>

            <div v-if="services.isConnected && model.city==''">
              <router-link to="/Account"><button  type="button" class="btn btn-default buttonCategory">Finaliser les informations de mon compte</button></router-link> 
            
            </div>
        </div>
    </div>
  </div>
</template>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

.buttonCategory:focus, .btn:hover{
background-color: #402E22!important;
color:white!important;
-moz-box-shadow: 5px 5px 5px -5px #402E22;
-webkit-box-shadow: 5px 5px 5px -5px #402E22;
-o-box-shadow: 5px 5px 5px -5px #402E22;
box-shadow: 5px 5px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
}
.btn-default:active, .btn-default.active, {
background-color: #BFA077;
border:none;
 margin-left:5px;
 margin-right:5px;
 -moz-box-shadow: 5px 5px 5px -5px #402E22;
-webkit-box-shadow: 5px 5px 5px -5px #402E22;
-o-box-shadow: 5px 5px 5px -5px #402E22;
box-shadow: 5px 5px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
}
.btn{
 background-color:#BFA077;
 border-radius:5px;
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
import App from '../App.vue'
import { mapGetters } from 'vuex'
import AuthService from '../services/AuthService.js'
import UserService from '../services/UserService.js'

export default {
  data() {
    return {
      model: {},
      services: AuthService
    }
  },
    async mounted() {
            this.email = AuthService.hisEmail();
            this.loadModelUser(this.email);
        },
         methods: {
            loadModelUser: async function(email) {
              
              var Model= await UserService.getUserAsync(email);
              this.model=Model.content;
              //this.model.userId = this.model.content.userId;
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