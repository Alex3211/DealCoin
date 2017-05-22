import Vue from 'vue'
import VueRouter from 'vue-router'
import $ from 'jquery'

import App from './App.vue'
import home from './vue/home.vue'
import connexion from './vue/connexion.vue'
import inscription from './vue/inscription.vue'
import apropos from './vue/apropos.vue'
import articles from './vue/articles.vue'
import article from './vue/article.vue'
import articleDetails from './vue/articleDetails.vue'
import AuthService from './services/AuthService.js'

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
      path: '/inscription',
      name: 'inscription',
      component: inscription
    },
    {
      path: '/apropos',
      name: 'apropos',
      component: apropos
    },
    {
      path: '/articles',
      name: 'articles',
      component: articles
    },
    {
      path: '/articleDetails',
      name: 'articleDetails',
      component: articleDetails
    },
    {
      path: '/article',
      name: 'article',
      component: article
    }
  ]
})

AuthService.allowedOrigins = ['http://localhost:5000', /* 'http://Dealcoin.com' */];

// AuthService.logoutEndpoint = '/Account/LogOff';

 AuthService.providers = {
   'Base': {
     endpoint: '/Account/Login'
   },
   'Google': {
     endpoint: '/Account/ExternalLogin?provider=Google'
   }
 };

/* AuthService.appRedirect = () => router.replace('/');*/

new Vue({
  el: '#app',
  router,
  render: h => h(App)
})