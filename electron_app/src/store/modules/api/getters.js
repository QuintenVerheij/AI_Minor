const GET_API_URL = (state) => {
        // rootState.dev ? (rootState.use_ssl ? state.API_URL_DEV_HTTPS : state.API_URL_DEV) :
        return  state.API_URL
}

const GET_LOGIN_ENDPOINT = (state, getters, rootState, rootGetters) => {
        return {
                url: GET_API_URL(state, getters, rootState, rootGetters) + "/" + state.endpoints.auth.login.extension, 
                method: state.endpoints.auth.login.method,
                headers: {
                        'Content-Type': 'application/json',
                        'accept': '*/*'
                }
        }
}

const GET_REGISTER_ENDPOINT = (state, getters, rootState, rootGetters) => {
        return {
                url: GET_API_URL(state, getters, rootState, rootGetters) + "/" + state.endpoints.auth.register.extension, 
                method: state.endpoints.auth.register.method,
                headers: {
                        'Content-Type': 'application/json',
                        'accept': '*/*'
                }
        }
}

const GET_MODEL_URL = (state, getters, rootState, rootGetters) => GET_API_URL(state, getters, rootState, rootGetters) + "/" + state.endpoints.file.model.extension

const GET_CLIENT_URL = (state) => {
        return state.endpoints.statistics.exercise.extension
}
const GET_LOGIN_EXTENSION = (state) => {
        return state.endpoints.auth.login.extension
}

export default {
    GET_API_URL, GET_LOGIN_ENDPOINT, GET_REGISTER_ENDPOINT, GET_LOGIN_EXTENSION, GET_MODEL_URL, GET_CLIENT_URL
}