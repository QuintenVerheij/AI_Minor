<template>
  <div>Exercise template
      <h1>{{exercise.title}}</h1>
      <p>{{exercise.text}}</p>
      <b-btn @click="camera">Start camera</b-btn>
  </div>
</template>
<script>
export default {
    computed: {
        exercise() {
            return this.$store.getters['exercises/get_exercise'](this.$route.params.id);
        }
    },
  methods: {
    camera() {
      this.$router.replace("/camera");
    },
  },
};
</script>
