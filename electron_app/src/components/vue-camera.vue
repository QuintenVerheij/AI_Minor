
function mounted() {
    // console.log(this.$el);
    navigator.mediaDevices
      .enumerateDevices()
      .then((devices) => {
        devices = devices.filter((v) => v.kind == "videoinput");
        // console.log("Found " + devices.length + " video devices");
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
        navigator.mediaDevices
          .getUserMedia(constraints)
          .then((stream) => {
            try {
              this.$el.srcObject = stream;
            } catch (error) {
              this.$el.srcObject = URL.createObjectURL(stream);
            }
            //info.innerHTML+= "<pre>DONE</pre>";
            // console.log("DONE");
            this.$store.commit('attachStream', this.$el)
            this.$store.commit('setLoaded', true);
          })
          .catch((err) => {
            // console.log(err.name + ": " + err.message);
          });
      })
      .catch((err) => {
        // console.log(err.name + ": " + err.message);
      });
  },
};
</script>