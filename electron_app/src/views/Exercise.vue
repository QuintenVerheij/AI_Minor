<template>
  <div>
      <h1>{{ex.exercise.title}}</h1>
      <b-row>
        <b-col md=6>
          <b-img :src="ex.exercise.image_url"></b-img>
        </b-col>
        <b-col md=6>
          <p>{{ex.exercise.text}}</p>
        </b-col>
      </b-row>
      <b-row>
        <b-col md=6>
          <video :src="ex.exercise.video_url"/>
        </b-col>
      </b-row>
      <b-btn @click="camera">Start</b-btn>
  </div>
</template>
<script>
export default {
  created(){
    this.$store.dispatch('exercises/setExercise', this.$route.params.id)
  },
  // data() {
  //   return {
  //     cExercise: this.$store.getters['exercises/get_exercise']
  //   }
  // },
  computed: {
      ex: function() {
          return this.$store.getters['exercises/get_exercise'];
      }
  },
  methods: {
    camera() {
      this.$router.replace({name:"Camera", params:{id:this.ex.exercise.id}});
    },
  },
};
</script>
