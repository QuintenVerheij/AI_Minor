import Vuex from "vuex";
import Camera from './modules/camera'
import Authentication from './modules/authentication'
import Exercises from './modules/exercises'
import therapist from './modules/therapist'
import chart from './modules/chart'
import API from './modules/api'
import createPersistedState from 'vuex-persistedstate'
// import example from "./modules/example_module";


const createStore = () => {
  return new Vuex.Store({
    plugins: [createPersistedState({
      storage: window.sessionStorage,
    })],
    modules: {
      camera: Camera,
      authentication: Authentication,
      exercises: Exercises,
      therapist: therapist,
      chart: chart,
      api: API
    },
    state: {
      version: '0.1.15',
      dev: true,
      use_ssl: false
    }
  });
};

export default createStore;