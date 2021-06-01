<template>
  <div id="app">
    <navigation-drawer v-show="authenticated"></navigation-drawer>
    <router-view/>
  </div>
</template>
<script>
import NavigationDrawer from './components/NavigationDrawer.vue'
export default {
  components: {
    NavigationDrawer
  },
  created(){
    this.$store.dispatch('authentication/checkAuthenticated');
  },
  computed: {
    authenticated() {
      return this.$store.getters['authentication/get_authenticated'];
    }
  },
  watch: {
    authenticated(){
      if(!this.authenticated){
        this.$router.replace({name: 'Auth'});
      }
    }
  }
}
</script>



<style lang="scss">

// @import './assets/scss/custom.css';
/* @import '../node_modules/bootstrap/dist/css/bootstrap.css';
@import '../node_modules/bootstrap-vue/dist/bootstrap-vue.css'; */
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

body {
  background-color: var(--white);
}
</style>
