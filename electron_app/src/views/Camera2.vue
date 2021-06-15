<template>
  <div>
    <!-- {{ poses }} -->
    <canvas id="canvas" width="1280px" height="720px"></canvas>
    <video
      id="video"
      width="1280px"
      height="720px"
      autoplay
      style="display: none"
    ></video>
  </div>
</template>
<script>
import * as poseDetection from "@tensorflow-models/pose-detection";
// Register one of the TF.js backends.
import "@tensorflow/tfjs-backend-webgl";
export default {
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
    // translate context to center of canvas
    this.ctx.translate(this.canvas.width, 0);

    // flip context horizontally
    this.ctx.scale(-1, 1);

    this.updateLoop = setInterval(
      function() {
        this.getPoses();
      }.bind(this),
      50
    );
  },
  data() {
    return {
      canvas: {},
      ctx: {},
      detector: {},
      loaded: false,
      updateLoop: {},
      poses: [],
      video: {},
    };
  },
  methods: {
    async getPoses() {
      const poses = await this.detector.estimatePoses(this.video);
      // console.log('poses: ',this.poses);
      // console.log(this.detector);
      this.poses = poses;
      this.drawCameraIntoCanvas();
    //   console.log(this.poses[0]);
    },
    async buildCapture() {
      let devices = await navigator.mediaDevices.enumerateDevices();
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
      let stream = await navigator.mediaDevices.getUserMedia(constraints);

      try {
        this.video.srcObject = stream;
      } catch (error) {
        this.video.srcObject = URL.createObjectURL(stream);
      }
      //info.innerHTML+= "<pre>DONE</pre>";
      console.log("DONE");
      //   this.$store.commit("attachStream", this.$el);
      //   this.$store.commit("setLoaded", true);
    },

     drawCameraIntoCanvas() {
      // Draw the video element into the canvas
      this.ctx.drawImage(this.video, 0, 0, 1280, 720);
      // We can call both functions to draw all keypoints and the skeletons
      this.drawSkeleton();
      this.drawKeypoints();
     
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
  },
};
</script>



