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
        <canvas class="myChart" width="250" height="250"></canvas>
    </div>
</div>

</template>

<script>
import AuthService from '../services/AuthService'
import UserService from '../services/UserService'
import Chart from 'chart.js';
import Vue from 'vue'
import $ from 'jquery'

export default {
        data() {
            return {
            }
        },
        mounted() {
            this.displayGraph();
        },
        methods: {
            displayGraph() {
                var ctx = this.$el.querySelector(".myChart");
                var myChart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
                        datasets: [{
                            label: '# of Votes',
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