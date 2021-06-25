<template>
  <div class="home">
    <div v-if="roles.includes('Client')">
    <b-container fluid class="home text-left">
      <h2>Voortgang voor vandaag</h2>
      <b-row>
        <b-col md="4" v-for="exercise in exercises" v-bind:key="exercise.id">
          <exercise-card :exercise="exercise" />
        </b-col>
      </b-row>

      <h2 class="font-weight-bold mt-3">Oefeningen voor vandaag</h2>
      <home-exercise-list class="mt-2" />
    </b-container>
    </div>
    <div v-if="roles.includes('Therapist')">
      <therapist-home :therapist="therapist"/>
    </div>
  </div>
</template>

<script>
import HomeExerciseList from '../components/HomeExerciseList.vue';
import TherapistHome from '../components/TherapistHome.vue'
// @ is an alias to /src

export default {
  components: { HomeExerciseList, TherapistHome },
  name: 'Home',
  created(){
    this.roles = this.$store.getters['authentication/get_roles'];
    if(this.roles.includes("Therapist")){
      this.$store.dispatch('therapist/getTherapist')
    }
    if(this.roles.includes("Client")){
      this.$store.dispatch('exercises/getExercises');
    }
    // this.$store.dispatch('authentication/getUserInfo');
  },
  data() {
    return {
      roles : []
    }
  },
  computed: {
    exercises(){
       return this.roles.includes("Client") ?  this.$store.getters['exercises/get_exercises'] : null;
    },
    therapist(){
      return this.roles.includes("Therapist") ? this.$store.getters['therapist/get_therapist'] : null;
    }
  }
}
</script>
