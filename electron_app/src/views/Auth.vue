<template>
<div>
  <b-navbar toggleable="lg" type="dark" variant="info">
    <b-navbar-brand href="#">MinorAI</b-navbar-brand>
  </b-navbar>
  <b-button class="my-auto mx-auto" @click="login">
      Login
  </b-button>
</div>
</template>
<script>
export default {
    methods: {
        login(){
          this.$router.replace('/home')
        }
    }
}
</script>
