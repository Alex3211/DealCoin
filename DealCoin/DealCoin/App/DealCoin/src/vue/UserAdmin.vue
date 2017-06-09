<template>
<div class="container">
    <nav class="navbar navbar-default" role="navigation">
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <li class="active"><router-link to="/homeAdmin"><i class="fa fa-home fa-fw"></i>Home</router-link></li>
                <li><router-link to="/userAdmin"><i class="fa fa-list-alt fa-fw"></i>Users</router-link></li>
                <li><router-link to="/cellAdmin"><i class="fa fa-list-alt fa-fw"></i>Cell</router-link></li>
                <li><router-link to="/articleAdmin"><i class="fa fa-list-alt fa-fw"></i>Articles</router-link></li>
                <li><router-link to="/reportAdmin"><i class="fa fa-list-alt fa-fw"></i>Report</router-link></li>
            </ul>   
        </div>
    </nav>
    <a @click="showadd()" class="btn btn-success">Ajouter un Utilisateur <span class="glyphicon glyphicon-user"></span></a>
    <div class="row" id="add">
      <form @submit="onSubmit($event)" class="form-horizontal" role="form">
        <div class="form-group">
          <label class="col-lg-3 control-label">Email:</label>
          <div class="col-lg-8">
            <input class="form-control" v-model="newuser.email" type="text">
          </div>
        </div>
        <div class="form-group">
          <label class="col-lg-3 control-label">Mots de passe:</label>
          <div class="col-lg-8">
            <input class="form-control" v-model="newuser.password" type="text">
          </div>
        </div>
        
        <div class="form-group">
          <label class="col-md-3 control-label"></label>
          <div class="col-md-8">
            <input class="btn btn-primary" value="Enregistrer" type="submit">
          </div>
		</div>
          </form>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <table class="table" id="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Email</th>
                        <th>Date d'Inscription</th>
                        <th>...</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="u of user">
                        <td>{{ u.userId }}</td>
                        <td>{{ u.email }}</td>
                        <td>12/06/2016</td>
                        <td><a class="btn btn-xs btn-danger" @click="deleteAccount(u.userId)"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></a></td>
                    </tr>
                </tbody>
            </table>
            <hr>
        </div>
    </div>
</div>

</template>

<script>
import AuthService from '../services/AuthService'
import UserService from '../services/UserService'
import Vue from 'vue'
import $ from 'jquery'

import { mapGetters, mapActions } from 'vuex'

export default {
        data() {
            return {
                newuser:{
                    email:'',
                    password:''
                },
                user:[]
            }
        },
        mounted() {
            this.loadUser();
            this.hideadd();
        },
        methods: {
            ...mapGetters(['getUser']),
            ...mapActions(['setuser']),
            loadUser: async function(){
                var User = await UserService.getAllUserAsync();
                this.user = User.content;
                this.setuser(User);
            },
            async deleteAccount(e){
                await UserService.deleteUserAsync(e);
                var User = await UserService.getAllUserAsync();
                this.user = User.content;
            },
            hideadd(){
                $('#add').hide();
            },
            showadd(){
                $('#add').show();
            },
            onSubmit: async function(e) {
              e.preventDefault();
              var result = null;  
              result = await UserService.postUserAdminAsync(this.newuser);
              this.hideadd();
              var User = await UserService.getAllUserAsync();
              this.user = User.content;

            }
        }
    }
</script>
<style scoped>
.label,.glyphicon { margin-right:5px; }
</style>