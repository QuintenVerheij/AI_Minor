import Vuex from "vuex";
import vueCameraModule from './modules/vue-camera'
// import example from "./modules/example_module";


const createStore = () => {
  return new Vuex.Store({
    modules: {
      camera: vueCameraModule
    },
    state: {
      version: '0.1.13'
    }
  });
};

export default createStore;