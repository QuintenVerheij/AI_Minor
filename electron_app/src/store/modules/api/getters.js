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

const GET_LOGIN_EXTENSION = (state) => {
        return state.endpoints.auth.login.extension
}

export default {
    GET_API_URL, GET_LOGIN_ENDPOINT, GET_REGISTER_ENDPOINT, GET_LOGIN_EXTENSION
}