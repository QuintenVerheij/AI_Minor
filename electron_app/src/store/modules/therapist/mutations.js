const SET_THERAPIST = (state, value) => {
    state.therapist = value;
}

const SET_DATA = (state, value) => {
    state.data = value;
}

const SET_POSE_NAMES = (state, value) => {
    state.pose_names = value
}

const SET_CLIENT_RESULTS = (state, value) => {
    state.client_results = value
}

export default {
    SET_DATA,
    SET_POSE_NAMES,
    SET_THERAPIST,
    SET_CLIENT_RESULTS
}