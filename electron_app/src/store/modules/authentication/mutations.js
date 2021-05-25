const SET_AUTHENTICATED = (state, value) => {
    state.authenticated = value;
}

const SET_USER = (state, value) => {
    state.user = value;
}

export default {
    SET_AUTHENTICATED,
    SET_USER
}