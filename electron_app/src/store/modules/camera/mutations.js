
const SET_LOADED = (state, payload) => {
    state.loaded = payload
}
const ATTACH_STREAM = (state, payload) => {
    state.stream = payload
}


export default {
    SET_LOADED, ATTACH_STREAM
}