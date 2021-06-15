<template>
  <div>
    <!-- <div id="video_box" class="center">
      <div class="rounded video_overlay">
        <div>
          <img
            src="@/assets/left.png"
            class="video_overlay_icon"
            @click="$router.go(-1)"
          />
          <p class="video_overlay_title">AI MINOR FYSIO APP</p>
        </div>
        <br />
        <p class="video_overlay_text">
          Logged in as {{ user !== undefined ? user : "none" }}
        </p>
        <br />
        <p class="video_overlay_text">
          Current Exercise {{ exercise !== undefined ? exercise : "none" }}
        </p>
        <br />
        <img src="@/assets/calendar.png" class="video_overlay_icon" />
        <img src="@/assets/stopwatch.png" class="video_overlay_icon" />
        <img src="@/assets/phone.png" class="video_overlay_icon" />
      </div>
      <canvas id="canvas" width="1280px" height="720px"></canvas>
      <video
        id="video"
        width="1280px"
        height="720px"
        autoplay
        style="display: none"
      ></video>
    </div> -->
  </div>
</template>

<script>
// import ml5 from "ml5";
// import * as tf from "@tensorflow/tfjs";
// import * as tfn from "@tensorflow/tfjs-node"
// const MODEL_URL = "@/assets/model/model.json";

