import Vue from 'vue'
import Vuex from 'vuex'

import * as actions from './actions'
import * as getters from './getters'

import app from './modules/app'
import panier from './modules/panier'
import User from './modules/User'
import Statut from './modules/Statut'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

export default new Vuex.Store({
  actions,
  getters,
  modules: {
      app,
      panier,
      User,
      Statut
  },
  strict: debug
})