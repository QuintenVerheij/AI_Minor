export default {
    API_URL :  "https://fysioapi2.azurewebsites.net",
    API_URL_DEV: "http://localhost:49154",
    API_URL_DEV_HTTPS: "https://localhost:49153",
    endpoints: {
        auth: {
            login: {extension: "auth/login", method: "POST"},
            register: {extension: "auth/register", method: "POST"},
            role: {extension: "auth/role", method:"GET"}
        },
        file:{
            model: {extension: "File/Model", method: "GET"}
        },
        statistics: {
            exercise: {extension: "api/client", method: "GET"}
        },
        client: {
            extension: "api/client", method: "GET",
            pastweek : {extension: "api/client/getPastWeekResults", method: "GET"},
            
        },
        exercise: {
            pose_names: {extension: "api/exercise/Poses", method: "GET"},
            add: {extension: "api/exercise/add", method: "POST"},
            get_all : {extension: "api/exercise", method: "GET"}
        },
        therapist: {
            extension: "api/therapist", method: "GET",
            assign_exercise: {extension: "api/therapist/assignexc", method: "POST"},
            upload_file: {extension: "api/therapist/uploadFile", method:"POST"},
            pastweek_from_client: {extension: "api/client/getPastWeekResults", method: "GET"},
            remove_client_exercise: {extension: "/api/therapist", method:"DELETE"},
        },

    }
}