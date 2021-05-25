import Vuex from "vuex";
import Camera from './modules/camera'
import Authentication from './modules/authentication'
import Exercises from './modules/exercises'
import therapist from './modules/therapist'
// import example from "./modules/example_module";


const createStore = () => {
  return new Vuex.Store({
    modules: {
      camera: Camera,
      authentication: Authentication,
      exercises: Exercises,
      therapist: therapist
    },
    state: {
      version: '0.1.13'
    }
  });
};

export default createStore;