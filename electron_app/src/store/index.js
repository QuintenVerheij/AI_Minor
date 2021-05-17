import Vuex from "vuex";
// import example from "./modules/example_module";


const createStore = () => {
  return new Vuex.Store({
    modules: {
    //   example: example,
    }
  });
};

export default createStore;