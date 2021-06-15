<template>
  <div>
    {{ poses }}

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

    this.updateLoop = setTimeout(
      function() {
        this.getPoses();
      }.bind(this),
      16
    );
  },
  data() {
    return {
      detector: {},
      loaded: false,
      updateLoop: {},
      poses: [],
      video: {},
    };
  },
  methods: {
    async getPoses() {
        console.log('hi');
    //   const poses = await this.detector.estimatePoses(this.video);
      console.log('poses: ',this.poses);
      console.log(this.detector);
    //   this.poses = this.poses;
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
  },
};
</script>
