import { HTTP } from "@/plugins/axios";
import { uploadMedia } from '@/plugins/firebase'

const saveData = ({ commit }, payload) => {// eslint-disable-line
  let data = mapData(payload);
  // (data.pose = "test"),

  return HTTP.post("data", data).then((response) =>{
    console.log(response);
    return response}).catch((response) => response);
};

function mapData(poses) {
  let data = poses[0].keypoints;
  const nose = data.find((e)=>e.name=="nose");
  const leftEye = data.find((e)=>e.name=="left_eye");
  const rightEye = data.find((e)=>e.name=="right_eye");
  const leftShoulder = data.find((e)=>e.name=="left_shoulder");
  const rightShoulder = data.find((e)=>e.name=="right_shoulder");
  const leftElbow = data.find((e)=>e.name=="left_elbow");
  const rightElbow = data.find((e)=>e.name=="right_elbow");
  const leftWrist = data.find((e)=>e.name=="left_wrist");
  const rightWrist = data.find((e)=>e.name=="right_wrist");
  const leftHip = data.find((e)=>e.name=="left_hip");
  const rightHip = data.find((e)=>e.name=="right_hip");
  const leftKnee = data.find((e)=>e.name=="left_knee");
  const rightKnee = data.find((e)=>e.name=="right_knee");
  const leftAnkle = data.find((e)=>e.name=="left_ankle");
  const rightAnkle = data.find((e)=>e.name=="right_ankle");

  return {
    pose: data.pose,
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

function prepareData(context// eslint-disable-line
  ,data){
    const d = mapData(data)
    delete(d.target)
  return Object.values(d)
}

const createMedia = async ({commit}, payload) => { // eslint-disable-line no-unused-vars
  let file = payload.file;
  let extension = file.name.split('.').pop();
  let type = payload.type;
  let url = await uploadMedia({
    media: file,
    extension: extension,
    type: type
  });

  let data = {
    type: payload.type,
    title: payload.title,
    url: url
  }
  let result = await HTTP.post('admin/media/', data, {
    headers: {
      'Authorization' : `Bearer ${localStorage.token}`
    }});

  return result;
}

export default {
  saveData, prepareData
};
