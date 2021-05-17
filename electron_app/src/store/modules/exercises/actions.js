
const getExercises = ({commit}) => {
    let exercises = [
      {
        title: 'exercise1',
        id: '1',
        text: 'Lorum ipsum dolor set amit',
        image_url: 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/waarom-je-elke-dag-5-minuten-moet-squatten-img900-1539533807.jpg', 
      },
      {
        title: 'exercise2',
        id: '2',
        text: 'Lorum ipsum dolor set amit',
        image_url: 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/waarom-je-elke-dag-5-minuten-moet-squatten-img900-1539533807.jpg', 
      },
      {
        title: 'exercise3',
        id: '3',
        text: 'Lorum ipsum dolor set amit',
        image_url: 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/waarom-je-elke-dag-5-minuten-moet-squatten-img900-1539533807.jpg', 
      }
    ]
    commit('SET_EXERCISES', exercises);
}   



export default {
  getExercises
}