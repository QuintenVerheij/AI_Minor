<template>
     <b-card
    :title="exercise.title"
    :img-src="exercise.image_url"
    img-alt="Image"
    img-top
    tag="article"
    style="max-width: 20rem;"
    class="mb-2"
  >
    <b-card-text>
      {{exercise.text}}
    </b-card-text>

    <b-button @click=goToExercise variant="primary">Go somewhere</b-button>
  </b-card>
</template>
<script>
export default {
    props: {
        exercise: Object
    },
    methods: {
        goToExercise(){
            this.$router.push({name: 'Exercise', params: {
                id: this.exercise.id
            } })
        }
    }
    
}
</script>