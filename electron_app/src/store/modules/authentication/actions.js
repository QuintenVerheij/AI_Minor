import { HTTP } from '@/plugins/axios'

const debugLogin = ({commit}) => {
    localStorage.token='token';
    commit('SET_AUTHENTICATED', true);
    commit('SET_USER', {
      first_name: "Eduard",
      last_name: "Terlouw",
      gender: "male",
      age: 21
  });
   
}   

const login = ({commit}, payload) => {
    return HTTP.post('/api/token/', payload).then((response)=>{
      localStorage.token=response.data.access;
      localStorage.refresh=response.data.refresh;
      commit('SET_AUTHENTICATED', true);
      return true;
    }
  ).catch(()=>{
    commit('SET_AUTHENTICATED', false);
    return false;
  })
}

const signOut = ({commit}) => {
  if(localStorage.token){
    localStorage.removeItem('token');
    commit('SET_AUTHENTICATED', false);
  }
}

const checkAuthenticated = ({commit}) => {
  if(localStorage.token){
    commit('SET_AUTHENTICATED', true);
  }
}

export default {
  debugLogin,
  login,
  signOut,
  checkAuthenticated
}