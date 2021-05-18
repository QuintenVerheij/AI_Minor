const get_exercises = (state) => {
    return state.exercises;
}

const get_exercise = (state) => (id) => {
    return state.exercises.find((exercise) => exercise.id === id);
}


export default {
    get_exercises,
    get_exercise
}