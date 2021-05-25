const get_authenticated = (state) => {
    return state.authenticated;
}

//TODO: Get user from server and set it in store
const get_user = (state) => {
    return state.user;
}

export default {
    get_authenticated,
    get_user
}