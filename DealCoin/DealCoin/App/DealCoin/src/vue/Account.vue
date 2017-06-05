<template>
<div class="hello">
    <div class="container">
      <img src="../assets/logo.png"><div class="row">
            <div class="col-lg-12 text-center">

          <div align="left">
                <h1>Modifier le profil</h1>

              <form @submit="onSubmit($event)" class="form-horizontal" role="form">
                <div class="form-group">
                  <label class="col-lg-1 control-label">Nom:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.lastName" type="text" value="ddddd">
                  </div>
                  <br>
                </div>

                <div class="form-group">
                  <label class="col-lg-1 control-label">Prénom:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.firstName" type="text">
                  </div>
                  <br>
                </div>

                <div class="form-group">
                  <label class="col-lg-1 control-label">Téléphone:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.tel" type="text">
                  </div>
                  <br>
                </div> 

                <div class="form-group">
                  <label class="col-lg-1 control-label">Adresse:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.adresse" type="text">
                  </div>
                  <br>
                </div> 

                <div class="form-group">
                  <label class="col-lg-1 control-label">Département:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.departement" type="text">
                  </div>
                  <br>
                </div> 

                <div class="form-group">
                  <label class="col-lg-1 control-label">Ville: </label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.city" type="text">
                  </div>
                  <br>
                </div>

                <div class="form-group">
                  <label class="col-lg-1 control-label">Code Postale:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.postale" type="text">
                  </div>
                  <br>
                </div> 

                <div class="form-group">
                  <label class="col-md-1 control-label"></label>
                  <div class="col-md-3">
                    <input class="btn btn-primary" value="Enregistrer" type="submit">
                </div>
                </div>
              </form>
          </div>

          <div align="left">
            <h1>Modifier le compte</h1>
                <form @submit="onSubmitPasse($event)" class="form-horizontal" role="form">    
            <div class="form-group">
              <label class="col-lg-1 control-label">Email:</label>
              <div class="col-lg-3">
                <input class="form-control" v-model="model.mail" type="email"required>
              </div>
            </div>
            <div class="form-group">
              <label class="col-md-1 control-label">Mot de passe:</label>
              <div class="col-md-3">
                <input class="form-control" v-model="newPass" type="password">
              </div>
            </div>
            <div class="form-group">
              <label class="col-md-1 control-label"> Confirmation du mot de passe:</label>
              <div class="col-md-3">
                <input class="form-control" v-model="confirmNewPass" type="password">
              </div>
            </div>
            <div class="form-group">
              <label class="col-md-1 control-label"></label>
              <div class="col-md-3">
                <input name ="Save" class="btn btn-primary" value="Enregistrer" type="submit">            
                <a class="btn btn-danger" @click="deleteAccount">Supprimer le compte</a>
              </div>
            </div>
            </form>

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
        model: {
            lastName : null,
            firstName : null,
            tel : null,
            adresse :null,
            departement:null,
            city : null,
            postale:null,
            mail : null
        },
        email: "",
        newPass: null,
        confirmNewPass: null
      }
     },
    methods: {
            onSubmit: async function(e) {
              e.preventDefault();
              var result = null;
                if (this.model.tel.length == 0)
                  this.model.tel = 0;   
              result = await UserService.postUserAsync(this.model);
              if(result != null)
              {
                this.model = await UserService.getUserAsync(this.email);
                this.model = this.model.content;
                this.message = "Profil modifié.";
                document.getElementById('2').className = 'on';
                window.setTimeout(function() {
                document.getElementById('2').className = 'off';                
                }, 4000);
              }
            },
            loadModelUser: async function(email) {
              this.model = await UserService.getUserAsync(email);
              this.model = this.model.content;
            },
            async deleteAccount(){

            var model = await UserService.getUserAsync(this.email);
            model = model.content;

            model = await ConversationService.getEventIdAsync(this.model.userId);
            model = model.content;

            var confirme2 = confirm("Vous êtes sur le point de supprimer un compte. Tout vos événements vont êtres supprimer. Êtes-vous sûr ?");
              if(confirme2 != false)
              {
                  var i = 0;
                  while (i != model.length)
                  {
                      var result = await EventService.deleteEvent(model[i].eventId);
                      if(result == false)
                        return;
                        i++;
                  }
                  await UserService.deleteUserAsync(this.model.userId);
                  this.$router.replace('/');             
              }
            },
            onSubmitPasse: async function(e) {
              e.preventDefault();
              if(this.newPass !== this.confirmNewPass) return 
              this.model.Passe = this.newPass
              var result = null;
              result = await UserService.putUserAsync(this.model);
              this.model.pass = null
              if(result != null)
              {
                this.model = await UserService.getUserAsync(this.email);
                this.model = this.model.content;
                this.message = "Compte modifié"
                document.getElementById('1').className = 'on';
                window.setTimeout(function() {
                document.getElementById('1').className = 'off';                
                }, 4000);              
              }
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



div.hello {
  background-color : #70B2E2;
  color : yellow;
}
</style>