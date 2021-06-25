const SET_THERAPIST = (state, value) => {
    state.therapist = value;
}

const SET_DATA = (state, value) => {
    state.data = value;
}

const SET_POSE_NAMES = (state, value) => {
    state.pose_names = value
}

export default {
    SET_DATA,
    SET_POSE_NAMES,
    SET_THERAPIST
}