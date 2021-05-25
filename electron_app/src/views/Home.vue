<template>
  <b-container fluid class="home text-left">
    <h2 class="font-weight-bold mt-3 " >Oefeningen voor vandaag</h2>
    <home-exercise-list class="mt-2"/>
  </b-container>
</template>

<script>
import HomeExerciseList from '../components/HomeExerciseList.vue';
// @ is an alias to /src

export default {
  components: { HomeExerciseList },
  name: 'Home',
  created(){
    this.$store.dispatch('exercises/getExercises');
  },
  computed: {
    exercises(){
      return this.$store.getters['exercises/get_exercises'];
    }
  }
}
</script>
