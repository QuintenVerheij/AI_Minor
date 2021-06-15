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

const login = (context, payload) => {
    return HTTP.post(context.rootGetters["api/GET_LOGIN_EXTENSION"], payload).then((response)=>{
      console.log(response);
      localStorage.token=response.data.token;
      localStorage.userId = response.data.userId;
      HTTP.defaults.headers.common = {
        "Authorization": `Token ${response.data.token}`,
      };
      context.commit('SET_AUTHENTICATED', true);
      return true;
    }
  ).catch(()=>{
    context.commit('SET_AUTHENTICATED', false);
    return false;
  })
}

const getUserInfo = (context) => {
  return HTTP.get(context.rootGetters["api/GET_LOGIN_EXTENSION"]).then((response) => {
    context.commit('SET_USER', response.data);
  })
}

const register = (context, payload) => {
  console.log(
  'endpoint', context.rootGetters["api/GET_REGISTER_ENDPOINT"]);
  return HTTP.post(context.rootGetters["api/GET_REGISTER_ENDPOINT"], payload).then((response)=>{
    console.log(response)
    return true;
  }
).catch((e)=>{
  console.log(e)
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
  getUserInfo,
  debugLogin,
  login,
  register,
  signOut,
  checkAuthenticated
}