const SET_AUTHENTICATED = (state, value) => {
    state.authenticated = value;
}

const SET_USER = (state, value) => {
    state.user = value;
}

const SET_ROLES = (state, value) => {
    state.roles = value
}

export default {
    SET_AUTHENTICATED,
    SET_USER,
    SET_ROLES
}