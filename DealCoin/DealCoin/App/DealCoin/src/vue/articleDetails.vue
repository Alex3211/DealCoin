<template>

<div class="container">
    <div class="panel panel-default">
        <div class="panel-heading">
            <router-link to="/articles"><a href="#" class="MakaleYazariAdi">Retour aux articles</a></router-link>
            <div class="btn-group" style="float:right;" v-if="this.email == user.email">
            	<button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            		<span class="glyphicon glyphicon-cog"></span>
            		<span class="sr-only">Toggle Dropdown</span>
            	</button>
            	<ul class="dropdown-menu">
            		<li><router-link v-bind:to="{ path: 'EditArticle', query: { article: Articleid }}"><a href="#"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span> Edit</a></router-link></li>
            		<li role="separator" class="divider"></li>
            		<li><router-link v-bind:to="{ path: 'DelArticle', query: { article: Articleid }}"><a href="#"><span class="glyphicon glyphicon-remove-circle" aria-hidden="true"></span> Delete</a></router-link></li>
            	</ul>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="panel-body">
            <div class="media">
                <div class="media-left">
                    <img class="media-object" width="300" v-bind:src="Articleid.photo" />
                    <iframe v-if="this.bool == true"
                      width="300" height="150"
                      frameborder="0" style="border:0"
                      :src="url" allowfullscreen>
                    </iframe>
                </div>
                <div class="media-body">
                <h4 class="media-heading">{{Articleid.title}}</h4>
                    <p>{{Articleid.desc1}}</p>
                    <p>{{Articleid.price}}</p>
                    <p>{{Articleid.visits}}</p>
                    <p>Crée le {{Articleid.created}}</p>
                    <p>Mis a jour le {{Articleid.updated}}</p>
                    <div>
                      <button v-on:click="addarticle(Articleid)">Ajouter au panier</button>
                    </div>
                                
                <div class="clearfix"></div>
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
import Connexion from './connexion.vue'
import AuthService from '../services/AuthService.js'
import UserService from '../services/UserService.js'
import Increment from './Increment.vue'
import { mapGetters,mapActions } from 'vuex'

export default {
  data() {
    return {
      Articleid: 'null',
      user: {},
      email:'',
      url:'https://www.google.com/maps/embed/v1/place?key=AIzaSyB_yRoeiBszCEHDf88Rnv0c9tX_eilmL7o&q=',
      bool: false
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'connexion': Connexion,
    Increment
  },
  
  computed:{
    ...mapGetters(['getCount']),
    auth: () => AuthService
  },
  async mounted(){
    this.email = AuthService.hisEmail();
    var q = this.$route.query.article
    this.Articleid = q
    this.loadModelUser();
  }, 
  methods: {
    ...mapActions(['increment']),
    ...mapActions(['setArticle']),
    loadModelUser: async function() {
    var Model2= await UserService.getUserByIdAsync(this.Articleid.userId);
    this.user=Model2.content;
    this.url += this.user.city;
    this.bool = true;
    this.Articleid.visits++;
  //this.model.userId = this.model.content.userId;
  },
  addarticle: function (article) {
      this.increment()
      this.setArticle(article)
  },
}
};
</script>