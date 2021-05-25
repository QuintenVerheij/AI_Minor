<template>
     <b-card
    :img-src="exercise.image_url"
    img-alt="Image"
    img-top
    tag="article"
    style="max-width: 20rem;"
    class="mb-2"
    >
    <b-card-title>
          <div class="d-flex flex-row">
        {{exercise.title}}
         </div>
    </b-card-title>
    <div class="d-flex flex-row-reverse">
        <b-button @click=goToExercise variant="primary">Oefenen</b-button>
    </div>
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