export default {
  // created() {
  //   this.$store.dispatch("getExercise", this.$route.params.id);
  // },
  // computed: {
  //   user() {
  //     return this.$store.getters["authentication/get_user"];
  //   },
  //   exercise() {
  //     return this.$route.params.id;
  //   },
  // },
  // data() {
  //   return {
  //     // LOCAL STATE GOES HERE
  //     posenet: {},
  //     poses: [],
  //     ourModel: {},
  //     ourModelOutPut: [],
  //     isModelLoaded: false,
  //     video: {},
  //     canvas: {},
  //     ctx: {},
  //   };
  // },
  // mounted: async function () {
  //   this.video = document.getElementById("video");
  //   this.buildCapture();
  //   this.canvas = document.getElementById("canvas");
  //   this.ctx = this.canvas.getContext("2d");
  //   // translate context to center of canvas
  //   this.ctx.translate(this.canvas.width, 0);

  //   // flip context horizontally
  //   this.ctx.scale(-1, 1);
  //   const opt = {
  //     architecture: "MobileNetV1",
  //     imageScaleFactor: 0.3,
  //     outputStride: 16,
  //     flipHorizontal: false,
  //     minConfidence: 0.5,
  //     maxPoseDetections: 5,
  //     scoreThreshold: 0.5,
  //     nmsRadius: 20,
  //     detectionType: "multiple",
  //     inputResolution: 513,
  //     multiplier: 0.75,
  //     quantBytes: 2,
  //   };
  //   this.poseNet = ml5.poseNet(this.video, opt, this.onModelLoaded);
  //   this.poseNet.on("pose", this.gotPoses);
  //   this.ourModel = await tf.loadLayersModel(tfn.io.fileSystem(MODEL_URL));
  //   console.log(this.ourModel);
  //   this.drawCameraIntoCanvas();
  // },
  // beforeUnmount() {
  //   this.video.srcObject.getTracks().forEach(function (track) {
  //     track.stop();
  //     this.video = null;
  //   });
  // },
  // methods: {
  //   onModelLoaded: function () {
  //     this.isModelLoaded = true;
  //   },
  //   gotPoses: function (results) {
  //     this.poses = results;
  //   },
  //   // A function to draw the video and poses into the canvas.
  //   // This function is independent of the result of posenet
  //   // This way the video will not seem slow if poseNet
  //   // is not detecting a position
  //   drawCameraIntoCanvas: function () {
  //     // Draw the video element into the canvas
  //     this.ctx.drawImage(this.video, 0, 0, 1280, 720);
  //     // We can call both functions to draw all keypoints and the skeletons
  //     this.drawKeypoints();
  //     this.drawSkeleton();
  //     window.requestAnimationFrame(this.drawCameraIntoCanvas);
  //   },
  //   // A function to draw ellipses over the detected keypoints
  //   drawKeypoints: function () {
  //     this.ctx.lineWidth = 1;
  //     // Loop through all the poses detected
  //     for (let i = 0; i < this.poses.length; i += 1) {
  //       // For each pose detected, loop through all the keypoints
  //       for (let j = 0; j < this.poses[i].pose.keypoints.length; j += 1) {
  //         let keypoint = this.poses[i].pose.keypoints[j];
  //         // Only draw an ellipse is the pose probability is bigger than 0.2
  //         if (keypoint.score > 0.2) {
  //           this.ctx.beginPath();
  //           this.ctx.arc(
  //             keypoint.position.x,
  //             keypoint.position.y,
  //             10,
  //             0,
  //             2 * Math.PI
  //           );
  //           this.ctx.fillStyle = "#FF3333";
  //           this.ctx.fill();
  //           this.ctx.stroke();
  //         }
  //       }
  //     }
  //   },
  //   // A function to draw the skeletons
  //   drawSkeleton: function () {
  //     this.ctx.lineWidth = 10;
  //     // Loop through all the skeletons detected
  //     for (let i = 0; i < this.poses.length; i += 1) {
  //       // For every skeleton, loop through all body connections
  //       for (let j = 0; j < this.poses[i].skeleton.length; j += 1) {
  //         let partA = this.poses[i].skeleton[j][0];
  //         let partB = this.poses[i].skeleton[j][1];
  //         this.ctx.beginPath();
  //         this.ctx.moveTo(partA.position.x, partA.position.y);
  //         this.ctx.lineTo(partB.position.x, partB.position.y);
  //         this.ctx.stroke();
  //       }
  //     }
  //   },
  //   buildCapture: function () {
  //     console.log(this.video);
  //     navigator.mediaDevices
  //       .enumerateDevices()
  //       .then((devices) => {
  //         devices = devices.filter((v) => v.kind == "videoinput");
  //         console.log("Found " + devices.length + " video devices");
  //         let lastDevice = devices[devices.length - 1];
  //         // devices= devices.filter( v => (v.label.indexOf("back")>0));
  //         let device = null;
  //         if (devices.length > 0) {
  //           console.log("Taking a 'back' camera");
  //           device = devices[0];
  //         } else {
  //           console.log("Taking last camera");
  //           device = lastDevice;
  //         }
  //         if (!device) {
  //           console.log("No devices!");
  //           return;
  //         }
  //         let constraints = {
  //           audio: false,
  //           video: {
  //             deviceId: { ideal: device.deviceId },
  //             width: { ideal: window.innerWidth },
  //             height: { ideal: window.innerHeight },
  //           },
  //         };
  //         console.log(constraints);
  //         navigator.mediaDevices
  //           .getUserMedia(constraints)
  //           .then((stream) => {
  //             try {
  //               this.video.srcObject = stream;
  //             } catch (error) {
  //               this.video.srcObject = URL.createObjectURL(stream);
  //             }
  //             //info.innerHTML+= "<pre>DONE</pre>";
  //             console.log("DONE");
  //             // this.$store.commit("camera/ATTACH_STREAM", this.$el);
  //             this.$store.commit("camera/SET_LOADED", true);
  //           })
  //           .catch((err) => {
  //             console.log(err.name + ": " + err.message);
  //           });
  //       })
  //       .catch((err) => {
  //         console.log(err.name + ": " + err.message);
  //       });
  //   },
  // },
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
  box-shadow: 2px 4px rgba(60, 60, 60, 0.9);
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
  z-index: 101;
}

.video_overlay_title {
  display: inline;
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
  width: 70px;
  height: 70px;
  padding: 10px;
}

.video_overlay_icon:hover {
  background-color: rgba(220, 220, 220, 0.3);
  border-radius: 25%;
}
</style>