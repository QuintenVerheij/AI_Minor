
<script>
import { Pie } from "vue-chartjs";

export default {
  extends: Pie,
  props: ['chart'],
    data: () => ({
    options: {
      responsive: true,
      maintainAspectRatio: false
    }
  }),

  mounted () {
    this.renderChart(this.chart, this.options)
  }
}
</script>