<template>
<div class="hello">
    <div class="container">
      <img src="../assets/logo.png"><div class="row">
            <div class="col-lg-12 text-center">
            <h3>Bonjour, {{model.nom}}, vous pouvez modifier votre compte ici.</h3>
          <div align="left">
                <h1>Modifier le profil</h1>

              <form @submit="onSubmit($event)" class="form-horizontal" role="form">
                <div class="form-group">
                  <label class="col-lg-1 control-label">Nom:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.nom" type="text" value="ddddd">
                  </div>
                  <br>
                </div>

                <div class="form-group">
                  <label class="col-lg-1 control-label">Prénom:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.prenom" type="text">
                  </div>
                  <br>
                </div>

                <div class="form-group">
                  <label class="col-lg-1 control-label">Téléphone:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.phone" type="text">
                  </div>
                  <br>
                </div> 

                <div class="form-group">
                  <label class="col-lg-1 control-label">Adresse:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.addresse" type="text">
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
        model: {},
        email: "",
        newPass: null,
        confirmNewPass: null
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