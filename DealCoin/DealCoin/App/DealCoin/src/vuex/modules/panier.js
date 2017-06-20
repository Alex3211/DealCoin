import { INCREMENT } from '../mutation-types'
import { DECREMENT } from '../mutation-types'
import { ADDARTICLE } from '../mutation-types'
import { DELLARTICLE } from '../mutation-types'

const state = {
  count: 0,
  list:[]
}

const mutations = {
    [INCREMENT](state, count) {
        state.count++
    },
    [DECREMENT](state) {
        state.count--
    },
    [ADDARTICLE](state, List) {
        state.list.push(List)
    },
    [DELLARTICLE](state, index) {
        state.list.splice(index,1)
    }
}

//const getCount = state => state.panier.count

export default {
  state,
  mutations
}
