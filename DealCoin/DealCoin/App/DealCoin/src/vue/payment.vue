<template>
    <div class="container">
    <div v-if="article == 0">
         <h3>Vous n'avez actuellement aucun article dans votre panier !</h3>
        <br/>
        <router-link to="/articles"><button type="button" class="btn btn-default buttonCategory">Retour à la boutique</button></router-link> 
    </div>
        <div class="row" v-else>
            <div class="col-sm-12 col-md-10 col-md-offset-1">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>Article</th>
                            <th class="text-center">Total : </th>
                            <th> </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(a, index) of article" >
                            <td class="col-sm-8 col-md-6">
                            <a class="thumbnail pull-left"> <img class="media-object"  v-bind:src="a.photo" style="width: 72px; height: 72px;"> </a>
                                <h4>{{a.title}}</h4>
                                <span>Veuillez envoyer {{a.price}}€ a cette adresse :<h6 style='color:orange;'>{{a.userAdresse}}</h6></span>
                              
                            </td>
                            <td class="col-sm-1 col-md-1 text-center"><strong><h4>{{a.price}} €</h4></strong></td>
                            <td class="col-sm-1 col-md-1">
                            <button type="button" class="btn btn-danger buttonCategory" v-on:click="Delarticle(index)">
                                <span></span> Supprimer l'article
                            </button></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<style scoped>

.table-hover tbody tr:hover td, .table-hover tbody tr:hover th {
  background-color: #402E22;
}
.buttonCategory:focus, .btn:hover{
background-color: #BFA077!important;
color:white!important;
-moz-box-shadow: 5px 5px 5px -5px #BFA077;
-webkit-box-shadow: 5px 5px 5px -5px #BFA077;
-o-box-shadow: 5px 5px 5px -5px #BFA077;
box-shadow: 5px 5px 5px -5px #BFA077;
filter:progid:DXImageTransform.Microsoft.Shadow(color=#BFA077, Direction=134, Strength=5);
}

.btn-default:active, .btn-default.active, .open > .btn-default.dropdown-toggle {
background-color: #BFA077;
border:none;
 margin-left:5px;
 margin-right:5px;
}
button:hover{
background-color:#BFA077!important;
}
.btn{
 background-color:#BFA077;
 border:none;
}
</style>

<script>
import Vue from 'vue'
import $ from 'jquery'
import { mapGetters,mapActions } from 'vuex'
import UserService from '../services/UserService.js'

export default {
        data() {
            return {
                article:[],
                totaleprix:0,
                tva:1.9,
                livraison:0,
                totaletopay:0
            }
        },
        async mounted() {
            await this.loadArticle();
        },
        methods: {
            ...mapGetters(['getArticle']),
            ...mapActions(['delArticle']),
            ...mapActions(['decrement']),
            loadArticle: async function(){
                this.article = await this.getArticle();
                for(var i =0 ; i < this.article.length; i++) {
                    this.$set(this.article[i], 'userAdresse', await this.GetBitcoinAdress(this.article[i].userId));
                }
            },
            GetBitcoinAdress : async function(id){
                var User = await UserService.getUserByIdAsync(id);
                return User.content.adresse_bitcoin;
            },
            Delarticle(i){
                this.delArticle(i)
                this.totaleprix = 0
                this.loadArticle()
                this.decrement()
            }
        }
    }
</script>