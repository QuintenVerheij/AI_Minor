import axios from 'axios';
import Vue from 'vue';

export let HTTP = axios.create({
  baseURL: 'https://fysio.azurewebsites.net/'
})

HTTP.interceptors.request.use(function (config) {
  const token = localStorage.getItem('token');
  // console.log(token)
  config.headers.common['Authorization'] =  token ? `Bearer ${token}` : '';
  return config;
});

Vue.use(HTTP);