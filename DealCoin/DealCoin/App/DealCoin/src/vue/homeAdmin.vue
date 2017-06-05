<template>
<div class="container">
    <div class="row">
        <div class="col-md-3">
            <ul class="nav nav-pills nav-stacked admin-menu">
                <li class="active"><a href="#" data-target-id="home"><i class="fa fa-home fa-fw"></i>Home</a></li>
                <li><a href="" data-target-id="widgets"><i class="fa fa-list-alt fa-fw"></i>Users</a></li>
                <li><a href="" data-target-id="pages"><i class="fa fa-file-o fa-fw"></i>Ventes</a></li>
                <li><a href="" data-target-id="widgets"><i class="fa fa-list-alt fa-fw"></i>Articles</a></li>
                <li><a href="" data-target-id="pages"><i class="fa fa-file-o fa-fw"></i>Raport</a></li>
            </ul>
        </div>
        <div class="col-md-9 well admin-content" id="home">
          <div class="container">
            <a class="btn icon-btn btn-success" href="#"><span class="glyphicon btn-glyphicon glyphicon-plus img-circle text-success"></span>Add</a>
            <a class="btn icon-btn btn-info" href="#"><span class="glyphicon btn-glyphicon glyphicon-share img-circle text-info"></span>Share</a>
            <a class="btn icon-btn btn-warning" href="#"><span class="glyphicon btn-glyphicon glyphicon-minus img-circle text-warning"></span>Remove</a>
            <a class="btn icon-btn btn-danger" href="#"><span class="glyphicon btn-glyphicon glyphicon-trash img-circle text-danger"></span>Delete</a>
          </div>
            <p>
                Hello! This is a forked snippet.<br>
                It is for users, which use one-page layouts.
            </p>
            <p>
                Here's the original one from BhaumikPatel: 
                <br><br>
                <strong>Thank you Bhaumik!</strong> 
                Dans la vie on ne fait pas ce que l'on veut mais on est responsable de ce que l'on est.
                <br><br>
                Exige beaucoup de toi-même et attends peu des autres. Ainsi beaucoup d'ennuis te seront épargnés.
                <br><br>
            </p>
            <div class="col-md-3">
            <div class="list-group">
                <a href="http://www.jquery2dotnet.com" class="list-group-item visitor">
                    <h3 class="pull-right">
                        <i class="fa fa-eye"></i>
                    </h3>
                    <h4 class="list-group-item-heading count">
                        1000</h4>
                    <p class="list-group-item-text">
                        Profile Views</p>
                </a><a href="http://www.jquery2dotnet.com" class="list-group-item facebook-like">
                    <h3 class="pull-right">
                        <i class="fa fa-facebook-square"></i>
                    </h3>
                    <h4 class="list-group-item-heading count">
                        1000</h4>
                    <p class="list-group-item-text">
                        Facebook Likes</p>
                </a><a href="http://www.jquery2dotnet.com" class="list-group-item google-plus">
                    <h3 class="pull-right">
                        <i class="fa fa-google-plus-square"></i>
                    </h3>
                    <h4 class="list-group-item-heading count">
                        1000</h4>
                    <p class="list-group-item-text">
                        Google+</p>
                </a><a href="http://www.jquery2dotnet.com" class="list-group-item twitter">
                    <h3 class="pull-right">
                        <i class="fa fa-twitter-square"></i>
                    </h3>
                    <h4 class="list-group-item-heading count">
                        1000</h4>
                    <p class="list-group-item-text">
                        Twitter Followers</p>
                </a>
            </div>
        </div>
        </div>
        </div>
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
            }
        },
        mounted() {
            
        },
        methods: {
            
        }
    }
</script>
<style scoped>
body{margin-top:20px;}
.fa-fw {width: 2em;
.btn-glyphicon { padding:8px; background:#ffffff; margin-right:4px; }
.icon-btn { padding: 1px 15px 3px 2px; border-radius:50px;}
}
</style>