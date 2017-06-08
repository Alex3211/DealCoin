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
            <canvas class="myChart" width="150" height="150"></canvas>
            <canvas class="line" width="750" height="750"></canvas>
            <canvas class="pie" width="750" height="750"></canvas>
            <canvas class="dognut" width="750" height="750"></canvas>
            <canvas class="polar" width="750" height="750"></canvas>
        </div>
    </div>
</div>

</template>

<script>
import AuthService from '../services/AuthService'
import UserService from '../services/UserService'
import Chart from 'chart.js';
import Vue from 'vue'
import $ from 'jquery'

import { mapGetters,mapActions } from 'vuex'

export default {
        data() {
            return {
                user:{}
            }
        },
        mounted() {
            this.displayGraph();
            this.graphLine();
            this.graphPie();
            this.graphDognut();
            this.graphPolar();
            this.loadUser();
        },
        methods: {
            ...mapGetters(['getUser']),
            ...mapActions(['setuser']),
            loadUser: async function(){
                var User = await UserService.getAllUserAsync();
                this.user = User;
                this.setuser(User);
            },
            displayGraph() {
                var ctx = this.$el.querySelector(".myChart");
                var myChart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
                        datasets: [{
                            label: 'NB of Votes',
                            data: [12, 19, 3, 5, 2, 3],
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
                        labels: ['Jeux', 'Vetement','Technologie'],
                        datasets: [{
                            data: [20, 50, 30],
                            backgroundColor: ['rgba(215, 220, 44, 0.9)','rgba(215, 22, 44, 0.9)','rgba(88, 162, 5, 0.9)']
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