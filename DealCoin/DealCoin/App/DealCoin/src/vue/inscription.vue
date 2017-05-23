<template>
      <!-- Page Content -->
    <div class="container">
        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6 text-center">
                <div class="input-group">
                    <span class="input-group-addon" id="basic-addon1">Pseudo</span>
                    <input type="text" class="form-control" placeholder="Ecrivez votre pseudo ici" aria-describedby="basic-addon1">
                </div>

                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Ecrivez votre adress e-mail ici" aria-describedby="basic-addon2">
                    <span class="input-group-addon" id="basic-addon2">@example.com</span>
                </div>

                <div class="input-group">
                    <span class="input-group-addon" id="basic-addon1">Mot de passe</span>
                    <input type="text" class="form-control" placeholder="Ecrivez votre mot de passe ici" aria-describedby="basic-addon1">
                </div>

                <div class="input-group">
                    <span class="input-group-addon" id="basic-addon1">Confirmation mot de passe</span>
                    <input type="text" class="form-control" placeholder="Ecrivez votre mot de passe ici" aria-describedby="basic-addon1">
                </div>
                <a href="#" @click="login('Base')">Inscription</a>
            </div>
        </div>
    </div>
</template>
<script>
import AuthService from '../services/AuthService'
import Vue from 'vue'
import $ from 'jquery'

export default {
        data() {
            return {
                endpoint: null
            }
        },
        mounted() {
            AuthService.registerAuthenticatedCallback(() => this.onAuthenticated());
        },
        beforeDestroy() {
            AuthService.removeAuthenticatedCallback(() => this.onAuthenticated());
        },
        methods: {
            login(provider) {
                AuthService.login(provider);
            },
            onAuthenticated() {
                 this.$router.replace('/homeco');
            }
        }
    }
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
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
