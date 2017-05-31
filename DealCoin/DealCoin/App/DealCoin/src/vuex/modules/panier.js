import { INCREMENT } from '../mutation-types'

const state = {
  count: 0
}

const mutations = {
    [INCREMENT](state, count) {
        state.count++
    }
}

//const getCount = state => state.panier.count

export default {
  state,
  mutations
}
