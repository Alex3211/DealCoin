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
</div>

</template>

<script>
import AuthService from '../services/AuthService'
import UserService from '../services/UserService'
import Chart from 'chart.js';
import Vue from 'vue'
import $ from 'jquery'

import { mapGetters, mapActions } from 'vuex'

export default {
        data() {
            return {
                user:{}
            }
        },
        mounted() {
            this.loadUser();
        },
        methods: {
            ...mapGetters(['getUser']),
            ...mapActions(['setuser']),
            loadUser: async function(){
                var User = await UserService.getAllUserAsync();
                this.user = User;
                this.setuser(User);
            }
        }
    }
</script>
<style scoped>
.label,.glyphicon { margin-right:5px; }
</style>