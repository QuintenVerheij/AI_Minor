const get_exercises = (state) => {
    return state.exercises;
}

const get_exercise = (state) => {
    return state.exercise;
}

const get_pose_names = (state) => {
    return state.posenames;
}


export default {
    get_exercises,
    get_exercise,
    get_pose_names
}