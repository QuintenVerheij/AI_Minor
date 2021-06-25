import { HTTP } from '@/plugins/axios'


const getExercises =  (context) => {
    // let exercises = [
    //   {
    //     title: 'exercise1',
    //     id: '1',
    //     text: 'Lorum ipsum dolor set amit',
    //     image_url: 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/waarom-je-elke-dag-5-minuten-moet-squatten-img900-1539533807.jpg',
    //     poses : [POSES GO HERE] 
    //   },
    //   {
    //     title: 'exercise2',
    //     id: '2',
    //     text: 'Lorum ipsum dolor set amit',
    //     image_url: 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/waarom-je-elke-dag-5-minuten-moet-squatten-img900-1539533807.jpg', 
    //   },
    //   {
    //     title: 'exercise3',
    //     id: '3',
    //     text: 'Lorum ipsum dolor set amit',
    //     image_url: 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/waarom-je-elke-dag-5-minuten-moet-squatten-img900-1539533807.jpg', 
    //   }
    // ]
    HTTP.get(context.rootGetters["api/GET_CLIENT_URL"]).then((response) => {
      console.log(response) 
      context.commit('SET_EXERCISES', response.data.clientExercises);
    }
    ).catch((error) => {
      console.log(error)
    });
}
const lastWeekResult =  (context) => {  
  HTTP.get(context.rootGetters["api/GET_PAST_WEEK_EXTENSION"]).then((response) => {
    console.log(response.data)
    context.commit('SET_LAST_WEEK_RESULT', response.data);    
}
).catch((error) => {
  console.log(error)
});
}
const setExercise = (context, id) => {
    context.commit('SET_EXERCISE', id);
}

const getPoseNames = (context) => {
  HTTP.get(context.rootGetters["api/GET_POSE_NAMES_EXTENSION"]).then((response) => {
    console.log(response)
    context.commit('SET_POSE_NAMES', response.data)
  }
  ).catch((error) => {
    console.log(error)
  });
}

const addExercise = (context, payload) => {
  HTTP.post(context.rootGetters["api/GET_EXERCISE_ADD_EXTENSION"], payload).then((response) => {
    console.log(response)

  }).catch((error) => {
    console.log(error)
  })
}



export default {
  getExercises,
  setExercise,
  getPoseNames,
  addExercise,
  lastWeekResult
}