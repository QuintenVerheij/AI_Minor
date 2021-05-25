
const getChartDataSets = ({commit}) => {
    let datasets = [
      {
      chartdata: {
        labels: ['Voltooid', 'Niet Voltooid'],
        datasets: [
          {
            label: 'Data One',
            backgroundColor: ['#2DCD40', '#CD2D32'],
            data: [40, 20]
          }
        ]
      }
      }
    ]
    commit('SET_CHARTDATA', datasets);
}   
export default {
  getChartDataSets
}