<template>
    <div>Statistics template
         <Chart :chart="chart" />
    </div>
</template>
<script>
import Chart from '../components/Chart.vue'
export default {
  components: { Chart },
   created() {
    this.$store.dispatch('chart/getChartDataSets')
  },
  computed:{
    chart(){
      return this.$store.getters['chart/get_chartdatasets']
    }
}
}
</script>