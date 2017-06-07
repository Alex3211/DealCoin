import { GETUSER } from '../mutation-types'

const state = {
  user:{}
}

const mutations = {
    [GETUSER](state, user) {
        state.user = user
    }
}

//const getCount = state => state.panier.count

export default {
  state,
  mutations
}