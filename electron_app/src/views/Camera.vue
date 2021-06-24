<template>
 <b-overlay :show="!loaded" rounded="sm">
  <b-container fluid>
    <b-progress
      :value="poseIndex"
      :max="exercisePoses.length"
      show-progress
      animated
      variant="success"
    ></b-progress>
    <b-row class="bg-custom">
      <b-col cols="3" class="bg-dark p-0 d">
          <h3 class="text-white py-4">{{formatName(exercise.title)}}</h3>
          <div
            class="w-100 py-3 px-3"
            v-for="(pose, index) in exercisePoses"
            v-bind:class="{ 'bg-custom': index == poseIndex }"
            v-bind:key="index"  
          >
            <h5 class="text-white  text-left">
              <b-icon
                v-if="index < poseIndex"
                class="mr-2"
                icon="check-circle"
                variant="success"
              ></b-icon
              >{{ formatName(pose) }}
            </h5>
          </div>
       
      </b-col>
      <b-col class="pl-0">
        <div>
          <div class="d-inline-block">
            <canvas id="canvas" width="1280px" height="720px"></canvas>
          </div>
          <video
            id="video"
            width="1280px"
            height="720px"
            autoplay
            style="display: none"
          ></video>
        </div>
      </b-col>
      <div v-show="devTools" class="position-absolute top-0 w-40 end-0 bg-gray-transparent p-4 ">
       <div class="w-100 pt-3" v-for="(output, index) in ourModelOutPut" v-bind:key="index">
    <div class="text-left text-white">{{formatName(poseNames[index])}}</div>
    <b-progress
      :value="output"
      :max="1"
      show-progress
      animated
      variant="success"
    ></b-progress>
    </div>
      </div>
    </b-row>
   
  </b-container>
 </b-overlay>
</template>

<script>
import * as poseDetection from "@tensorflow-models/pose-detection";
// Register one of the TF.js backends.
import "@tensorflow/tfjs-backend-webgl";
import * as tensor from "@tensorflow/tfjs";

