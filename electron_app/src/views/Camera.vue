<template>
  <div>
    <b-navbar toggleable="lg" type="dark" variant="info">
      <b-navbar-brand href="#">MinorAI</b-navbar-brand>
    </b-navbar>
    <div id="video_box" class="center">
      <div class="rounded video_overlay">
        <p class="video_overlay_text">AI MINOR FYSIO APP</p>
        <p class="video_overlay_text">v {{ version }}</p>
      </div>
      <vueCamera> </vueCamera>
    </div>
  </div>
</template>
<script>
import vueCamera from "@/components/vue-camera.vue";
export default {
  components: { vueCamera },
  props: {
    version: String,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
#video_box {
  float: center;
  text-align: center;
  width: fit-content;
  object-fit: cover;
}
.video_overlay {
  position: absolute;
  float: left;
  min-height: 20px;
  min-width: 40px;
  padding: 5px;
  margin: 5px;
  border: solid black 1px;
  box-shadow: 1px 2px rgba(60,60,60, 0.9);
  z-index: 100;
  background-color: rgba(192, 192, 192, 0.3);
}
.center {
  margin: auto;
  width: 50%;
  padding-top: 5px;
}
.rounded {
  border-radius: 25px;
}
.video_overlay_text {
  font-size: 30px;
  z-index: 101;
}
</style>