import axios from 'axios';
import Vue from 'vue';

export const HTTP = axios.create({
  baseURL: '',
})

Vue.use(HTTP);