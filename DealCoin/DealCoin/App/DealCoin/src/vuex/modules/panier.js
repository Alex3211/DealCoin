import { INCREMENT } from '../mutation-types'
import { ADDARTICLE } from '../mutation-types'

const state = {
  count: 0,
  list:[]
}

const mutations = {
    [INCREMENT](state, count) {
        state.count++
    },
    [ADDARTICLE](state, List) {
        state.list.push(List)
    }
}

//const getCount = state => state.panier.count

export default {
  state,
  mutations
}
