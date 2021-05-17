<template>
  <div class="home">
    <nav-bar />
    <img alt="Vue logo" src="../assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App" :version='version' />
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'
import NavBar from '@/components/NavBar.vue'

export default {
  name: 'Home',
  components: {
    HelloWorld,
    NavBar, 
  },
  version: '0.1.13'
}
</script>
