import { HTTP } from "@/plugins/axios";

const saveData = ({ commit }, payload) => {// eslint-disable-line
  let data = mapData(payload);
  (data.pose = "test"), (data.target = 1);
  HTTP.post("data", data).then((response) => console.log(response));
};

function mapData(data) {
  let pose = data[0].pose;
  return {
    noseX: pose.nose.x,
    noseY: pose.nose.y,
    leftEyeX: pose.leftEye.x,
    leftEyeY: pose.leftEye.y,
    rightEyeX: pose.rightEye.x,
    rightEyeY: pose.rightEye.y,
    leftShoulderX: pose.leftShoulder.x,
    leftShoulderY: pose.leftShoulder.y,
    rightShoulderX: pose.rightShoulder.x,
    rightShoulderY: pose.rightShoulder.y,
    leftElbowX: pose.leftElbow.x,
    leftElbowY: pose.leftElbow.y,
    leftWristX: pose.leftWrist.x,
    leftWristY: pose.leftWrist.y,
    rightWristX: pose.rightWrist.x,
    rightWristY: pose.rightWrist.y,
    leftHipX: pose.leftHip.x,
    leftHipY: pose.leftHip.y,
    rightHipX: pose.rightHip.x,
    rightHipY: pose.rightHip.y,
    leftKneeX: pose.leftKnee.x,
    leftKneeY: pose.leftKnee.y,
    rightKneeX: pose.rightKnee.x,
    rightKneeY: pose.rightKnee.y,
    leftAnkleX: pose.leftAnkle.x,
    leftAnkleY: pose.leftAnkle.y,
    rightAnkleX: pose.rightAnkle.x,
    rightAnkleY: pose.rightAnkle.y,
  };
}

export default {
  saveData,
};
