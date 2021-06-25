<script>
import { Bar } from "vue-chartjs";
import moment from "moment";

export default {
  extends: Bar,
  props: {
    label: {
      type: String,
    },
    dataSet: {
      type: Array,
    },
    options: {
      type: Object,
    },
    chartColors: {
      type: Object,
    },
  },
  computed: {
    chartData() {
      let days = [];
      let daysRequired = 7;
      for (let i = daysRequired; i >= 1; i--) {
        days.push(
          moment()
            .subtract(i - 1, "days")
            .format("MMM Do")
        );
      }
      return {
        labels: ["Vandaag", "Gisteren", days[4], days[3], days[2], days[1], days[0]],
        datasets: [
          {
            label: "Voltooide Exercises",
            data: this.dataSet,

            pointBackgroundColor: this.chartColors.pointBackgroundColor,
            backgroundColor: this.chartColors.backgroundColor,
          },
        ],
      };
    },
  },
  mounted() {
    this.renderChart(this.chartData, this.options);
  },
};
</script>
