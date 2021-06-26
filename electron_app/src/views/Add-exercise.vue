<template>
  <body>
    <div>
      <div class="box-center">
        <h1 class="box-title">Maak nieuwe exercise</h1>
        <br/>
        <b-form class="box-form" @submit="onSubmit">
          <b-form-group class="form-field" label="Exercise naam" label-for="name-input">
            <b-form-input id="name-input" type="text" v-model="exercise_out.name" required />
            <span></span>
          </b-form-group>
          <b-form-group class="form-field" label="Exercise Beschrijving" label-for="description-input">
            <b-form-textarea id="desciption-input" type="text" v-model="exercise_out.description" required />
            <span></span>
          </b-form-group>
          <b-form-group class="form-field" label="Exercise Voorbeeldfoto" label-for="photo-input">
            <b-form-file 
              id="photo-input" 
              accept="image/*"
              v-model="photo_file"
              placeholder="Kies een foto of drag en drop er een in dit veld..." 
              drop-placeholder="Drop file hier..." 
              required />
            <span></span>
          </b-form-group>
          <b-form-group class="form-field" label="Exercise Voorbeeldvideo" label-for="video-input">
            <b-form-file 
              id="video-input"
              accept="video/*"
              v-model="video_file"
              placeholder="Kies een video of drag en drop er een in dit veld..." 
              drop-placeholder="Drop file hier..." 
              required />
            <span></span>
          </b-form-group>
          <br/>
          <h4> Kies de poses die achter elkaar voltooid moeten worden om de exercise uit te voeren.</h4>
          <h5> Om meer poses toe te voegen, klik op de +  </h5>
          <b-form-group class="form-field">
             <b-form-select class="form-dropdown" 
              v-for="poseIndex in Array(exercise_out.poses.length > 0 ? exercise_out.poses.length : 1).keys()" 
              v-bind:key="poseIndex" 
              :id="Number.toString(poseIndex)" 
              v-model="exercise_out.poses[poseIndex]" 
              :options="poses" required
              >
                <template #first>
                  <b-form-select-option value="" disabled>-- Kies een pose --</b-form-select-option>
                </template>
              </b-form-select>
              <b-button class="pose-button" @click="addPose"> + </b-button>
              <div style="display: inline" v-if=" exercise_out.poses.length > 1">
              |
              <b-button class="pose-button" @click="removePose"> - </b-button>
              </div>
          </b-form-group>
          <br/>
          <div class="field-login">
            <b-button type="submit" class="button-login">Exercise opslaan</b-button>
          </div>
        </b-form>
      </div>
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
      photo_file: null,
      video_file: null,
      exercise_out: {
        name: "",
        description: "",
        videoLink: "",
        photoLink: "",
        poses: [""],
      },
    };
  },
  computed: {
    poses() {
      return this.$store.getters["exercises/get_pose_names"];
    },
  },
  methods: {
    async onSubmit(event){
      event.preventDefault();
      this.exercise_out.poses = this.exercise_out.poses.filter((value) => {return value != null && value != ""})
      this.exercise_out.photoLink = await this.$store.dispatch("therapist/createMedia", {file: this.photo_file , type:"images"})
      this.exercise_out.videoLink = await this.$store.dispatch("therapist/createMedia", {file: this.video_file , type:"videos"})
      console.log(this.exercise_out)
      await this.$store.dispatch("exercises/addExercise", this.exercise_out)
    },
    addPose(){
      this.exercise_out.poses.push(null)
    },
    removePose(){
      this.exercise_out.poses.pop()
    }
  },
};
</script>

<style scoped>
body {
  margin: 0;
  padding: 0;
  font-family: montserrat;
  /* background-color:lightgrey !important; */
  height: 100vh;
  overflow: hidden;
}
.title {
  text-align: center;
  color: #081f5e;
  padding: 50px;
}

.box-center {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 80%;
  background: white;
  border-radius: 12px;
}

.box-title {
  text-align: center;
  padding: 0 0 20px 0;
  border-bottom: 1px solid #081f5e;
}

.box-form {
  padding: 0 42px;
  box-sizing: border-box;
}

.invalid-feedback {
  margin-bottom: 20px;
}

.box-form .form-field {
  position: relative;
  border-bottom: 2px solid #adadad;
  margin-top: 35px;
  margin-bottom: 10px;
}

.form-field input {
  width: 100%;
  margin-top: 5px;
  padding: 0 5px;
  height: 40px;
  font-size: 16px;
  border: none;
  background: none;
  outline: none;
}

.form-field label {
  position: absolute;
  top: -50%;
  color: #adadad;
  font-size: 16px;
  pointer-events: none;
  transition: 0.5s;
}

.form-field span::before {
  content: "";
  position: absolute;
  top: 70px;
  left: 0;
  width: 0%;
  height: 4px;
  background: #081f5e;
  transition: 0.5s;
}

.form-field input:focus ~ label,
.form-field input:valid ~ label {
  top: -10px;
  color: #081f5e;
  font-size: 16px;
}

.form-field input:focus ~ span::before,
.form-field input:valid ~ span::before {
  width: 100%;
}

.form-dropdown {
  width: 65%;
  display: inline;
  margin-bottom: 5px;
}

.pose-button {
  display: inline;
  margin-right: 2.5%;
  margin-left: 2.5%;
  width: 10%
}

.field-login {
  margin: -5px 0 20px 5px;
}

.button-login {
  width: 100%;
  height: 40px;
  border: 1px solid;
  background: #081f5e;
  border-radius: 25px;
  font-size: 22px;
  color: antiquewhite;
  font-weight: 700;
  outline: none;
  cursor: pointer;
}

.button-login:hover {
  border-color: black;
  transition: 0.5s;
}

.field-signup {
  margin: 30px 0;
  text-align: center;
  font-size: 17px;
  color: #adadad;
}

.field-signup a {
  color: #4646c5;
  text-decoration: none;
  padding-left: 5px;
}

.field-signup a:hover {
  text-decoration: underline;
}

.error-message {
  color: red;
}
</style>
