<template>
  <div class="container">
    <div class="row mt-5">
      <div class="col">
        <h1 class="text-center">Voortgang Exercise</h1>
      </div>
    </div>

    <div class="row mt-5" v-for="ce in exercises" :key="ce">
      <div class="col" >
        <h2 class="text-center">{{ce.exercise.title}}</h2>
        <excercise-chart 
          :ce="ce"
          :chartData="weeklyRepetitionsCompleted"
          :options="chartOptions"
          :chartColors="positiveChartColors"
          label="Positive"
        />
      </div>
    </div>
  </div>
</template>

<script>
import ExcerciseChart from "../components/ExcerciseChart.vue";

export default {
  components: {
    ExcerciseChart
  },
  computed: {
    user_data(){
      return this.$store.getters["authentication/get_user/"]
    },
    exercises(){
      return this.$store.getters['exercises/get_exercises'];
    },

  },
  data() {
    return {
      weeklyRepetitionsCompleted: [],
      positiveChartColors: {
        borderColor: "#077187",
        pointBorderColor: "#0E1428",
        pointBackgroundColor: "#AFD6AC",
        backgroundColor: "#74A57F"
      },
      chartOptions: {
        responsive: true,
        maintainAspectRatio: false
      }
    };
  },
    created(){
    this.$store.dispatch('authentication/getClientData')
    this.$store.dispatch('exercises/getExercises');
    this.$store.dispatch('authentication/getUserInfo');
    }
};
</script>
