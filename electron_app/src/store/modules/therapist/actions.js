import { HTTP } from "@/plugins/axios";
import { uploadMedia } from '@/plugins/firebase'

const saveData = ({ commit }, payload) => {// eslint-disable-line
  let data = mapData(payload);
  // (data.pose = "test"),

  return HTTP.post("data", data).then((response) =>{
    console.log(response);
    return response}).catch((response) => response);
};

function mapData(data) {
  console.log(data[0].pose);
  let pose = data[0].pose;
  return {
    pose: data.pose,
    target: data.target,
    noseX: Math.floor(pose.nose.x),
    noseY: Math.floor(pose.nose.y),
    leftEyeX: Math.floor(pose.leftEye.x),
    leftEyeY: Math.floor(pose.leftEye.y),
    rightEyeX: Math.floor(pose.rightEye.x),
    rightEyeY: Math.floor(pose.rightEye.y),
    leftShoulderX: Math.floor(pose.leftShoulder.x),
    leftShoulderY: Math.floor(pose.leftShoulder.y),
    rightShoulderX: Math.floor(pose.rightShoulder.x),
    rightShoulderY: Math.floor(pose.rightShoulder.y),
    leftElbowX: Math.floor(pose.leftElbow.x),
    leftElbowY: Math.floor(pose.leftElbow.y),
    rightElbowX: Math.floor(pose.rightElbow.x),
    rightElbowY: Math.floor(pose.rightElbow.y),
    leftWristX: Math.floor(pose.leftWrist.x),
    leftWristY: Math.floor(pose.leftWrist.y),
    rightWristX: Math.floor(pose.rightWrist.x),
    rightWristY: Math.floor(pose.rightWrist.y),
    leftHipX: Math.floor(pose.leftHip.x),
    leftHipY: Math.floor(pose.leftHip.y),
    rightHipX: Math.floor(pose.rightHip.x),
    rightHipY: Math.floor(pose.rightHip.y),
    leftKneeX: Math.floor(pose.leftKnee.x),
    leftKneeY: Math.floor(pose.leftKnee.y),
    rightKneeX: Math.floor(pose.rightKnee.x),
    rightKneeY: Math.floor(pose.rightKnee.y),
    leftAnkleX: Math.floor(pose.leftAnkle.x),
    leftAnkleY: Math.floor(pose.leftAnkle.y),
    rightAnkleX: Math.floor(pose.rightAnkle.x),
    rightAnkleY: Math.floor(pose.rightAnkle.y),
  };
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
  saveData,
};
