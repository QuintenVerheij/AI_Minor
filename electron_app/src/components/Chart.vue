<script>
import { Pie } from "vue-chartjs";

export default {
  extends: Pie,
    data: () => ({
    chartdata: {
      labels: ['Voltooid', 'Niet Voltooid'],
      datasets: [
        {
          label: 'Data One',
          backgroundColor: ['#2DCD40', '#CD2D32'],
          data: [40, 20]
        }
      ]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false
    }
  }),

  mounted () {
    this.renderChart(this.chartdata, this.options)
  }
}
</script>