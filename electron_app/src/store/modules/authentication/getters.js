const get_authenticated = (state) => {
    return state.authenticated;
}

const get_user = (state) => {
    return state.user;
}

const get_roles = (state) => {
    return state.roles
}

export default {
    get_authenticated,
    get_user,
    get_roles
}