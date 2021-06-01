<template>
  <div>
    <div id="video_box" class="center">
      <div class="rounded video_overlay">
        <p class="video_overlay_text">AI MINOR FYSIO APP</p>
        <br />
        <p class="video_overlay_text">
          Logged in as {{ user !== undefined ? user : "none" }}
        </p>
        <p class="video_overlay_text">
          Current Exercise {{ exercise !== undefined ? exercise : "none" }}
        </p>
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
        style="display:none"
      ></video>
    </div>
    <div>
      <b-row>
        <b-col>
          <canvas id="imageCanvas" width="1280px" height="720px"></canvas>
        </b-col>
        <b-col>
          <p>{{ this.pose }}</p>
        </b-col>
      </b-row>
      <b-form-checkbox v-model="target" name="check-button" switch>
        Switch target <b>(pose is goed: {{ target }})</b>
      </b-form-checkbox>
    </div>
  </div>
</template>

<script>
import ml5 from "ml5";

export default {
  props: {
    user: String,
    exercise: String,
  },
  created() {
    window.addEventListener("keydown", (e) => {
      if (e.key == "p") {
        this.takePicture();
      }
    });
    window.addEventListener("keydown", (e) => {
      if (e.key == "s") {
        this.saveData();
      }
    });
  },
  
  data() {
    return {
      // LOCAL STATE GOES HERE
      showPicture: false,
      image: null,
      target: false,
      pose: [],
      posenet: {},
      poses: [],
      isModelLoaded: false,
      video: {},
      canvas: {},
      image_canvas: null,
      image_ctx: {},
      ctx: {},
    };
  },
  mounted() {
    this.picture = null;
    this.video = document.getElementById("video");
    this.buildCapture();
    this.canvas = document.getElementById("canvas");
    this.ctx = this.canvas.getContext("2d");
    this.image_canvas = document.getElementById("imageCanvas");
    this.image_ctx = this.image_canvas.getContext("2d");
    console.log(this.image_canvas);

    this.poseNet = ml5.poseNet(this.video, this.onModelLoaded);
    this.poseNet.on("pose", this.gotPoses);
    this.drawCameraIntoCanvas();
  },
  beforeDestroy() {
    navigator.mediaDevices.getUserMedia({audio: false, video: true})
  .then(mediaStream => {
    let tracks=  mediaStream.getTracks()
    tracks.forEach((track)=>{
      track.stop();
    })

})
  },
 
  methods: {
    takePicture() {
      console.log("hello");
      this.pose = [...this.poses];

      //copy canvas by DataUrl
      let sourceImageData = this.canvas.toDataURL("image/png");
      let destinationContext = this.image_canvas.getContext("2d");
      let destinationImage = new Image();
      destinationImage.onload = function() {
        destinationContext.drawImage(destinationImage, 0, 0);
      };
      destinationImage.src = sourceImageData;
    },
    saveData() {
      this.$store.dispatch("therapist/saveData", this.pose);
    },
    onModelLoaded() {
      console.log("PoseNet Model has Loaded");
      this.isModelLoaded = true;
    },
    gotPoses(results) {
      this.poses = results;
    },
    // A function to draw the video and poses into the canvas.
    // This function is independent of the result of posenet
    // This way the video will not seem slow if poseNet
    // is not detecting a position
    drawCameraIntoCanvas: function() {
      // Draw the video element into the canvas
      this.ctx.drawImage(this.video, 0, 0, 1280, 720);
      // We can call both functions to draw all keypoints and the skeletons
      this.drawKeypoints();
      this.drawSkeleton();
      window.requestAnimationFrame(this.drawCameraIntoCanvas);
    },
    // A function to draw ellipses over the detected keypoints
    drawKeypoints: function() {
      this.ctx.lineWidth = 1;
      // Loop through all the poses detected
      for (let i = 0; i < this.poses.length; i += 1) {
        // For each pose detected, loop through all the keypoints
        for (let j = 0; j < this.poses[i].pose.keypoints.length; j += 1) {
          let keypoint = this.poses[i].pose.keypoints[j];
          // Only draw an ellipse is the pose probability is bigger than 0.2
          if (keypoint.score > 0.2) {
            this.ctx.beginPath();
            this.ctx.arc(
              keypoint.position.x,
              keypoint.position.y,
              10,
              0,
              2 * Math.PI
            );
            this.ctx.fillStyle = "#FF3333";
            this.ctx.fill();
            this.ctx.stroke();
          }
        }
      }
    },
    // A function to draw the skeletons
    drawSkeleton: function() {
      this.ctx.lineWidth = 10;
      // Loop through all the skeletons detected
      for (let i = 0; i < this.poses.length; i += 1) {
        // For every skeleton, loop through all body connections
        for (let j = 0; j < this.poses[i].skeleton.length; j += 1) {
          let partA = this.poses[i].skeleton[j][0];
          let partB = this.poses[i].skeleton[j][1];
          this.ctx.beginPath();
          this.ctx.moveTo(partA.position.x, partA.position.y);
          this.ctx.lineTo(partB.position.x, partB.position.y);
          this.ctx.stroke();
        }
      }
    },
    buildCapture: function() {
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
          navigator.mediaDevices
            .getUserMedia(constraints)
            .then((stream) => {
              try {
                this.video.srcObject = stream;
              } catch (error) {
                this.video.srcObject = URL.createObjectURL(stream);
              }
              //info.innerHTML+= "<pre>DONE</pre>";
              console.log("DONE");
              this.$store.commit("attachStream", this.$el);
              this.$store.commit("setLoaded", true);
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
  font-size: 30px;
  z-index: 101;
}

.video_overlay_icon {
  display: inline;
  max-width: 80px;
  max-height: 80px;
  min-width: 50px;
  min-height: 50px;
  padding: 10px;
}

.video_overlay_icon:hover {
  background-color: rgba(220, 220, 220, 0.3);
  border-radius: 25%;
}
</style>
