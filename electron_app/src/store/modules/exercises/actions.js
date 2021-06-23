
const getExercises = ({commit}) => {
    let exercises = [
      {
        title: 'exercise1',
        id: '1',
        text: 'Lorum ipsum dolor set amit',
        image_url: 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/waarom-je-elke-dag-5-minuten-moet-squatten-img900-1539533807.jpg', 
        poses: [
          "front_raise_-30",
          "front_raise_60",
          "squad"
        ]
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

const getExercise = ({commit}) => {
  let exercise = 
    {
      title: 'exercise1',
      id: '1',
      text: 'Lorum ipsum dolor set amit',
      image_url: 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/waarom-je-elke-dag-5-minuten-moet-squatten-img900-1539533807.jpg', 
    };
    commit('SET_EXERCISE', exercise);
}



export default {
  getExercises,
  getExercise
}