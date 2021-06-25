<template>
<div>
    <div class="d-flex flex-row flex-nowrap scroller" >
        <exercise-card class="mr-2" v-for="cExercise in cExercises" :ce="cExercise" v-bind:key="cExercise.id"/>
    </div>
</div>
</template>
<script>
import ExerciseCard from './ExerciseCard.vue';
export default {
  components: { ExerciseCard },
    created(){
    this.roles = this.$store.getters["authentication/get_roles"]
    if(this.roles.includes("Client")){this.$store.dispatch('exercises/getExercises');}
  },
  data() {
      return {
      roles: []
    }
  },
  computed: {
    cExercises(){
      return this.roles.includes("Client") ?  this.$store.getters['exercises/get_exercises'] : null;
    }
  }
}
</script>
<style lang="scss" scoped>

.scroller {
    overflow-x: auto;
}
/* width */
::-webkit-scrollbar {
  width: 5px;
}

/* Track */
::-webkit-scrollbar-track {
  background: #f1f1f1;
  border-radius: 5px; 
}
 
/* Handle */
::-webkit-scrollbar-thumb {
  background: #888; 
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: #555; 
}

</style>