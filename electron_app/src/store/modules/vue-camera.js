const vueCameraModule = {
    state: () => ({
        loaded: false
    }),
    mutations: {
        setLoaded (state, payload) {
            state.loaded = payload
        },
    },
    actions: {},
    getters: {
        getLoaded: state => {
            return state.loaded;
        }
    }
}

export default vueCameraModule