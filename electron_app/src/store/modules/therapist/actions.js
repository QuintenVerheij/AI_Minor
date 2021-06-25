import { HTTP } from "@/plugins/axios";
import { uploadMedia } from "@/plugins/firebase";

const saveData = ({ commit }, payload) => {   // eslint-disable-line
  let data = stringValuesToIntegers(mapData(payload));

  return HTTP.post("data", data).then((response) => {
    return response
  }).catch((response) => response);
};

const getPoseNames = (context) => {
  console.log('getting pose names')
  return HTTP.get(context.rootGetters["api/GET_POSE_NAMES_EXTENSION"]).then((response) => context.commit("SET_POSE_NAMES", response.data))
}

function stringValuesToIntegers(obj) {
  const res = {}
  for (const key in obj) {
    const parsed = parseInt(obj[key], 10);
    res[key] = isNaN(parsed) ? obj[key] : parsed;
  }
  return res;
}
function mapData(poses) {
  // // console.log(poses);
  let data = poses[0].keypoints;
  // // console.log(data);
  const nose = data.find((e) => e.name == "nose");
  const leftEye = data.find((e) => e.name == "left_eye");
  const rightEye = data.find((e) => e.name == "right_eye");
  const leftShoulder = data.find((e) => e.name == "left_shoulder");
  const rightShoulder = data.find((e) => e.name == "right_shoulder");
  const leftElbow = data.find((e) => e.name == "left_elbow");
  const rightElbow = data.find((e) => e.name == "right_elbow");
  const leftWrist = data.find((e) => e.name == "left_wrist");
  const rightWrist = data.find((e) => e.name == "right_wrist");
  const leftHip = data.find((e) => e.name == "left_hip");
  const rightHip = data.find((e) => e.name == "right_hip");
  const leftKnee = data.find((e) => e.name == "left_knee");
  const rightKnee = data.find((e) => e.name == "right_knee");
  const leftAnkle = data.find((e) => e.name == "left_ankle");
  const rightAnkle = data.find((e) => e.name == "right_ankle");

  return {
    pose: poses.pose,
    noseX: nose.x,
    noseY: nose.y,
    leftEyeX: leftEye.x,
    leftEyeY: leftEye.y,
    rightEyeX: rightEye.x,
    rightEyeY: rightEye.y,
    leftShoulderX: leftShoulder.x,
    leftShoulderY: leftShoulder.y,
    rightShoulderX: rightShoulder.x,
    rightShoulderY: rightShoulder.y,
    leftElbowX: leftElbow.x,
    leftElbowY: leftElbow.y,
    rightElbowX: rightElbow.x,
    rightElbowY: rightElbow.y,
    leftWristX: leftWrist.x,
    leftWristY: leftWrist.y,
    rightWristX: rightWrist.x,
    rightWristY: rightWrist.y,
    leftHipX: leftHip.x,
    leftHipY: leftHip.y,
    rightHipX: rightHip.x,
    rightHipY: rightHip.y,
    leftKneeX: leftKnee.x,
    leftKneeY: leftKnee.y,
    rightKneeX: rightKnee.x,
    rightKneeY: rightKnee.y,
    leftAnkleX: leftAnkle.x,
    leftAnkleY: leftAnkle.y,
    rightAnkleX: rightAnkle.x,
    rightAnkleY: rightAnkle.y,
  };
}

function prepareData(context, data) { // eslint-disable-line
  const d = stringValuesToIntegers(mapData(data));
  delete d.target;
  delete d.pose;
  return scale(Object.values(d));
}

function scale(data) {
  let scaled_data = []
  data.forEach(el => {
    scaled_data.push(el / 1280);
  });

  return scaled_data;
}

const createMedia =
  async (context, payload) => { // eslint-disable-line no-unused-vars
    let file = payload.file;
    let extension = file.name.split(".").pop();
    let type = payload.type;
    let url = await uploadMedia({
      media: file,
      extension: extension,
      type: type,
    });
    console.log(url)

    // let data = {
    //   type: payload.type,
    //   title: payload.title,
    //   url: url,
    // };

    HTTP.post(context.rootGetters["api/GET_FILE_UPLOAD_EXTENSION"], {url: url}).then((response) => {
      console.log(response)
    }).catch((error) => {
      console.log(error)
      return error
    });
    return url
  };

export default {
  saveData,
  prepareData,
  createMedia,
  getPoseNames
};
