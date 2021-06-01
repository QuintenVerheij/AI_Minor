<template>
  <div>
     <Chart :data="chartData"></Chart>
  </div>
</template>
<script>
import Chart from "../components/Chart.js";
export default {
  components: {
    Chart
  },
   created() {
    this.$store.dispatch('chart/getChartDataSets')
  },
  computed:{
    chartData(){
      return this.$store.getters['chart/get_chartdatasets']
    }
}
};
</script>

