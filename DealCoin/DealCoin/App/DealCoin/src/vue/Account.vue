<template>
<div class="hello">
        <div class="container">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h1>DealCoin</h1>

          <div align="left">
                <h1>Modifier le profil</h1>

              <form @submit="onSubmit($event)" class="form-horizontal" role="form">
                <div class="form-group">
                  <label class="col-lg-1 control-label">Prénom:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.firstName" type="text">
                  </div>
                  <br>
                </div>

                <div class="form-group">
                  <label class="col-lg-1 control-label">Nom:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.lastName" type="text">
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
                  <label class="col-lg-1 control-label">Téléphone:</label>
                  <div class="col-lg-3">
                    <input class="form-control" v-model="model.tel" type="text">
                  </div>
                  <br>
                </div> 

                <div class="form-group">
                  <label class="col-md-3 control-label"></label>
                  <div class="col-md-8">
                    <input class="btn btn-primary" value="Enregistrer" type="submit">
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

export default {
  	data () {
      return {
        model: {
            firstName : null,
            lastName : null,
            city : null,
            tel : null,
            mail : null
        }
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
                this.message = "Les modifications ont bien été apporté.";
                document.getElementById('1').className = 'on';
                window.setTimeout(function() {
                document.getElementById('1').className = 'off';                
                }, 4000);
              }
            },
            loadModelUser: async function(email) {
              this.model = await UserService.getUserAsync(email);
              this.model = this.model.content;
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

a {
  color: #42b983;
}
</style>