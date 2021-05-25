<template>
    <b-container class="text-left">
        <h1>Persoonlijke informatie</h1>
        <b-list-group>
            <b-list-group-item>Voornaam: {{user.first_name}}</b-list-group-item>
            <b-list-group-item>Achternaam: {{user.last_name}}</b-list-group-item>
            <b-list-group-item>Leeftijd: {{user.age}}</b-list-group-item>
        </b-list-group>
        <div v-if="user.trainer != null">
            Trainer: {{user.trainer}}
        </div>
        <div v-else>
            <h1>Trainer code:</h1>
            <b-form-input v-model="code" placeholder="Voer je code in"></b-form-input>
        </div>
    </b-container>
</template>
<script>
export default {
    computed: {
        user(){
            return this.$store.getters['authentication/get_user']
        }
    },
    data(){
        return {
            code: null
        }
    }
}
</script>