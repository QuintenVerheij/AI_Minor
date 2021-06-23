const SET_EXERCISES = (state, value) => {
    var clientExercises = []
    value.forEach(ce => {
        clientExercises.push({
            'id': ce.clientExerciseId,
            'logs': ce.clientExerciseLogs,
            'exercise': {
                'title': ce.exercise.name,
                'id': ce.exercise.exerciseId,
                'text': ce.exercise.description,
                'image_url': ce.exercise.photoLink,
                'video_url': ce.exercise.videoLink
            },
            'weeklyRepetitions': ce.weeklyRepetitions,
            'weeklyRepetitionsCompleted': ce.weeklyRepetitionsCompleted,
            'score': ce.score,
            'finishingDate':ce.finishingDate
        }
        )
    })
    state.exercises = clientExercises;
}

const SET_EXERCISE = (state, value) => {
    state.exercise = state.exercises.find(ex => ex.exercise.id == value);
}
export default {
    SET_EXERCISES,
    SET_EXERCISE
}