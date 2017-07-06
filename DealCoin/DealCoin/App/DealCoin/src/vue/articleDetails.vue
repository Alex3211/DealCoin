<template>

<div class="container " style="border:none;">
        <div class="panel-body">
              <router-link to="/articles"><button href="#" class="btn btn-default" style='margin-left:80px;'>Retour aux articles</button></router-link>
            
            <div class="btn-group" style="float:right;" v-if="this.email == user.email">
            	<button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            		<span>Modifier</span>
            		<span class="sr-only">Toggle Dropdown</span>
            	</button>
            	<ul class="dropdown-menu">
            		<li><router-link v-bind:to="{ path: 'EditArticle', query: { article: Articleid }}"><a href="#"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>Modifier</a></router-link></li>
            		<li role="separator" class="divider"></li>
            		<li><router-link v-bind:to="{ path: 'DelArticle', query: { article: Articleid, account: false }}"><a href="#"><span class="glyphicon glyphicon-remove-circle" aria-hidden="true"></span>Supprimer</a></router-link></li>
            	</ul>
            </div>
            <div class="clearfix"></div>
<br>
        <div class="row"> 
              <div class="col-md-4"></div>
              <div class="col-md-4">
                      
              <div class="row"><h4 class="media-heading col-md-12">{{Articleid.title}}</h4></div>
                <div class="row">
                    <img class="media-object col-md-12 imag" v-bind:src="Articleid.photo" />
                </div>
                <div class="row">
                    <div class="col-md-12">
                    <br>
                          <p>{{Articleid.desc1}}</p>
                          <p>{{Articleid.price}}</p>
                          <p>{{Articleid.visits}}</p>
                          <p>Crée le {{Articleid.created.substring(0,10)}}</p>
                          <p>Mis a jour le {{Articleid.updated.substring(0,10)}}</p>
                          <div>
                            <button v-if="this.email !== user.email" class="btn btn-default" v-on:click="addarticle(Articleid)">Ajouter au panier</button>
                          </div>
                                      
                      <div class="clearfix"></div>
                    </div>
                </div>
                <div class="row">
                <br>
                    <iframe v-if="this.bool == true" class="col-md-12"
                      width="300" height="150"
                      frameborder="0" style="border:0"
                      :src="url" allowfullscreen>
                    </iframe>
                </div>
              </div>
              <div class="col-md-4"></div>
        </div>
    </div>
</div>
</template>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.btn-default:active, .btn-default.active, .open > .btn-default.dropdown-toggle {
  background-color: #BFA077;
  border:none;
}
.btn{
    color:white !important;
    text-decoration: none !important;
    
}
.btn:hover{
background-color: #402E22!important;
color:white!important;
-moz-box-shadow: 5px 5px 5px -5px #402E22;
-webkit-box-shadow: 5px 5px 5px -5px #402E22;
-o-box-shadow: 5px 5px 5px -5px #402E22;
box-shadow: 5px 5px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
}
.panel-body{
  background-color: #BFA077;
  border:none;
  -moz-border-radius: 0px;
  -webkit-border-radius: 0px;
  border-radius: 0px;
  -moz-box-shadow: 10px 10px 5px -5px #402E22;
-webkit-box-shadow: 10px 10px 5px -5px #402E22;
-o-box-shadow: 10px 10px 5px -5px #402E22;
box-shadow: 10px 10px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
}
.imag{
  margin-left:30px;
  padding: 0;
  width:300px;
  max-height: 400px;
    -moz-box-shadow: 10px 10px 5px -5px #402E22;
-webkit-box-shadow: 10px 10px 5px -5px #402E22;
-o-box-shadow: 10px 10px 5px -5px #402E22;
box-shadow: 10px 10px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
}
.toto{
  background-color:#BFA077;
  border:none;
  
}
.panel{
  border:none;
}
button:hover{
background-color:#BFA077!important;
}
.btn{
 background-color:#BFA077;
 border: 1px solid #402E22;
 border-radius:10px;
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
import AuthService from '../services/AuthService.js'
import UserService from '../services/UserService.js'
import { mapGetters,mapActions } from 'vuex'
import CategoryApiService from '../services/CategoryService.js'

export default {
  data() {
    return {
      category: [],
      Articleid: 'null',
      user: {},
      email:'',
      url:'https://www.google.com/maps/embed/v1/place?key=AIzaSyB_yRoeiBszCEHDf88Rnv0c9tX_eilmL7o&q=',
      bool: false
    }
  },
  components: {
    // <my-component> will only be available in parent's template
    'app': App,
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
    await this.loadCategory();
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
  },
  loadCategory: async function(){
    var e = await CategoryApiService.getCategoryListAsync();
    this.category = e.content;

  //this.model.userId = this.model.content.userId;
  },
  addarticle: function (article) {
      this.increment()
      this.setArticle(article)
  }
}
};
</script>