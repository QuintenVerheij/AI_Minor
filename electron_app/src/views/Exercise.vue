<template>
  <div>
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
  created(){
    this.$store.dispatch('exercises/getExercise', this.$route.params.id)
  },
  computed: {
      exercise() {
          return this.$store.getters['exercises/get_exercise'];
      }
  },
  methods: {
    camera() {
      this.$router.replace("/camera");
    },
  },
};
</script>
