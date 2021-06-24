<template>
  <body>
    <div>
      <p v-for="pose in poses" v-bind:key="pose">pose</p>
    </div>
  </body>
</template>
<script>
export default {
  created() {
    this.$store.dispatch('exercises/getPoseNames');
  },
  data() {
    return {
      exercise_out: {
        name: "",
        description: "",
        videoLink: "",
        photoLink: "",
        poses: [],
      },
    };
  },
  computed: {
    poses() {
      return this.$store.getters["exercises/get_poses"];
    },
  },
  methods: {},
};
</script>
