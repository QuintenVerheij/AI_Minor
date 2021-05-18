<template>
  <div>Exercise template
      <h1>{{exercise.title}}</h1>
      <b-row>
        <b-col>
          <b-img :src="exercise.image_url"></b-img>
        </b-col>
        <b-col>
          <p>{{exercise.text}}</p>
        </b-col>
      </b-row>
      <b-btn @click="camera">Start</b-btn>
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
