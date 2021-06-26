const get_pose_names = (state) => {
    return state.pose_names;
}

const get_therapist = (state) => {
    return state.therapist
}

const get_client_results = (state) => {
    return state.client_results
}

export default {
    get_pose_names,
    get_therapist,
    get_client_results
}