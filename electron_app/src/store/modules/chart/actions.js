
const getChartDataSets = ({commit}) => {
    let datasets =
      {
        chartData: {
          hoverBackgroundColor: "red",
          hoverBorderWidth: 10,
          labels: ["Green", "Red", "Blue"],
          datasets: [
            {
              label: "Data One",
              backgroundColor: ["#41B883", "#E46651", "#00D8FF"],
              data: [1, 10, 5]
            }
          ]
        }
      }
    commit('SET_CHARTDATA', datasets);
}   
export default {
  getChartDataSets
}