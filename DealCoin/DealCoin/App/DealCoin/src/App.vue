<template class='test'>
  <div id="app">
    <nav class="navbar navbar-fixed-top" role="navigation">
        <div class="container">
            <div v-if=" getStatut == 1" class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <router-link to="/homeAdmin"><a class="navbar-brand Element" style="color:#f7931b!important;" href="#" >DealCoin</a></router-link>
            </div>
            <!-- Brand and toggle get grouped for better mobile display -->
            <div v-if=" getStatut == 0" class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <router-link to="/"><a class="navbar-brand Element" style="color:#f7931b!important;"  href="#" >DealCoin</a></router-link>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul v-if=" getStatut == 0" class="nav navbar-nav">
                    <li v-if="!services.isConnected">
                      <router-link to="/connexion"><a href="#" class="Element">Connexion</a></router-link>
                    </li>
                    <li>
                        <router-link to="/apropos"><a href="#" class="Element">À propos</a></router-link>
                    </li> 
                    <li v-if="services.isConnected">
                        <router-link to="/articles"><a href="#" class="Element">Boutique</a></router-link>
                    </li>
                    
                    
                </ul>

                <ul v-if="services.isConnected && getStatut == 0" class="nav navbar-nav navbar-right">
                    <li v-if="services.isConnected && getStatut == 0">
                        <router-link to="/panier">Panier <span class="badge">{{ getCount }}</span></router-link>
                    </li>
                    <li v-if="services.isConnected && getStatut == 0">
                        <router-link to="/MyArticles"><a href="#" class="Element">Mes articles</a></router-link>
                    </li>
                    <li class="dropdown">
                        <a v-if="services.isConnected" class="dropdown-toggle Element" data-toggle="dropdown" role="button" 
                        aria-haspopup="true" aria-expanded="false">{{ auth.email }} <span class="caret"></span></a>
                        
                        <ul class="dropdown-menu">
                            <li v-if="services.isConnected && getStatut == 0" class="profil">
                                <router-link to="/Account">Mon compte</router-link>
                            </li> 
                            <li class="profil">
                                <router-link to="/Logout">Se déconnecter</router-link>
                            </li>
                        </ul>
                    </li>
                </ul>
                
            </div>
        </div>
    </nav>
    <router-view></router-view>
  </div>
</template>

<style lang="scss">
  @import 'src/assets/scss/design.scss';
</style>

<script>
import { mapGetters,mapActions } from 'vuex'
import AuthService from './services/AuthService.js'

export default {
    name: 'app',
    data() {
        return {
            services: AuthService,
            status: 0
        }
    },
    computed:{
    ...mapGetters(['getCount']),
    ...mapGetters(['getStatut']),
    auth: () => AuthService
    }
}
</script>

<style>
.navbar{
-moz-box-shadow: 0px 5px 5px 1px #402E22;
-webkit-box-shadow: 0px 5px 5px 1px #402E22;
-o-box-shadow: 0px 5px 5px 1px #402E22;
box-shadow: 0px 5px 5px 1px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=180, Strength=5);
background-color:#402E22;
}
body{
    background-color:#7F6A4F;
}
.router-link-active a {
    color:white;
}
a{
    color:white!important;
}
.profil a:hover{
    background-color:#402E22!important;
}
li a:hover{
    background-color:#BFA077!important;
}
.nav > li > a:hover, .nav > li > a:focus,.nav .open > a, .nav .open > a:hover, .nav .open > a:focus,.dropdown-menu{
    background-color:#BFA077!important;
}
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: white;
  margin-top: 60px;
}
</style>
