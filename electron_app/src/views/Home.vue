<template>
  <div class="home">
    <h2>Voortgang voor vandaag</h2>
    <b-row>
      <b-col md=4 v-for="exercise in exercises" v-bind:key="exercise.id">
        <exercise-card :exercise="exercise"/>
      </b-col>
    </b-row>
    <h2>Oefeningen voor vandaag</h2>
    <b-row>
      <b-col md=4 v-for="exercise in exercises" v-bind:key="exercise.id">
        <exercise-card :exercise="exercise"/>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import ExerciseCard from '../components/ExerciseCard.vue';
// @ is an alias to /src

export default {
  components: { ExerciseCard },
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
