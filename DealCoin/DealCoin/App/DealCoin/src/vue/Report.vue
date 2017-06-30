<template>
    <div class="container">

        <div>
            <div>
                      <h1 style="margin-left:-130px">Envoyez-nous votre commentaire !</h1>
                      <form @submit="onSubmit($event)" class="form-horizontal" role="form">
                        <div class="form-group">
                          <label class="col-lg-3 control-label">Message :</label>
                          <div class="col-lg-5">
                            <textarea class="form-control" rows="5" id="comment"></textarea>
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
        email: ""
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
              confirm("Nous avons bien reçu votre commentaire !");
            },
            loadModelUser: async function(email) {
              
              var Model2= await UserService.getUserAsync(email);
              this.model=Model2.content;
              //this.model.userId = this.model.content.userId;
            }
    }
}
</script>