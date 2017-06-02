import 'babel-polyfill'
import Vue from 'vue'
import store from './vuex/store'
import VueRouter from 'vue-router'
import $ from 'jquery'

import App from './App.vue'
import home from './vue/home.vue'
import connexion from './vue/connexion.vue'
import Logout from './vue/Logout.vue'
import apropos from './vue/apropos.vue'
import articles from './vue/articles.vue'
import homeMembers from './vue/homeMembers.vue'
import article from './vue/article.vue'
import articleDetails from './vue/articleDetails.vue'
import AuthService from './services/AuthService'
import ArticleServices from './services/ArticleServices'
import Increment from './vue/Increment.vue'

Vue.use(VueRouter)

/**
 * Filter for routes requiring an authenticated user
 * @param {*} to 
 * @param {*} from 
 * @param {*} next 
 */
function requireAuth (to, from, next)  {
  if (!AuthService.isConnected) {
    next({
      path: '/connexion',
      query: { redirect: to.fullPath }
    });

    return;
  }

  var requiredProviders = to.meta.requiredProviders;

  if(requiredProviders && !AuthService.isBoundToProvider(requiredProviders)) {
    next( false )
  };

  next();
}

/**
 * Declaration of the different routes of our application, and the corresponding components
 */
const router = new VueRouter({
  mode: 'history',
  base: '/',
  routes: [
    {
      path: '/',
      name: 'home',
      component: home
    },
    {
      path: '/connexion',
      name: 'connexion',
      component: connexion
    },
    {
      path: '/logout',
      name: 'Logout',
      component: Logout
    },
    {
      path: '/apropos',
      name: 'apropos',
      component: apropos
    },
    {
      path: '/articles',
      name: 'articles',
      component: articles, beforeEnter: requireAuth
    },
    {
      path: '/articleDetails',
      name: 'articleDetails',
      component: articleDetails, beforeEnter: requireAuth
    },
    {
      path: '/article',
      name: 'article',
      component: article, beforeEnter: requireAuth
    },
    {
      path: '/Increment',
      name: 'Increment',
      component: Increment, beforeEnter: requireAuth
    },
    {
      path: '/homeMembers',
      name: 'homeMembers',
      component: homeMembers,beforeEnter: requireAuth
    }
  ]
})

AuthService.allowedOrigins = ['http://localhost:5000', /* 'http://Dealcoin.com' */];

AuthService.logoutEndpoint = '/Account/LogOff';

 AuthService.providers = {
   'Base': {
     endpoint: '/Account/Login'
   },
   'Google': {
     endpoint: '/Account/ExternalLogin?provider=Google'
   }
 };

AuthService.appRedirect = () => router.replace('/');

new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})