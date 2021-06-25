const get_exercises = (state) => {
    return state.exercises;
}

const get_exercise = (state) => {
    return state.exercise;
}

const get_pose_names = (state) => {
    return state.posenames;
}
const get_last_week_result = (state) => {
    return state.lastweekresult
}


export default {
    get_exercises,
    get_exercise,
    get_pose_names,
    get_last_week_result
}