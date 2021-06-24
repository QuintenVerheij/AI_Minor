<script>
import { Bar } from "vue-chartjs";
import moment from 'moment'

export default {
  extends: Bar,
  props: {
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
    let days = [];
    let daysRequired = 7

    for (let i = daysRequired; i >= 1; i--) {
    days.push( moment().subtract(i-1, 'days').format('MMM Do') )
    }
     console.log(days)
     
    const {
      borderColor,
      pointBorderColor,
      pointBackgroundColor,
      backgroundColor
    } = this.chartColors;

    this.finishdates = this.value.map(el => el.finishDate)

    this.renderChart(
      {
        labels: [days[6],days[5],days[4],days[3],days[2],days[1],days[0]],
        datasets: [
          {
            label: 'test',
            //data: [this.ce.logs.length],
            data: [this.value.length],
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
