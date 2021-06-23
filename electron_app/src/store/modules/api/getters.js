const GET_API_URL = () => {
        return 'https://fysioapi2.azurewebsites.net'
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

const GET_ROLE_ENDPOINT = (state, getters, rootState, rootGetters) => {
        return {
                url: GET_API_URL(state, getters, rootState, rootGetters) + "/" + state.endpoints.auth.role.extension, 
                method: state.endpoints.auth.role.method,
                headers: {
                        'accept': '*/*'
                }
        }
}

const GET_MODEL_URL = (state, getters, rootState, rootGetters) => GET_API_URL(state, getters, rootState, rootGetters) + "/" + state.endpoints.file.model.extension

const GET_EXERCISE_URL = (state) => {
        return state.endpoints.statistics.exercise.extension
}

const GET_CLIENT_URL = (state, getters, rootState, rootGetters) => GET_API_URL(state, getters, rootState, rootGetters) + "/" + state.endpoints.client.extension

const GET_LOGIN_EXTENSION = (state) => {
        return state.endpoints.auth.login.extension
}

const GET_ROLE_EXTENSION = (state) => {
        return state.endpoints.auth.role.extension
}

export default {
    GET_API_URL, GET_LOGIN_ENDPOINT, GET_REGISTER_ENDPOINT, GET_LOGIN_EXTENSION, GET_MODEL_URL, GET_EXERCISE_URL, GET_CLIENT_URL, GET_ROLE_ENDPOINT, GET_ROLE_EXTENSION
}