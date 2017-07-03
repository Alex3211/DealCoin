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
		<div class="well colorB">
        <h1 class="text-center">Vos messages</h1>
        <div class="list-group" v-for="reports in filteredArticles">
          <div href="#" class=" list-group-item colorC">
                <div class="col-md-12 row" >
                        <label class="col-md-4 control-label">Message de {{reports.email}} : </label>
                        <div class="col-md-8">
                          <p style="word-break:break-all;">{{reports.message}}</p>
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
import ReportService from '../services/ReportServices'
import Chart from 'chart.js';
import Vue from 'vue'
import $ from 'jquery'

import { mapGetters, mapActions } from 'vuex'

export default {
        data() {
            return {
                report:{},
                model: {},
                email: "",
                reports: []
            }
        },
       async mounted() {
            this.loadUser();
            this.email = AuthService.hisEmail();
            await this.loadModelUser(this.email);
        },
        methods: {
            ...mapGetters(['getUser']),
            ...mapActions(['setuser']),
            loadUser: async function(){
                var Report = await ReportService.getAllReportAsync();
                this.report =Report.content;
            },
            loadModelUser: async function(email) {
              var Model2= await UserService.getUserAsync(email);
              this.model=Model2.content;
              //this.model.userId = this.model.content.userId;
            }
        },
        computed : {
            
        filteredArticles: function () {
      var articles_array = this.report,
          searchString = this.searchString;
      if(!searchString){
          return articles_array;
      }
      searchString = searchString.trim().toLowerCase();
      articles_array = articles_array.filter(function(item){
          if(item.title.toLowerCase().indexOf(searchString) !== -1){
              return item;
          }
      })
      // Return an array with the filtered data.
      return articles_array.slice(0,5);
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
list-group-item {
    height:auto;
    min-height:220px;
}
list-group-item.active small {
    color:#fff;
}

.colorB{
    background:#402E22!important;
}

.colorC{
    background:#402E22!important;
    color:white!important;
    border:solid 1px #402E22!important;
}
</style>