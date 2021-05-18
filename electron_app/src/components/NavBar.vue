<template>
     <b-navbar toggleable="lg" type="dark" variant="info">
      <slot name="menuActivator"></slot>
      <b-navbar-brand href="#">MinorAI</b-navbar-brand>
      
      <!-- <b-nav-item @click="$router.replace('/')">Signout</b-nav-item> -->
    </b-navbar>
</template>
<script>
export default {
    methods: {
        SignOut(){
            this.$router.replace('/');
        }
    }
}
</script>