<template>
  <!-- <div>
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
          <video :src="ex.exercise.video_url" autoplay/>
        </b-col>
      </b-row>
      <b-btn @click="camera">Start</b-btn>

  </div> -->

  <b-card
    width="100%"
    :img-src="ex.exercise.image_url"
    img-alt="Image"
    img-top
    :shadow="true"
    tag="article"
    style="min-width: 18rem"
    class="mb-2 custom-background border-0"
  >
    <b-card-title>
      <div class="text-center">
        {{ ex.exercise.title }}
      </div>
    </b-card-title>
    <b-card-body>
      <b-row >
        <b-col md=6 class="text-center">
          <p>{{ex.exercise.text}}</p>
        </b-col>
        <b-row><b-col class="text-center" >Repetities compleet:</b-col></b-row>
        <b-row><b-col class="text-center" style="font-size:10em">{{ ex.weeklyRepetitionsCompleted }} / {{ ex.weeklyRepetitions }}</b-col></b-row>
        <b-row><b-col class="text-center" >Repetities per oefening:</b-col></b-row>
        <b-row><b-col class="text-center" style="font-size:10em">{{ ex.reps }}</b-col></b-row>
        <br/>
        {{ ex.logs.finishDate }}
      </b-row>
      <b-row>
        <b-col md="6">
          <video :src="ex.exercise.video_url" autoplay />
        </b-col>
      </b-row>
    </b-card-body>
    <div class="d-flex mx-auto">
      <b-button class="mx-auto" @click="camera" variant="primary"
        >Oefenen</b-button
      >
    </div>
  </b-card>
</template>
<script>
export default {
  created() {
    this.$store.dispatch("exercises/setExerciseId", this.$route.params.id);
  },
  // data() {
  //   return {
  //     cExercise: this.$store.getters['exercises/get_exercise']
  //   }
  // },
  computed: {
    ex() {
      return this.$store.getters["exercises/get_exercise"];
    },
  },
  methods: {
    camera() {
      this.$router.replace({
        name: "Camera",
        params: {id: this.ex.exercise.id },
      });
    },
  },
};
</script>
