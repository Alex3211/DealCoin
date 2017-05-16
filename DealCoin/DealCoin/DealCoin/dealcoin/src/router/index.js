import Vue from 'vue'
import Router from 'vue-router'
import home from '@/components/home'
import connexion from '@/components/connexion'
import inscription from '@/components/inscription'
import apropos from '@/components/apropos'

Vue.use(Router)

export default new Router({
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
    }
  ]
})
