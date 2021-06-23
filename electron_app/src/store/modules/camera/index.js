import Vuex from 'vuex';
import Vue from 'vue';

import state from './state';
import actions from './actions';
import getters from './getters';
import mutations from './mutations';

Vue.use(Vuex);

export default {
  namespaced: true, 
  state,
  actions,
  mutations,
  getters,
}