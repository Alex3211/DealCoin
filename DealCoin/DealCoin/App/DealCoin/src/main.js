import Vue from 'vue'
import VueRouter from 'vue-router'

import App from './App.vue'
import home from './vue/home.vue'
import connexion from './vue/connexion.vue'
import inscription from './vue/inscription.vue'
import apropos from './vue/apropos.vue'
import articles from './vue/articles.vue'
import article from './vue/article.vue'
import articleDetails from './vue/articleDetails.vue'

Vue.use(VueRouter)

/**
 * Filter for routes requiring an authenticated user
 * @param {*} to 
 * @param {*} from 
 * @param {*} next 
 */
/*function requireAuth (to, from, next)  {
  if (!AuthService.isConnected) {
    next({
      path: '/login',
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
*/
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

/**
 * Configuration of the authentication service
 */

// Allowed urls to access the application (if your website is http://mywebsite.com, you have to add it)
//AuthService.allowedOrigins = ['http://localhost:5000', /* 'http://mywebsite.com' */];

// Server-side endpoint to logout
//AuthService.logoutEndpoint = '/Account/LogOff';

// Allowed providers to log in our application, and the corresponding server-side endpoints
/*AuthService.providers = {
  'Base': {
    endpoint: '/Account/Login'
  },
  'Google': {
    endpoint: '/Account/ExternalLogin?provider=Google'
  },
  'GitHub': {
    endpoint: '/Account/ExternalLogin?provider=GitHub'
  },
};

AuthService.appRedirect = () => router.replace('/');*/

// Creation of the root Vue of the application
new Vue({
  el: '#app',
  router,
  render: h => h(App)
})