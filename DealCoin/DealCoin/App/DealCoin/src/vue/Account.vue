<template>
<div>
    <div class="container">
            <div class="col-lg-12 text-center">
            <h3>Bonjour {{model.nom}}, vous pouvez modifier votre compte ici.</h3>
            <div class="row">
            <div class="col-md-12">
            <h1 class="display-1">Votre solde BitCoin</h1>
            <h1 class="display-1">{{solde.toFixed(8)}}</h1>
            </br>
            </div>
            </br>
            </br>
            
            <div class="col-md-12">
              <li class="dropdown">
                <button type="button" class="btn-lg btn-info dropdown-toggle clrbtn" data-toggle="dropdown">Recevoir</button>
                <ul style="margin-left: -95%;"class="dropdown-menu" role="menu">
                  <div  class="input-group">
                    <input style="width:225px;" type="text" class="form-control">
                    <span class="input-group-btn"><button class="btn btn-default" type="button">Recevoir</button></span>
                  </div>
                </ul>
              </li>
              </div>
            </br>
            </br>
          <div class="col-md-6">
                <h1>Modifier le profil</h1>
                
              <form @submit="onSubmit($event)" class="form-horizontal" role="form">
                <div class="form-group">
                  <label class="col-lg-3 control-label">Nom:</label>
                  <div class="col-lg-5">
                    <input class="form-control" v-model="model.nom" type="text" value="ddddd">
                  </div>
                  <br>
                </div>

                <div class="form-group">
                  <label class="col-lg-3 control-label">Prénom:</label>
                  <div class="col-lg-5">
                    <input class="form-control" v-model="model.prenom" type="text">
                  </div>
                  <br>
                </div>

                <div class="form-group">
                  <label class="col-lg-3 control-label">Téléphone:</label>
                  <div class="col-lg-5">
                    <input class="form-control" v-model="model.phone" type="text">
                  </div>
                  <br>
                </div> 

                <div class="form-group">
                  <label class="col-lg-3 control-label">Adresse:</label>
                  <div class="col-lg-5">
                    <input class="form-control" v-model="model.addresse" type="text">
                  </div>
                  <br>
                </div> 

                <div class="form-group">
                  <label class="col-lg-3 control-label">Département:</label>
                  <div class="col-lg-5">
                    <input class="form-control" v-model="model.departement" type="text">
                  </div>
                  <br>
                </div> 

                <div class="form-group">
                  <label class="col-lg-3 control-label">Ville: </label>
                  <div class="col-lg-5">
                    <input class="form-control" v-model="model.city" type="text">
                  </div>
                  <br>
                </div>

                <div class="form-group">
                  <label class="col-lg-3 control-label">Code Postale:</label>
                  <div class="col-lg-5">
                    <input class="form-control" v-model="model.postale" type="text">
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
              <label class="col-lg-5 control-label"><h4>{{model.email}}</h4></label>
            </div>
            <div class="form-group">
              <label class="col-md-3 control-label">Acien mot de passe:</label>
              <div class="col-md-5">
                <input class="form-control" v-model="PastCode" type="password" pattern="^[a-zA-Z]\w{3,14}$" title="
                Premier caractère doit être une lettre, 
                Minimum 4 caractères, Max 15, 
                Que des chiffres et lettres">
              </div>
            </div>
            <div class="form-group">
              <label class="col-md-3 control-label">Mot de passe:</label>
              <div class="col-md-5">
                <input class="form-control" v-model="newCode" type="password" pattern="^[a-zA-Z]\w{3,14}$" title="
                Premier caractère doit être une lettre, 
                Minimum 4 caractères, Max 15, 
                Que des chiffres et lettres">
              </div>
            </div>
            <div class="form-group">
              <label class="col-md-3 control-label"> Confirmation du mot de passe:</label>
              <div class="col-md-5">
                <input class="form-control" v-model="confirmNewCode" type="password"  pattern="^[a-zA-Z]\w{3,14}$" title="Premier caractère 
            doit être une lettre, un minumum de 6 caractères et maximum 15, que des chiffres et lettres">
              </div>
            </div>
            <div class="form-group">
              <label class="col-md-3 control-label"></label>
              <div class="col-md-5">
                <input name ="Save" class="btn btn-primary" value="Modifier le mot de passe" type="submit">
                <a  align="right" class="btn btn-danger" @click="deleteAccount(model.userId)">Supprimer le compte</a>           
              </div>
            </div>
            </form>

          </div>
</div>
            </div>
        </div>
        </div>
  </div>
</template>

<script>
import UserService from '../services/UserService.js'
import AuthService from '../services/AuthService.js'

export default {
  	data () {
      return {
        model: {},
        email: "",
        PastCode: null,
        newCode: null,
        confirmNewCode: null,
        solde: 0.00000000
      }
     },
    async mounted() {
            this.email = AuthService.hisEmail();
            this.loadModelUser(this.email);
        },
    methods: {
            onSubmit: async function(e) {
              e.preventDefault();
              var result = null;  
              result = await UserService.putUserAsync(this.model);
              confirm("Vous avez modifié votre compte.");
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
              }
              
              //this.model.pass = null
            }
    }
}
</script>       

<style scoped>
.clrbtn{
  background-color:#7F5D2F !important;
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