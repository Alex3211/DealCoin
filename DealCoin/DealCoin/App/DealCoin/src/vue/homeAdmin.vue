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
            <div class="col-md-6">
                <span>Nouvel utilisateur</span>
                <canvas class="graphBar"></canvas>
            </div>
            <div class="col-md-6">
                <span>Vente</span>
                <canvas class="line"></canvas>
            </div>
            <div class="col-md-6">
                <span>Article par catégories</span>
                <canvas class="dognut"></canvas>
            </div>
        </div>
    </div>
</div>

</template>

<script>
import AuthService from '../services/AuthService'
import UserService from '../services/UserService'
import SalesService from '../services/SalesService'
import ArticleServices from '../services/ArticleServices.js'
import CategoryApiService from '../services/CategoryService.js'
import Chart from 'chart.js'
import moment from 'moment'
import Vue from 'vue'
import $ from 'jquery'

import { mapGetters,mapActions } from 'vuex'

export default {
        data() {
            return {
                user:{},
                article: {},
                category: {},
                sales:{},
                cat0:[],
                cat1: [],
                cat2: [],
                cat3: [],
                cat4:[],
                userjanvier:0,
                userfevrier:0,
                usermars:0,
                useravril:0,
                usermai:0,
                userjuin:0,
                userjuillet:0,
                useraout:0,
                userseptembre:0,
                useroctobre:0,
                usernovembre:0,
                userdecembre:0,
                vente:{
                    janvier:0,
                    fevrier:0,
                    mars:0,
                    avril:0,
                    mai:0,
                    juin:0,
                    juillet:0,
                    aout:0,
                    septembre:0,
                    octobre:0,
                    novembre:0,
                    decembre:0,
                }
            }
        },
       async mounted() {
           await this.loadArticle();
           await this.loadUser();
           await this.loadSalesProducts();
           await this.loadCategory();
           await this.sortCategory();
           await this.sortUser();
           await this.sortVente();
            this.graphBar();
            this.graphLine();
            this.graphDognut();
            
        },
        methods: {
            ...mapGetters(['getUser']),
            ...mapActions(['setuser']),
            loadUser: async function(){
                var User = await UserService.getAllUserAsync();
                this.user = User;
                this.setuser(User);
            },
            loadArticle: async function(){
            var e = await ArticleServices.getArticleListAsync();
            this.article = e.content;
            },
            loadSalesProducts: async function(){
                var Sales = await SalesService.getAllSalesAsync();
                this.sales = Sales.content;
            },
            loadCategory: async function(){
                var e = await CategoryApiService.getCategoryListAsync();
                this.category = e.content;
            },
            sortCategory: async function(){
                for(var i=0;i<this.category.length;i++){
                    if(this.category[i].parentId == 0)
                    {
                        this.cat0.push(this.category[i].parentId);
                    }
                    else if(this.category[i].parentId == 1)
                    {
                        this.cat1.push(this.category[i].parentId);
                    }
                    else if(this.category[i].parentId == 2)
                    {
                        this.cat2.push(this.category[i].parentId);
                    }
                    else if(this.category[i].parentId == 3)
                    {
                        this.cat3.push(this.category[i].parentId);
                    }
                    else
                    {
                        this.cat4.push(this.category[i].parentId);
                    }
                } 
            },
            sortUser: async function(){
                for(var i=0;i<this.user.content.length;i++){
                    var date = moment(this.user.content[i].first_Login, moment.ISO_8601);
                    
                    switch(date.month()+1) {
                        case 1:
                            this.userjanvier++
                            break;
                        case 2:
                            this.userfevrier++
                            break;
                        case 3:
                            this.usermars++
                            break;
                        case 4:
                            this.useravril++
                            break;
                        case 5:
                            this.usermai++
                            break;
                        case 6:
                            this.userjuin++
                            break;
                        case 7:
                            this.userjuillet++
                            break;
                        case 8:
                            this.useraout++
                            break;
                        case 9:
                            this.userseptembre++
                            break;
                        case 10:
                            this.useroctobre++
                            break;
                        case 11:
                            this.usernovembre++
                            break;
                        case 12:
                            this.userdecembre++
                            break;
                    }
                } 
            },
            sortVente: async function(){
                for(var i=0;i<this.sales.length;i++){
                    var date = moment(this.sales[i].sales_date, moment.ISO_8601);
                    
                    switch(date.month()+1) {
                        case 1:
                            this.vente.janvier++
                            break;
                        case 2:
                            this.vente.fevrier++
                            break;
                        case 3:
                            this.vente.mars++
                            break;
                        case 4:
                            this.vente.avril++
                            break;
                        case 5:
                            this.vente.mai++
                            break;
                        case 6:
                            this.vente.juin++
                            break;
                        case 7:
                            this.vente.juillet++
                            break;
                        case 8:
                            this.vente.aout++
                            break;
                        case 9:
                            this.vente.septembre++
                            break;
                        case 10:
                            this.vente.octobre++
                            break;
                        case 11:
                            this.vente.novembre++
                            break;
                        case 12:
                            this.vente.decembre++
                            break;
                    }
                } 
            },
            graphBar() {
                var ctx = this.$el.querySelector(".graphBar");

                var myChart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: ["Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin","Juillet","Aout","Septembre","Octobre","Novembre","Decembre"],
                        datasets: [{
                            data: [this.userjanvier, this.userfevrier,this.usermars, this.useravril, this.usermai, this.userjuin,this.userjuillet,this.useraout,this.userseptembre,this.useroctobre,this.usernovembre,this.userdecembre],
                            backgroundColor: [
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)',
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)'
                            ],
                            borderColor: [
                                'rgba(255,99,132,1)',
                                'rgba(54, 162, 235, 1)',
                                'rgba(255, 206, 86, 1)',
                                'rgba(75, 192, 192, 1)',
                                'rgba(153, 102, 255, 1)',
                                'rgba(255, 159, 64, 1)',
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)'
                            ],
                            borderWidth: 1
                        }]
                    },
                    options: {
                        legend: {
                            display: false,
                        },
                        scales: {
                            yAxes: [{
                                ticks: {
                                    beginAtZero:true
                                }
                            }]
                        }
                    }
                });

            },
            graphLine(){
                var ctx = this.$el.querySelector(".line");
                var myLineChart = new Chart(ctx, {
                    type: 'line',
                    data: {
                        labels: ["Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin","Juillet","Aout","Septembre","Octobre","Novembre","Decembre"],
                        datasets: [{
                            data: [this.vente.janvier, this.vente.fevrier,this.vente.mars, this.vente.avril, this.vente.mai, this.vente.juin,this.vente.juillet,this.vente.aout,this.vente.septembre,this.vente.octobre,this.vente.novembre,this.vente.decembre],
                            pointBackgroundColor:[
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)',
                                'rgba(255, 99, 132, 0.2)',
                                'rgba(54, 162, 235, 0.2)',
                                'rgba(255, 206, 86, 0.2)',
                                'rgba(75, 192, 192, 0.2)',
                                'rgba(153, 102, 255, 0.2)',
                                'rgba(255, 159, 64, 0.2)'
                            ],
                            fill : false,
                            borderColor : 'rgba(215, 220, 44, 0.9)',
                            pointStyle:'triangle'
                        }]
                    },
                    options: {
                        legend: {
                            display: false,
                        }
                    }
                });
            },
            graphDognut(){
                var ctx = this.$el.querySelector(".dognut");
                var myDoughnutChart = new Chart(ctx, {
                    type: 'doughnut',
                    data: {
                        labels: ['Téléphone', 'High-Tech et Informatique','Sports et Loisirs','Vêtements, Chaussures, Bijoux'],
                        datasets: [{
                            data: [this.cat1.length, this.cat2.length, this.cat3.length,this.cat4.length],
                            backgroundColor: ['rgba(215, 220, 44, 0.9)','rgba(215, 22, 44, 0.9)','rgba(88, 162, 5, 0.9)','#483D8B']
                        }]
                    },
                    options: {}
                });
            }
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