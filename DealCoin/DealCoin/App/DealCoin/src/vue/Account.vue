<template>
<div>
    <div class="container">
      <div class="col-lg-12 text-center">
      <h3>Bonjour {{model.nom}}, vous pouvez modifier votre compte ici.</h3>
      <div class="row">
        <div class="col-md-12" v-if="this.model.adresse_bitcoin !== '' || this.model.adresse_bitcoin !== null">
          <h1 class="display-1">Votre adresse BitCoin</h1>
          <h1 class="display-1">{{this.model.adresse_bitcoin}}</h1>
          </br>
        </div>
          </br>
          </br>
        <div class="row">
          <div class="col-md-12">
            <li class="dropdown">
              <button type="button" class="btn-lg btn-info dropdown-toggle clrbtn" data-toggle="dropdown">Créditer votre compte</button>
              <ul class="dropdown-menu" role="menu">
                <div  class="input-group">
                  <input style="width:225px;" type="text" class="form-control">
                  <span class="input-group-btn"><button class="btn btn-default" type="button">Recevoir</button></span>
                </div>
              </ul>
            </li>
          </div>            
        </div>
          <br>
        <div class="row">
          <div class="col-md-12">
            <div class="btn-group" role="group" aria-label="..." >
              
              <button type="button" class="btn-lg btn-info clrbtn" v-on:click="ShowAccount('invisible')">Modifier son compte</button>
              <button type="button" class="btn-lg btn-info clrbtn" v-on:click="ShowAccount('invisibleGrap')">Informations</button>
              <button type="button" class="btn-lg btn-info clrbtn" v-on:click="ShowAccount('dmin')">Contacter un administrateur</button>
              <button type="button" class="btn-lg btn-info clrbtn" v-on:click="ShowAccount('mArticles')">Gestion de mes articles</button>
            </div>
          </div>
        </div>
        </br>
        <div class="row" style="display:none;" id="mArticles">
        <table class="table" id="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Catégorie</th>
                        <th>Nom</th>
                        <th>Prix</th>
                        <th>Date d'ajout</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="a of article">
                        <td>{{a.productsId}}</td>
                        <td>{{a.desc1}}</td>
                        <td>{{a.title}}</td>
                        <td>{{a.price}}</td>
                        <td>12/10/2016</td>
                        <td><router-link v-bind:to="{ path: 'DelArticle', query: { article: a, account: true }}"><a href="#"><button type="button" class="btn-lg btn-info clrbtn">Supprimer</button></a></router-link></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="row" style="display:none;" id="dmin">
          <form @submit="submitReportReport()" class="form-horizontal" role="form">
            <div class="form-group">
              <label class="col-lg-3 control-label">Message :</label>
                <div class="col-lg-5">
                  <textarea  v-model="model.message" class="form-control" rows="5" id="comment"></textarea>
                </div>
              <br>
            </div>

            <div class="form-group">
              <label class="col-lg-3 control-label">Sujet :</label>
                <div class="col-lg-5">
                  <input v-if="model.phone == null || model.subject == ''" class="form-control red" v-model="model.subject" type="text">
                  <input v-else class="form-control" v-model="model.subject" type="text">
                </div>
              <br>
            </div> 

            <div class="form-group">
              <label class="col-lg-3 control-label">Téléphone :</label>
                <div class="col-lg-5">
                  <input v-if="model.phone == null || model.phone == ''" class="form-control red" v-model="model.phone" type="text">
                  <input v-else class="form-control" v-model="model.phone" type="text">
                </div>
              <br>
            </div>
            <div class="form-group">
              <label class="col-md-3 control-label"></label>
              <div class="col-md-5">
                <input class="btn btn-primary" value="Envoyer" type="submit">
              </div>
            </div>
          </form>
        </div>
        <div class="row" style='display:none;' id="invisibleGrap">
            <p>Nombre d'article En Vente: {{this.article.length}}</p>
            <div class="col-lg-12">
              <table class="table" id="table">
                  <thead>
                      <tr>
                          <th>Description article</th>
                          <th>Nb Vue</th>
                          <th>Date d'ajout</th>
                      </tr>
                  </thead>
                  <tbody>
                      <tr v-for="a of articleev">
                          <td>{{a.desc1}}</td>
                          <td>{{a.visits}}</td>
                          <td>{{a.updated}}</td>
                      </tr>
                  </tbody>
              </table>
              <hr>
            </div>
            </br>
            <p>Nombre d'article Vendue: {{this.sales.length}}</p>
            <div class="col-lg-12">
                <table class="table" id="table">
                    <thead>
                        <tr>
                            <th>Description article</th>
                            <th>Prix</th>
                            <th>Date de Vente</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="s of articlev">
                            <td>{{s.title}}</td>
                            <td>{{s.price}} €</td>
                            <td>{{s.sales_date}}</td>
                        </tr>
                    </tbody>
                </table>
                <hr>
            </div>
          </div>
        <div class="row" style='display:none;' id="invisible">
            <div class="col-md-1"></div>
            <div class="col-md-10">
              <div class="row">
                <div class="col-md-6">
                    <h1>Modifier le profil</h1>
                    <form @submit="onSubmit($event)" class="form-horizontal" role="form">
                      <div class="form-group">
                        <label class="col-lg-3 control-label">adresse bitcoin:</label>
                        <div class="col-lg-5">
                          <input v-if="model.adresse_bitcoin == null || model.adresse_bitcoin == ''" class="form-control red" v-model="model.adresse_bitcoin" type="text" value="ddddd">
                          <input v-else class="form-control" v-model="model.adresse_bitcoin" type="text" value="ddddd">
                        </div>
                        <br>
                      </div>
                      <div class="form-group">
                        <label class="col-lg-3 control-label">Nom:</label>
                        <div class="col-lg-5">
                          <input v-if="model.nom == null || model.nom == ''" class="form-control red" v-model="model.nom" type="text" value="ddddd">
                          <input v-else class="form-control" v-model="model.nom" type="text" value="ddddd">
                        </div>
                        <br>
                      </div>
                      <div class="form-group">
                        <label class="col-lg-3 control-label">Prénom:</label>
                        <div class="col-lg-5">
                          <input v-if="model.prenom == null || model.prenom == ''" class="form-control red" v-model="model.prenom" type="text">
                          <input v-else class="form-control" v-model="model.prenom" type="text">
                        </div>
                        <br>
                      </div>

                      <div class="form-group">
                        <label class="col-lg-3 control-label">Téléphone:</label>
                        <div class="col-lg-5">
                          <input v-if="model.phone == null || model.phone == ''" class="form-control red" v-model="model.phone" type="text">
                          <input v-else class="form-control" v-model="model.phone" type="text">
                        </div>
                        <br>
                      </div> 

                      <div class="form-group">
                        <label class="col-lg-3 control-label">Adresse:</label>
                        <div class="col-lg-5">
                          <input v-if="model.addresse == null || model.addresse == ''" class="form-control red" v-model="model.addresse" type="text">
                          <input v-else class="form-control" v-model="model.addresse" type="text">
                        </div>
                        <br>
                      </div> 

                      <div class="form-group">
                        <label class="col-lg-3 control-label">Département:</label>
                        <div class="col-lg-5">
                          <input v-if="model.departement == null || model.departement == ''" class="form-control red" v-model="model.departement" type="text">
                          <input v-else class="form-control" v-model="model.departement" type="text">
                        </div>
                        <br>
                      </div> 

                      <div class="form-group">
                        <label class="col-lg-3 control-label">Ville: </label>
                        <div class="col-lg-5">
                          <input v-if="model.city == null || model.city == ''" class="form-control red" v-model="model.city" type="text">
                          <input v-else class="form-control" v-model="model.city" type="text">
                        </div>
                        <br>
                      </div>

                      <div class="form-group">
                        <label class="col-lg-3 control-label">Code Postale:</label>
                        <div class="col-lg-5">
                          <input v-if="model.postale == null || model.postale == ''" class="form-control red" v-model="model.postale" type="text">
                          <input v-else class="form-control" v-model="model.postale" type="text">
                        </div>
                        <br>
                      </div> 

                      <div class="form-group">
                        <label class="col-md-3 control-label"></label>
                        <div class="col-md-5">
                          <input class="btn btn-primary" value="Enregistrer" type="submit">
                      </div>
                      </div>
                    </form>
                </div>

                <div class="col-md-6">
                  <h1>Modifier le compte</h1>
                  <form @submit="onSubmitPasse($event)" class="form-horizontal" role="form">    
                      <div class="form-group">
                        <label class="col-lg-5 control-label"><p>Votre mail: {{model.email}}</p></label>
                      </div>
                      <div class="form-group">
                        <label class="col-md-3 control-label">Mot de passe:</label>
                        <div class="col-md-5">
                          <input required class="form-control" v-model="newCode" type="password" pattern="^[a-zA-Z]\w{4,14}$" title="
                          Premier caractère doit être une lettre, 
                          Minimum 5 caractères, Max 15, 
                          Que des chiffres et lettres">
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="col-md-3 control-label"> Confirmation du mot de passe:</label>
                        <div class="col-md-5">
                          <input required class="form-control" v-model="confirmNewCode" type="password"  pattern="^[a-zA-Z]\w{4,14}$" title="Premier caractère 
                      doit être une lettre, un minumum de 5 caractères et maximum 15, que des chiffres et lettres">
                        </div>
                      </div>
                      <div class="form-group">
                        <label class="col-md-3 control-label"></label>
                        <div class="col-md-5">
                          <input name ="Save" class="btn btn-primary" value="Modifier le mot de passe" type="submit">
                          <br><br>
                          <a  align="right" class="btn btn-danger" @click="deleteAccount(model.userId)">Supprimer le compte</a>           
                        </div>
                      </div>
                  </form>
                </div>
              </div>
            </div>
            <div class="col-md-1"></div>
          </div>

        </div>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import moment from 'moment'