export default {
  created() {
    this.$store.dispatch('exercises/getExercises');
    this.$store.dispatch('therapist/getPoseNames');
    this.keyInputListener = this.event_listener = window.addEventListener("keydown", (e) => {
      if (e.key == "d") {
        this.toggleDevTools();
        // this.saveData();
      }
    });
  },
  computed: {
    user() {
      return this.$store.getters["authentication/get_user"];
    },
    exercise() {
      let exercises = this.$store.getters["exercises/get_exercises"];
      let index = exercises.findIndex((el) => el.exercise.id == this.$route.params.id);
      if(index > -1){
        return exercises[index].exercise;
      }
      return {}
    },
    poseNames() {
      return this.$store.getters["therapist/get_pose_names"];
    },
    exercisePoses() {
      return this.exercise.poses;
    },
  },
  data() {
    return {
      looping: true,
      posenet: {},
      ourModel: {},
      ourModelOutPut: "",
      isModelLoaded: false,
      updateLoop: {},
      loaded: false,
      video: {},
      canvas: {},
      ctx: {},
      interval: {},
      framecount: 0,
      pose_saved: {},
      poseDetectedIndex: 0,
      poseIndex: 0,
      devTools: false,
      keyInputListener: {}
    };
  },
  async mounted() {
    const detectorConfig = {
      modelType: poseDetection.movenet.modelType.SINGLEPOSE_LIGHTNING,
    };
    this.video = document.getElementById("video");
    await this.buildCapture();
    this.detector = await poseDetection.createDetector(
      poseDetection.SupportedModels.MoveNet,
      detectorConfig
    );
    this.loaded = true;
    this.canvas = document.getElementById("canvas");
    this.ctx = this.canvas.getContext("2d");
    this.ctx.translate(this.canvas.width, 0);
    this.ctx.scale(-1, 1);
    this.ourModel = await tensor.loadLayersModel(
      "https://fysiomodelstorage.z6.web.core.windows.net/model.json"
    );
    this.interval = setInterval(this.recognizePose, 100);
    this.loop();
  },
  beforeDestroy() {
    this.looping = false;
    this.video.srcObject.getTracks().forEach(function(track) {
      track.stop();
      this.video = null;
      clearInterval(this.interval);
    });
    window.removeEventListener(this.keyInputListener);
  },
  methods: {
    toggleDevTools() {
      this.devTools = !this.devTools;
    },
    async takePicture() {
      // let pose = await this.getPoses();
      const prepped_data = await this.$store.dispatch(
        "therapist/prepareData",
        await this.getPoses()
      );
      this.pose_saved = prepped_data;
      this.$bvToast.toast(`saved`, {
        title: `Saved`,
        variant: "success",
        solid: true,
      });
    },
    loop() {
      this.render();
      if(this.looping){
        window.requestAnimationFrame(this.loop);
      }
    },
    renderEstimation(poses) {
      this.drawKeypoints(poses);
      this.drawSkeleton(poses);
    },
    async render() {
      this.ctx.drawImage(this.video, 0, 0, 1280, 720);
      this.renderEstimation(await this.getPoses());
    },
    onModelLoaded() {
      this.isModelLoaded = true;
    },
    async getPoses() {
      return await this.detector.estimatePoses(this.video);
    },
    async recognizePose() {
      const prepped_data = await this.$store.dispatch(
        "therapist/prepareData",
        await this.getPoses()
      );
      // console.log("data", prepped_data);

      tensor.scalar.tr;
      const output = await this.ourModel.predict(
        tensor.tensor(prepped_data, [1, 30])
      );
      // // console.log(output);
      this.ourModelOutPut = (await output.array())[0];
      // // console.log(this.ourModelOutPut);
      // console.log(this.poseNames[this.poseDetectedIndex], " score: ", this.ourModelOutPut[this.poseDetectedIndex]);
      this.poseDetectedIndex = this.ourModelOutPut.reduce(
        (iMax, x, i, arr) => (x > arr[iMax] ? i : iMax),
        0
      );
      // console.log(this.exercise);
      // console.log(
      //   "detected: " + this.poseNames[this.poseDetectedIndex],
      //   "  wanted: " + this.exercise.poses[this.poseIndex]
      // );
      if (
        this.poseNames[this.poseDetectedIndex] ===
        this.exercise.poses[this.poseIndex] && this.ourModelOutPut[this.poseDetectedIndex] > 0.5
      ) {
        this.makeToast(
          "voltooid!",
          this.exercise.poses[this.poseIndex],
          "warning"
        );
        this.poseIndex++;
      }
      if (this.poseIndex === this.exercise.poses.length) {
        this.makeToast("Exercise voltooid!", "Voltooid", "success");
        this.poseIndex = 0;
      }
    },
    // A function to draw ellipses over the detected keypoints
    drawKeypoints(poses) {
      // // console.log(this.poses)
      this.ctx.lineWidth = 1;
      // Loop through all the poses detected
      for (let i = 0; i < poses.length; i += 1) {
        // For each pose detected, loop through all the keypoints
        for (let j = 0; j < poses[i].keypoints.length; j += 1) {
          let keypoint = poses[i].keypoints[j];
          // Only draw an ellipse is the pose probability is bigger than 0.2
          if (keypoint.score > 0.2) {
            this.ctx.beginPath();
            this.ctx.arc(keypoint.x, keypoint.y, 5, 0, 2 * Math.PI);
            this.ctx.fillStyle = "#e43f6f";
            this.ctx.fill();
            this.ctx.stroke();
            this.ctx.closePath();
          }
        }
      }
    },
    // A function to draw the skeletons
    drawSkeleton(poses) {
      const lines = [
        // {
        //   partA: "nose",
        //   partB: "left_eye",
        // },
        // {
        //   partA: "nose",
        //   partB: "right_eye",
        // },
        // {
        //   partA: "left_ear",
        //   partB: "left_eye",
        // },
        // {
        //   partA: "right_ear",
        //   partB: "right_eye",
        // },
        // {
        //   partA: "right_ear",
        //   partB: "right_eye",
        // },
        {
          partA: "left_shoulder",
          partB: "left_elbow",
        },
        {
          partA: "left_elbow",
          partB: "left_wrist",
        },
        {
          partA: "right_shoulder",
          partB: "right_elbow",
        },
        {
          partA: "right_wrist",
          partB: "right_elbow",
        },
        {
          partA: "right_shoulder",
          partB: "left_shoulder",
        },
        {
          partA: "right_shoulder",
          partB: "right_hip",
        },
        {
          partA: "left_shoulder",
          partB: "left_hip",
        },
        {
          partA: "right_hip",
          partB: "left_hip",
        },
        {
          partA: "right_hip",
          partB: "right_knee",
        },
        {
          partA: "right_knee",
          partB: "right_ankle",
        },
        {
          partA: "left_hip",
          partB: "left_knee",
        },
        {
          partA: "left_hip",
          partB: "left_ankle",
        },
      ];
      // // console.log(lines);
      this.ctx.lineWidth = 5;

      // Loop through all the skeletons detected
      poses.forEach((pose) => {
        const keypoints = pose.keypoints;
        lines.forEach((line) => {
          const partA = keypoints.find((kp) => kp.name == line.partA);
          const partB = keypoints.find((kp) => kp.name == line.partB);

          if (partA.score > 0.3 && partB.score > 0.3) {
            this.ctx.strokeStyle ="#e43f6f";
            this.ctx.beginPath();
            this.ctx.moveTo(partA.x, partA.y);
            this.ctx.lineTo(partB.x, partB.y);
            this.ctx.stroke();
            this.ctx.closePath();
          }
        });
      });
    },
    makeToast(text, title, variant) {
      this.$bvToast.toast(`${text}`, {
        title: `${title}`,
        variant: variant,
        solid: true,
      });
    },
    formatName(name){
      return name.replaceAll('_', ' ').toUpperCase();
    },
    buildCapture: function() {
      // // console.log(this.video);
      navigator.mediaDevices
        .enumerateDevices()
        .then((devices) => {
          devices = devices.filter((v) => v.kind == "videoinput");
          // // console.log("Found " + devices.length + " video devices");
          let lastDevice = devices[devices.length - 1];
          // devices= devices.filter( v => (v.label.indexOf("back")>0));
          let device = null;
          if (devices.length > 0) {
            // console.log("Taking a 'back' camera");
            device = devices[0];
          } else {
            // console.log("Taking last camera");
            device = lastDevice;
          }
          if (!device) {
            // console.log("No devices!");
            return;
          }
          let constraints = {
            audio: false,
            video: {
              deviceId: { ideal: device.deviceId },
              width: { ideal: window.innerWidth },
              height: { ideal: window.innerHeight },
            },
          };
          // // console.log(constraints);
          navigator.mediaDevices
            .getUserMedia(constraints)
            .then((stream) => {
              try {
                this.video.srcObject = stream;
              } catch (error) {
                this.video.srcObject = URL.createObjectURL(stream);
              }
              //info.innerHTML+= "<pre>DONE</pre>";
              // console.log("CAMERA LOADED; STREAM ATTACHED");
              // this.$store.commit("camera/ATTACH_STREAM", this.$el);
              this.$store.commit("camera/SET_LOADED", true);
            })
            .catch((err) => {
              console.log(err.name + ": " + err.message);
            });
        })
        .catch((err) => {
          console.log(err.name + ": " + err.message);
        });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

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
.end-0 {
  right:0;
}
.w-40 {
  width: 40%;
}
.video_overlay {
  position: absolute;
  float: left;
  min-height: 20px;
  min-width: 40px;
  /* padding: 5px; */
  margin: 5px;
  border: solid black 1px;
  box-shadow: 1px 2px rgba(60, 60, 60, 0.9);
  z-index: 100;
  background-color: rgba(192, 192, 192, 0.3);
}

.bg-gray-transparent {
   background-color: rgba(0, 0, 0, 0.5);
}
/*     */
.rounded {
  border-radius: 25px;
}
.video_overlay_text {
  display: inline;
  font-size: 30px;
  color: black;
  -webkit-text-stroke: 0.3px white;
  z-index: 101;
}

.video_overlay_title {
  display: inline;
  color: black;
  -webkit-text-stroke: 0.7px white;
  vertical-align: middle;
  font-size: 35px;
  height: 70px;
  padding: 10px;
  margin-top: 10px;
}

.video_overlay_title:hover {
  background-color: rgba(220, 220, 220, 0.3);
}

.video_overlay_icon {
  display: inline;
  background-color: rgba(220, 220, 220, 0.3);
  border-radius: 25%;
  box-shadow: 1px 2px rgba(60, 60, 60, 0.9);
  width: 70px;
  height: 70px;
  padding: 10px;
  margin: 0px 4px;
}

.video_overlay_icon:hover {
  background-color: rgba(240, 240, 240, 0.3);
}
</style>
