<template>
     <b-card
     width="400"
    :img-src="ce.exercise.image_url"
    img-alt="Image"
    img-top
    :shadow="true"
    tag="article"
    style="min-width: 18rem; width: 18rem"
    class="mb-2 custom-background border-0"
    >
    <b-card-title>
          <div class="d-flex flex-row font-weight-semi-bold">
        {{ce.exercise.title}}
        {{ce.weeklyRepetitionsCompleted }} / {{ce.weeklyRepetitions}}
        {{ce.logs.finishDate}}
         </div>
    </b-card-title>
    <div class="d-flex flex-row-reverse">
        <b-button @click=goToExercise variant="primary">Oefenen</b-button>
    </div>
  </b-card>
</template>
<script>
export default {
    name:'exercise-card',
    props: {
        ce: Object
    },
    methods: {
        goToExercise(){
            this.$router.push({name: 'Exercise', params: {
                id: this.ce.exercise.id
            } })
        }
    }
}
</script>
<style scoped>
.card-body {
    background-color: white;
    border: 1px solid #f4f4f4;
    border-radius: 5px;
}
</style>