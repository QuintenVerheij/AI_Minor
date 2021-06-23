import { HTTP } from '@/plugins/axios'


const getExercises =  (context) => {
    // let exercises = [
    //   {
    //     title: 'exercise1',
    //     id: '1',
    //     text: 'Lorum ipsum dolor set amit',
    //     image_url: 'https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/waarom-je-elke-dag-5-minuten-moet-squatten-img900-1539533807.jpg', 
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



export default {
  getExercises,
  setExercise,
  lastWeekResult
}