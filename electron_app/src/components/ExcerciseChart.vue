<script>
import { Bar } from "vue-chartjs";

export default {
  extends: Bar,
  props: {
    ce: Object,
    label: {
      type: String
    },
    chartData: {
      type: Array
    },
    options: {
      type: Object
    },
    chartColors: {
      type: Object
    }
  },
  data() {
    return {
      finishdates : {}
    }
  },
  mounted() {
    this.finishdates = this.$props.ce.logs.map(el => el.finishDate)

    const {
      borderColor,
      pointBorderColor,
      pointBackgroundColor,
      backgroundColor
    } = this.chartColors;

    this.renderChart(
      {
        labels: ["MA","DI","WO","DO","VR","ZA","ZO"],
        datasets: [
          {
            label: 'test',
            data: [this.ce.logs.length],
            borderColor: borderColor,
            pointBorderColor: pointBorderColor,
            pointBackgroundColor: pointBackgroundColor,
            backgroundColor: backgroundColor
          }
        ]
      },
      this.options
    );
  }
};
</script>
