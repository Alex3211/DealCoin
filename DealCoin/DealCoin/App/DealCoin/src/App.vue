<template class='test'>
  <div id="app">
    <nav class="navbar navbar-fixed-top" role="navigation">
        <div class="container">
            <div  class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"><span class="caret"></span>
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <router-link v-if=" getStatut == 1" to="/homeAdmin"><a class="navbar-brand Element" style="color:#f7931b!important;" href="#" >DealCoin</a></router-link>
                <router-link v-else to="/"><a class="navbar-brand Element" style="color:#f7931b!important;"  href="#" ><img src="./assets/logo_sf.png"  class="image2"></a></router-link>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul v-if=" getStatut == 0" class="nav navbar-nav">
                      <li class="dropdown" v-if="!services.isConnected">
                        <a class="dropdown-toggle Element" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Connexion <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li>
                                <button type="button" @click="login('Google')" class="btn btn-lg btn-default buttonCategory"><i class="fa fa-google" aria-hidden="true"></i><img src="./logogoogle.png" style="width:10%;">Connexion avec Google</button>
                            </li> 
                            <li>
                                <button type="button" @click="login('Base')" class="btn btn-lg btn-default buttonCategory"><img src="./bitcoinlogo.png" style="width:10%;" >Connexion avec DealCoin</button>
                            </li>
                        </ul>
                    </li>

                    <li>
                        <router-link to="/apropos"><a href="#" class="Element">À propos</a></router-link>
                    </li> 
                    <li v-if="services.isConnected">
                        <router-link to="/articles"><a href="#" class="Element">Boutique</a></router-link>
                    </li>
                    
                </ul>

                <ul v-if="services.isConnected" class="nav navbar-nav navbar-right">
                    <li v-if="services.isConnected && getStatut == 0">
                       <router-link to="/Panier"><a href="#" class="Element"><img src="./cartlogo.png" class="image1"><p class="text1">{{getCount}}</p></img></a></router-link> 
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
    <img src="./logo_sf.png" style="margin-top:-70px;margin-bottom:-70px;">
    <router-view></router-view>
  </div>
</template>

<style lang="scss">
  @import 'src/assets/scss/design.scss';
</style>

<script>
import { mapGetters,mapActions } from 'vuex'
import AuthService from './services/AuthService.js'
import UserService from './services/UserService'
import Vue from 'vue'
import $ from 'jquery'


export default {
    name: 'app',
    data() {
        return {
            services: AuthService,
            status: 0,
            endpoint: null,
            User:[],
            email: null
        }
    },
    mounted() {
            AuthService.registerAuthenticatedCallback(() => this.onAuthenticated());
        },
        beforeDestroy() {
            AuthService.removeAuthenticatedCallback(() => this.onAuthenticated());
        },
        methods: {
            ...mapActions(['setStatut']),
            login(provider) {
                AuthService.login(provider);
            },
            onAuthenticated() {
                this.email = AuthService.hisEmail();
                this.loadModelUser(this.email);
            },
            loadModelUser: async function(email) {
              this.User = await UserService.getUserAsync(this.email);
              this.User = this.User.content;
                if(this.User.status == 1)
                {
                    this.setStatut(1);
                    this.$router.replace('/homeAdmin');
                }
                else
                {
                    this.setStatut(0);
                    this.$router.go('/home'); 
                }
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
.navbar-toggle {
    background-color: #7F6A4F;
    border: 1px solid #7F6A4F;
}
.image1 {
	width: 36px;
    height:26px;
}
.image2 {
	width: 128px;
    height:64px;
    margin-top:-24px;
}
.text1{
   margin-left:-8px;
   margin-top:-35px;
}



.btn-lg
{
  padding:8px 22px;
}
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
    color:white !important;
    text-decoration: none !important;
}
.profil a:hover{
    background-color:#402E22!important;
}
.btn{
  color:white !important;
  text-decoration: none !important;
  background-color:#7F6A4F;
  border:1px solid #402E22;
  border-radius:0px;
}
.buttonCategory:focus, .btn:hover{
background-color: #402E22!important;
color:white!important;
-moz-box-shadow: 5px 5px 5px -5px #402E22;
-webkit-box-shadow: 5px 5px 5px -5px #402E22;
-o-box-shadow: 5px 5px 5px -5px #402E22;
box-shadow: 5px 5px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
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