import articleApiService from '../services/ArticleServices.js'
import SalesService from '../services/SalesService'
import UserService from '../services/UserService.js'
import AuthService from '../services/AuthService.js'
import ReportService from '../services/ReportServices.js'

export default {
  	data () {
      return {
        model: {},
        article:[],
        sales:[],
        articleev:[],
        articlev:[],
        email: "",
        newCode: null,
        confirmNewCode: null,
        solde: 0.00000000,
        modify: false,
        graphs: false,
        BoolArticle: false,
        sendReport: false
      }
     },
    async mounted() {
            this.email = AuthService.hisEmail();
            await this.loadModelUser(this.email);
            await this.loadSalesProducts();
            await this.loadArticle();
            await this.sortSales();
            await this.sortArticle();
        },
    methods: {
          loadSalesProducts: async function(){
              var Sales = await SalesService.getAllSaleandProductByUserIdAsync(this.model.userId);
              this.sales = Sales.content;
          },
          loadArticle: async function(){
            var e = await articleApiService.GetArticleListByIdAsync(this.model.userId);
            this.article = e.content;
          },
          sortArticle: async function(){
              for(var i=0;i<this.article.length;i++){
                 if(this.article[i]){
                  var date = moment(this.article[i].updated, moment.ISO_8601);
                  this.article[i].updated = date.fromNow();
                  this.articleev.push(this.article[i]);
                }
              } 
          },
          sortSales: async function(){
              for(var i=0;i<this.sales.length;i++){
                 if(this.sales[i]){
                  var date = moment(this.sales[i].sales_date, moment.ISO_8601);
                  this.sales[i].sales_date = date.fromNow();
                  this.articlev.push(this.sales[i]);
                }
              } 
          },
          ShowAccount: async function(id){
            if(this.BoolArticle){
              this.ShowFunction('mArticles');
              this.BoolArticle = !this.BoolArticle;
            } 
            if(this.modify){
              this.ShowFunction('invisible');
              this.modify = !this.modify;
            } 
            if(this.graphs){
              this.ShowFunction('invisibleGrap');
              this.graphs = !this.graphs;
            }
            if(this.sendReport){
              this.ShowFunction('dmin');
              this.sendReport = !this.sendReport;
            }
            if(id == 'mArticles'){
              this.BoolArticle = !this.BoolArticle;
            } 
            if(id == 'invisible'){
              this.modify = !this.modify;
            } 
            if(id == 'invisibleGrap'){
              this.graphs = !this.graphs;
            } 
            if(id == 'dmin'){
              this.sendReport = !this.sendReport;
            }
            this.ShowFunction(id);
          },
          ShowFunction: function(id){
            if(document.getElementById(id).style.display == 'none'){
                document.getElementById(id).style.display = 'block';
              }
              else {
                document.getElementById(id).style.display = 'none';
               }  
            },
            onSubmit: async function(e) {
              e.preventDefault();
              var result = null;  
              result = await UserService.putUserAsync(this.model);
              confirm("Vous avez modifié votre compte.");
              this.$router.go('/Account'); 
            },
            loadModelUser: async function(email) {
              
              var Model2= await UserService.getUserAsync(email);
              this.model=Model2.content;
              //this.model.userId = this.model.content.userId;
            },
            async deleteAccount(e){
                if (confirm("Voulez-vous vraiment supprimer votre compte ?") == true) {
                   await UserService.deleteUserAsync(e);
                var User = await UserService.getAllUserAsync();
                this.user = User.content;
                this.$router.replace('/Logout');                    
                }
            },
               submitReportReport: async function() {
              
              var result = null;  
              result = await ReportService.putReportAsync(this.model);
              confirm("Nous avons bien reçu votre commentaire !");
              this.$router.replace('/Account'); 
            },
            onSubmitPasse: async function(e) {
              e.preventDefault();
              if(this.newCode !== this.confirmNewCode) 
              {
                confirm("Les mots de passe ne correspondent pas !");
              }
              else
              {
              this.model.password = this.newCode
              var result = null;
              result = await UserService.putUserPassAsync(this.model);
              confirm("Vous avez modifié votre mot de passe !");
              this.$router.replace('/Account'); 
              }
            }
    }
}
</script>       

<style scoped>
    .form-control:focus {
        border-color: #402E22;
        outline: 0;
        -webkit-box-shadow: inset 0 1px 1px #402E22, 0 0 8px #402E22;
        box-shadow: inset 0 1px 1px #402E22, 0 0 8px #402E22;
    }
.red {
    border-color: red;
    outline: 0;
    -webkit-box-shadow: inset 0 1px 1px red, 0 0 8px red;
    box-shadow: inset 0 1px 1px red, 0 0 8px red;
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
.clrbtn{
  background-color:#BFA077 !important;
  border:none;
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

div.div2{

}
</style>