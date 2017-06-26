<template>

<div class="container">
    <nav class="navbar navbar-default" role="navigation">
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <li class="active"><router-link to="/homeAdmin"><i class="fa fa-home fa-fw"></i>Home</router-link></li>
                <li><router-link to="/userAdmin"><i class="fa fa-list-alt fa-fw"></i>Utilisateurs</router-link></li>
                <li><router-link to="/sellAdmin"><i class="fa fa-list-alt fa-fw"></i>Ventes</router-link></li>
                <li><router-link to="/articleAdmin"><i class="fa fa-list-alt fa-fw"></i>Articles</router-link></li>
                <li><router-link to="/reportAdmin"><i class="fa fa-list-alt fa-fw"></i>Report</router-link></li>
            </ul>   
        </div>
    </nav>
    <div class="row">
        <div class="col-lg-12">
            <table class="table" id="table">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Catégorie</th>
                        <th>Nom</th>
                        <th>Prix</th>
                        <th>Date d'ajout</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="a of article">
                        <td>{{a.productsId}}</td>
                        <td>{{a.desc1}}</td>
                        <td>{{a.title}}</td>
                        <td>{{a.price}}</td>
                        <td>12/10/2016</td>
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
import articleApiService from '../services/ArticleServices.js'
import Vue from 'vue'
import $ from 'jquery'

import { mapGetters, mapActions } from 'vuex'

export default {
        data() {
            return {
                article:[]
            }
        },
        mounted() {
            this.loadArticle();
        },
        methods: {
            loadArticle: async function(){
            var e = await articleApiService.getArticleListAsync();
            this.article = e.content;
            }
        }
    }
</script>
<style scoped>
body{margin-top:20px;}
.fa-fw {width: 2em;
.btn-glyphicon { padding:8px; background:#ffffff; margin-right:4px;}
.icon-btn { padding: 1px 15px 3px 2px; border-radius:50px;}
}
</style>