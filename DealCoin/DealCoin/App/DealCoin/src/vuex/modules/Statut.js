import { GETSTATUT } from '../mutation-types'

const state = {
  status: 0
}

const mutations = {
    [GETSTATUT](state, status) {
        state.status = status
    }
}

//const getCount = state => state.panier.count

export default {
  state,
  mutations
}