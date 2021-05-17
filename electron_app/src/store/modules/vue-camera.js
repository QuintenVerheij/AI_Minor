const vueCameraModule = {
    state: () => ({
        loaded: false,
        stream: {}
    }),
    mutations: {
        setLoaded (state, payload) {
            state.loaded = payload
        },
        attachStream(state, payload) {
            state.stream = payload
        }
    },
    actions: {},
    getters: {
        getLoaded: state => {
            return state.loaded;
        },
        getStream: state => {
            return state.stream
        }
    }
}

export default vueCameraModule