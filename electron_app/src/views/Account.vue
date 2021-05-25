<template>
    <b-container>
        <h1>Persoonlijke informatie</h1>
        <b-list-group>
            <b-list-group-item>Voornaam: {{user.first_name}}</b-list-group-item>
            <b-list-group-item>Achternaam: {{user.last_name}}</b-list-group-item>
            <b-list-group-item>Leeftijd: {{user.age}}</b-list-group-item>
        </b-list-group>
    </b-container>
</template>
<script>
export default {
    computed: {
        user(){
            return this.$store.getters['authentication/get_user']
        }
    }
}
</script>