import 'babel-polyfill'
import 'bootstrap/dist/js/bootstrap'
import Vue from 'vue'
import store from './vuex/store'
import VueRouter from 'vue-router'
import $ from 'jquery'

import App from './App.vue'
import home from './vue/home.vue'
import Logout from './vue/Logout.vue'
import apropos from './vue/apropos.vue'
import articles from './vue/articles.vue'
import homeMembers from './vue/homeMembers.vue'
import homeAdmin from './vue/homeAdmin.vue'
import userAdmin from './vue/UserAdmin.vue'
import sellAdmin from './vue/SellAdmin.vue'
import articleAdmin from './vue/ArticleAdmin.vue'
import reportAdmin from './vue/ReportAdmin.vue'
import article from './vue/article.vue'
import MyArticles from './vue/MyArticles.vue'
import articleDetails from './vue/articleDetails.vue'
import InsertArticle from './vue/InsertArticle.vue'
import DelArticle from './vue/DelArticle.vue'
import EditArticle from './vue/EditArticle.vue'
import AuthService from './services/AuthService'
import ArticleServices from './services/ArticleServices'
import UserService from './services/UserService'
import SalesService from './services/SalesService'
import Account from './vue/Account.vue'
import Panier from './vue/Panier.vue'


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
      path: './app',
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
  base: '/Home',
  routes: [
    {
      path: '/',
      name: 'home',
      component: home
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
      path: '/MyArticles',
      name: 'MyArticles',
      component: MyArticles, beforeEnter: requireAuth
    },
    {
      path: '/DelArticle',
      name: 'DelArticle',
      component: DelArticle, beforeEnter: requireAuth
    },
    {
      path: '/InsertArticle',
      name: 'InsertArticle',
      component: InsertArticle, beforeEnter: requireAuth
    },
    {
      path: '/EditArticle',
      name: 'EditArticle',
      component: EditArticle, beforeEnter: requireAuth
    },
    {
      path: '/article',
      name: 'article',
      component: article, beforeEnter: requireAuth
    },
    {
      path: '/Account',
      name: 'Account',
      component: Account,beforeEnter: requireAuth
    },
    {
      path: '/homeMembers',
      name: 'homeMembers',
      component: homeMembers,beforeEnter: requireAuth
    },
    {
      path: '/homeAdmin',
      name: 'homeAdmin',
      component: homeAdmin,beforeEnter: requireAuth
    },
    {
      path: '/userAdmin',
      name: 'userAdmin',
      component: userAdmin,beforeEnter: requireAuth
    },
    {
      path: '/sellAdmin',
      name: 'sellAdmin',
      component: sellAdmin,beforeEnter: requireAuth
    },
    {
      path: '/articleAdmin',
      name: 'articleAdmin',
      component: articleAdmin,beforeEnter: requireAuth
    },
    {
      path: '/reportAdmin',
      name: 'reportAdmin',
      component: reportAdmin,beforeEnter: requireAuth
    },
    {
      path: '/panier',
      name: 'panier',
      component: Panier,beforeEnter: requireAuth
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