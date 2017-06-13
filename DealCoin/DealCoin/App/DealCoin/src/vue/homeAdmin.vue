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
            <div class="col-md-3">
                <canvas class="graphBar"></canvas>
            </div>
            <div class="col-md-3">
                <canvas class="line"></canvas>
            </div>
            <div class="col-md-3">
                <canvas class="pie"></canvas>
            </div>
            <div class="col-md-3">
                <canvas class="dognut"></canvas>
            </div>
            <canvas class="polar"></canvas>
        </div>
    </div>
</div>

</template>

<script>
import AuthService from '../services/AuthService'
import UserService from '../services/UserService'
import ArticleServices from '../services/ArticleServices.js'
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
            }
        },
       async mounted() {
           await this.loadArticle();
           await this.loadUser();
           await this.sortArticle();
           await this.sortUser();
            this.graphBar();
            this.graphLine();
            this.graphPie();
            this.graphDognut();
            this.graphPolar();
            
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
            sortArticle: async function(){
                for(var i=0;i<this.article.length;i++){
                    if(this.article[i].categoriesId == 1)
                    {
                        this.cat1.push(this.article[i].categoriesId);
                    }
                    else if(this.article[i].categoriesId == 2)
                    {
                        this.cat2.push(this.article[i].categoriesId);
                    }
                    else if(this.article[i].categoriesId == 3)
                    {
                        this.cat3.push(this.article[i].categoriesId);
                    }
                    else
                    {
                        this.cat4.push(this.article[i].categoriesId);
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
            graphBar() {
                var ctx = this.$el.querySelector(".graphBar");

                var myChart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: ["Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin","Juillet","Aout","Septembre","Octobre","Novembre","Decembre"],
                        datasets: [{
                            label: 'Nombre Crétion User/Mois',
                            data: [this.userjanvier, this.userfevrier,this.usermars, this.useravril, this.usermai, this.userjuin,this.userjuillet,this.useraout,this.userseptembre,this.useroctobre,this.usernovembre,this.userdecembre],
                            backgroundColor: [
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
                                'rgba(255, 159, 64, 1)'
                            ],
                            borderWidth: 1
                        }]
                    },
                    options: {
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
                        labels: [10, 100, 1000, 10000, 100000, 1000000],
                        datasets: [{
                            label: 'Nb des Votes',
                            data: [10, 20, 30, 1000, 50, 60],
                            pointBackgroundColor:[
                                'rgba(255,99,132,1)'
                            ],
                            fill : false,
                            borderColor : 'rgba(215, 220, 44, 0.9)',
                            pointStyle:'triangle'
                        }]
                    },
                    options: {}
                });
            },
            graphPie(){
                var ctx = this.$el.querySelector(".pie");
                var myPieChart = new Chart(ctx,{
                    type: 'pie',
                    data: {
                        labels: ['Jeux', 'Vetement','Technologie'],
                        datasets: [{
                            data: [20, 50, 30],
                            backgroundColor: ['rgba(215, 220, 44, 0.9)','rgba(215, 22, 44, 0.9)','rgba(88, 162, 5, 0.9)']
                        }]
                    },
                    options: {}
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
            },
            graphPolar(){
                var ctx = this.$el.querySelector(".polar");
                var myPolarChart = new Chart(ctx, {
                    type: 'polarArea',
                    data: {
                        labels: ['Jeux', 'Vetement','Technologie'],
                        datasets: [{
                            data: [20, 50, 30],
                            backgroundColor: ['rgba(215, 220, 44, 0.9)','rgba(215, 22, 44, 0.9)','rgba(88, 162, 5, 0.9)']
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