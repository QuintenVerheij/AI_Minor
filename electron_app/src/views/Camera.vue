<template>
  <div>
    <div id="video_box" class="center">
      <div class="rounded position-absolute bottom-0 w-auto px-2 py-2 text-left video_overlay">
        
        <h2 class="font-weight-bold fs-1 uppercase">
          {{ exercise !== undefined ? exercise.title : "none" }}
        </h2>
        <br />
        <p class="video_overlay_text">
          Current Pose:
          {{ this.ourModelOutPut !== undefined ? this.ourModelOutPut : "none" }}
        </p>
        <br />
      </div>
      <canvas id="canvas" width="1280px" height="720px"></canvas>
    <video
      id="video"
      width="1280px"
      height="720px"
      autoplay
      style="display: none"
    ></video>
    </div>
  </div>
</template>

<script>
import * as poseDetection from "@tensorflow-models/pose-detection";
// Register one of the TF.js backends.
import "@tensorflow/tfjs-backend-webgl";
import * as tensor from "@tensorflow/tfjs";

export default {
  created() {
    this.$store.dispatch("exercises/getExercises");
  },
  computed: {
    user() {
      return this.$store.getters["authentication/get_user"];
    },
    exercise() {
      return this.$store.getters["exercises/get_exercise"](this.$route.params.id);
    },
  },
  data() {
    return {
      // LOCAL STATE GOES HERE
      posenet: {},
      poses: [],
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
    };
  },
  async mounted () {
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
    // translate context to center of canvas
    this.ctx.translate(this.canvas.width, 0);

    // flip context horizontally
    this.ctx.scale(-1, 1);
    this.updateLoop = setInterval(
      function() {
        this.getPoses();
      }.bind(this),
      12
    );
    console.log(
      "Fetching model from " +
        "https://fysiomodelstorage.z6.web.core.windows.net/model.json"
    );
    this.ourModel = await tensor.loadLayersModel(
      "https://fysiomodelstorage.z6.web.core.windows.net/model.json"
    );
    this.interval = setInterval(
      this.recognizePose, 2000
    );
    console.log(this.ourModel.summary());
    this.drawCameraIntoCanvas();
  },
  beforeUnmount() {
    this.video.srcObject.getTracks().forEach(function (track) {
      track.stop();
      this.video = null;
      clearInterval(this.interval)
    });
  },
  methods: {
    onModelLoaded () {
      this.isModelLoaded = true;
    },
    async getPoses () {
      this.poses = await this.detector.estimatePoses(this.video);
      this.drawCameraIntoCanvas();
    },
    recognizePose: async function () {
      const prepped_data = await this.$store.dispatch(
          "therapist/prepareData",
          this.poses
        );
        console.log("data", prepped_data);

        const output = this.ourModel.predict(tensor.tensor(prepped_data, [1,30]));
        this.ourModelOutPut = output.dataSync();
    },
    // A function to draw the video and poses into the canvas.
    // This function is independent of the result of posenet
    // This way the video will not seem slow if poseNet
    // is not detecting a position
    drawCameraIntoCanvas: function () {
      // Draw the video element into the canvas
      this.ctx.drawImage(this.video, 0, 0, 1280, 720);
      // We can call both functions to draw all keypoints and the skeletons
      this.drawKeypoints();
      this.drawSkeleton();
      window.requestAnimationFrame(this.drawCameraIntoCanvas);
    },
    // A function to draw ellipses over the detected keypoints
    drawKeypoints() {
      // console.log(this.poses)
      this.ctx.lineWidth = 1;
      // Loop through all the poses detected
      for (let i = 0; i < this.poses.length; i += 1) {
        // For each pose detected, loop through all the keypoints
        for (let j = 0; j < this.poses[i].keypoints.length; j += 1) {
          let keypoint = this.poses[i].keypoints[j];
          // Only draw an ellipse is the pose probability is bigger than 0.2
          if (keypoint.score > 0.2) {
            this.ctx.beginPath();
            this.ctx.arc(
              keypoint.x,
              keypoint.y,
              10,
              0,
              2 * Math.PI
            );
            this.ctx.fillStyle = "#FF3333";
            this.ctx.fill();
            this.ctx.stroke();
            this.ctx.closePath();
          }
        }
      }
    },
    // A function to draw the skeletons
    drawSkeleton() {
      const lines = [
        {
          partA: "nose",
          partB: "left_eye",
        },
        {
          partA: "nose",
          partB: "right_eye",
        },
        {
          partA: "left_ear",
          partB: "left_eye",
        },
        {
          partA: "right_ear",
          partB: "right_eye",
        },
        {
          partA: "right_ear",
          partB: "right_eye",
        },
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
      ]
      // console.log(lines);
      this.ctx.lineWidth = 10;
      
      // Loop through all the skeletons detected
      this.poses.forEach((pose)=>{
        const keypoints = pose.keypoints;
        lines.forEach((line)=>{

          const partA = keypoints.find((kp)=>kp.name == line.partA);
          const partB = keypoints.find((kp)=>kp.name == line.partB);
          
          if(partA.score > 0.5 && partB.score > 0.5 ){
            this.ctx.beginPath();
            this.ctx.moveTo(partA.x, partA.y);
            this.ctx.lineTo(partB.x, partB.y);
            this.ctx.stroke();
            this.ctx.closePath();
          }
        })
      })
    },
    buildCapture: function () {
      console.log(this.video);
      navigator.mediaDevices
        .enumerateDevices()
        .then((devices) => {
          devices = devices.filter((v) => v.kind == "videoinput");
          console.log("Found " + devices.length + " video devices");
          let lastDevice = devices[devices.length - 1];
          // devices= devices.filter( v => (v.label.indexOf("back")>0));
          let device = null;
          if (devices.length > 0) {
            console.log("Taking a 'back' camera");
            device = devices[0];
          } else {
            console.log("Taking last camera");
            device = lastDevice;
          }
          if (!device) {
            console.log("No devices!");
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
          console.log(constraints);
          navigator.mediaDevices
            .getUserMedia(constraints)
            .then((stream) => {
              try {
                this.video.srcObject = stream;
              } catch (error) {
                this.video.srcObject = URL.createObjectURL(stream);
              }
              //info.innerHTML+= "<pre>DONE</pre>";
              console.log("CAMERA LOADED; STREAM ATTACHED");
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
  box-shadow: 1px 2px rgba(60, 60, 60, 0.9);
  z-index: 100;
  background-color: rgba(192, 192, 192, 0.3);
}
.center {
  margin: auto;
  width: 80%;
  padding-top: 5px;
}
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