<template>
  <div class="container">
    <div class="row mt-5">
      <div class="col">
        <h1 class="text-center">Voortgang Exercise</h1>
      </div>
    </div>

    <div class="row mt-5" v-for="(value, name) in lastWeekResult" :key="name">
      <div class="col" >
        <h2 class="text-center">{{name}} {{value}}</h2>
        <excercise-chart 
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
  created() {
    this.$store.dispatch('exercises/lastWeekResult')
    this.$store.dispatch('authentication/getClientData')
    this.$store.dispatch('exercises/getExercises');
    this.$store.dispatch('authentication/getUserInfo');
  },
  computed: {
    user_data(){
      return this.$store.getters["authentication/get_user/"]
    },
    exercises(){
      return this.$store.getters['exercises/get_exercises']
    },
    lastWeekResult(){
      return this.$store.getters['exercises/get_last_week_result']
    }
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
  }
};
</script>
