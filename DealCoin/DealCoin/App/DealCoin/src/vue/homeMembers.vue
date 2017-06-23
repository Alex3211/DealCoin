<template>
      <div class="container">
      <img src="../assets/logo.png">
        <div class="row">
            <div class="col-lg-12 text-center">
                <h1>DealCoin</h1>
                <p class="lead">Welcome</p>
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
h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>