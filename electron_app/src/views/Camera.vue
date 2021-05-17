<template>
<div>
  <b-navbar toggleable="lg" type="dark" variant="info">
    <b-navbar-brand href="#">MinorAI</b-navbar-brand>
  </b-navbar>
  <vueCamera/>
  
</div>
</template>
<script>
import vueCamera from '@/components/vue-camera.vue'
export default {
    components: {vueCamera}
    }
</script>