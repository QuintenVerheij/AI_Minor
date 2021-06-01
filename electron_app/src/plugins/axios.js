import axios from 'axios';
import Vue from 'vue';

export const HTTP = axios.create({
  baseURL: 'https://fysioapi2.azurewebsites.net/'
})

Vue.use(HTTP);