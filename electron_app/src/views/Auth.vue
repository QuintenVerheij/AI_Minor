<template>
<div>
  <b-button class="my-auto mx-auto" @click="login">
      Login
  </b-button>
</div>
</template>
<script>
export default {
    methods: {
        login(){
          if(this.$store.dispatch('authentication/debugLogin')) {
            this.$router.push({name: 'Home'});
          }
        }
    }
}
</script>
