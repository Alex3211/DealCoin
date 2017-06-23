<template>

<div class="container">
    <nav class="navbar navbar-default" role="navigation">
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <li class="active"><router-link to="/homeAdmin"><i class="fa fa-home fa-fw"></i>Home</router-link></li>
                <li><router-link to="/userAdmin"><i class="fa fa-list-alt fa-fw"></i>Utilisateurs</router-link></li>
                <li><router-link to="/cellAdmin"><i class="fa fa-list-alt fa-fw"></i>Vente</router-link></li>
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
                        <th>Description</th>
                        <th>Prix</th>
                        <th>Date d'Achat</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="s of sales">
                        <td>{{s.orderProductsId}}</td>
                        <td>{{s.desc1}}</td>
                        <td>{{s.price}}</td>
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
import SalesService from '../services/SalesService'
import Vue from 'vue'
import $ from 'jquery'

import { mapGetters, mapActions } from 'vuex'

export default {
        data() {
            return {
                sales:{}
            }
        },
        mounted() {
            this.loadSalesProducts();
        },
        methods: {
            loadSalesProducts: async function(){
                var Sales = await SalesService.getAllSalesProductsAsync();
                this.sales = Sales.content;
            }
        }
    }
</script>
<style scoped>

</style>