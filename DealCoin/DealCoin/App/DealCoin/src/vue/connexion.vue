<template>
    <div>
        <div class="text-center">
            <div class="page-header">
                <h1>Bienvenue sur DealCoin!</h1>
            </div>
            <button type="button" @click="login('Google')" class="btn btn-lg btn-block btn-primary"><i class="fa fa-google" aria-hidden="true"></i> Se connecter via Google</button>
            <button type="button" @click="login('Base')" class="btn btn-lg btn-block btn-default">Se connecter sur notre site</button>
        </div>
    </div>
</template>
<script>
import AuthService from '../services/AuthService'
import UserService from '../services/UserService'
import Vue from 'vue'
import $ from 'jquery'

export default {
        data() {
            return {
                endpoint: null,
                User:[],
                email: null
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
                this.email = AuthService.hisEmail();
                this.loadModelUser(this.email);
                if(User.status != 0){
                this.$router.replace('/homeAdmin');
                }
                else{ 
                this.$router.replace('/homeMembers');
                }
               
            },
            loadModelUser: async function(email) {
              this.User = await UserService.getUserAsync(this.email);
              this.User = this.User.content;
            }
        }
    }
</script>
<style lang="less">
    iframe {
        width: 100%;
        height: 600px;
    }
</style>
