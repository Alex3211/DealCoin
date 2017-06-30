<template>
    <div v-if="this.$route.path !== '/MyArticles'" class="thumbnail" >
      <router-link v-bind:to="{ path: 'articleDetails', query: { article: Articleid }}"
       v-on:click.native="onVisited(Articleid)">
        <img v-if="Articleid.photo!==''" class="taille" v-bind:src="Articleid.photo" />
      </router-link>
      <div class="caption">
        <router-link v-bind:to="{ path: 'articleDetails', query: { article: Articleid }}"
        v-on:click.native="onVisited(Articleid)"><h3>{{Articleid.title}}</h3></router-link>
        <div>
							<span itemprop="price" class="price product-price">
							{{Articleid.price}}	€
              </span>
				</div>
        <p> Article vu <b>{{Articleid.visits}}</b> fois.</p> 
        <button class="btn btn-default" v-on:click="addarticle(Articleid)">Ajouter au panier</button>
      </div>
    </div>
      <div v-else class="thumbnail" >
      <router-link v-bind:to="{ path: 'articleDetails', query: { article: Articleid }}">
        <img class="taille" v-bind:src="Articleid.photo" />
      </router-link>
        <div class="caption">
          <router-link v-bind:to="{ path: 'articleDetails', query: { article: Articleid }}"><h3>{{Articleid.title}}</h3></router-link>
          <div>
							<span itemprop="price" class="price product-price">
							{{Articleid.price}}	€
              </span>
				</div>
          <p> Article vu <b>{{Articleid.visits}}</b> fois.</p>
          <router-link v-bind:to="{ path: 'articleDetails', query: { article: Articleid }}">
          <button type="button" class="btn btn-danger dropdown-toggle buttonCategory" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><span>Modifier</span></button></router-link>
        </div>
      </div>
</template>

<script>
import Vue from 'vue'
import $ from 'jquery'
import { mapGetters,mapActions } from 'vuex'
import AuthService from '../services/AuthService.js'
import ArticleServices from '../services/ArticleServices.js'

export default {
  components: {
  },
  props:["id"],
  data() {
    return {
      Articleid: this.id,
      services: AuthService
    }
  },
  computed:{
    ...mapGetters(['getCount']),
    auth: () => AuthService
  },
  methods: {
    ...mapActions(['increment']),
    ...mapActions(['setArticle']),
    addarticle: function (article) {
      this.setArticle(article)
      this.increment()
    },
    onVisited: async function(e){
        await ArticleServices.putNbVisitsAsync(e);
    }
  }
}
</script>


<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>


.taille{
  height:140px
}
h1, h2, h3 {
  font-weight: normal;
  color:white;
}
p{
  color:white;
}
.btn-default:hover{
  background-color: #BFA077;
  border:1px solid #7F6A4F;
-moz-box-shadow: 5px 5px 5px -5px #402E22;
-webkit-box-shadow: 5px 5px 5px -5px #402E22;
-o-box-shadow: 5px 5px 5px -5px #402E22;
box-shadow: 5px 5px 5px -5px #402E22;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#402E22, Direction=134, Strength=5);
}
.btn{
  color:white !important;
  text-decoration: none !important;
  background-color:#7F6A4F;
  border:none;
}
ul {
  list-style-type: none;
  padding: 0;
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
li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}

.price.product-price {
	font: 500 15px/17px "Roboto Condensed", sans-serif;
	color: #FFF;
	background:url(../imageprice.png);
	width: 75px;
	height: 34px;
	line-height: 37px;
	text-align: center;
	display: inline-block;
  border-radius : 5px;
  margin-left:170px;
	}
  
  

</style>
