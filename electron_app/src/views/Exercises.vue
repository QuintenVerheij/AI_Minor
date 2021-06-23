<template>
    <b-container fluid class="text-left">
        <h2 class="font-weight-bold mt-3 " >Jouw oefeningen</h2>
        <home-exercise-list class="mt-2"/>
    </b-container>
</template>
<script>
import HomeExerciseList from '../components/HomeExerciseList.vue';

export default {
    components: {
        HomeExerciseList
    }
}
</script>