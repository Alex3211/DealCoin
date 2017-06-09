<template>
<div>
    <div class="container">

            <div class="col-lg-12 text-center">
            <h3>Bonjour, {{model.nom}}, vous pouvez modifier votre compte ici.</h3>
            <div class="row">
            
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
              <label class="col-md-3 control-label">Mot de passe:</label>
              <div class="col-md-5">
                <input class="form-control" v-model="newCode" type="password">
              </div>
            </div>
            <div class="form-group">
              <label class="col-md-3 control-label"> Confirmation du mot de passe:</label>
              <div class="col-md-5">
                <input class="form-control" v-model="confirmNewCode" type="password">
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
        newCode: null,
        confirmNewCode: null
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
              if(this.newCode !== this.confirmNewCode) return 
              this.model.password = this.newCode
              var result = null;
              result = await UserService.putUserPassAsync(this.model);
              //this.model.pass = null
            }
    }
}
</script>       

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

div.div2{

}
</style>