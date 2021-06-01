import { firebase } from '@firebase/app'
import 'firebase/storage'
import {v4 as uuidv4} from 'uuid';
// firebase init - add your own config here
const firebaseConfig = {
    apiKey: "AIzaSyBSx_3bhzpfX06-DJhKl5a_2-8hkh-32NA",
    authDomain: "poseestimation-41bda.firebaseapp.com",
    projectId: "poseestimation-41bda",
    storageBucket: "poseestimation-41bda.appspot.com",
    messagingSenderId: "227258654083",
    appId: "1:227258654083:web:89c9af98ae362e17d82ab6"
  };

if (!firebase.apps.length) {
    firebase.initializeApp(firebaseConfig);
 }else {
    firebase.app(); // if already initialized, use that one
 }
// utils
const storage = firebase.storage()


const uploadMedia = async(payload) => {  // eslint-disable-line no-unused-vars
  let storageRef = storage.ref();
  let imageName = uuidv4();
 
  // Create a reference to 'images/mountains.jpg'
  let imageRef = storageRef.child(`${payload.type}/${imageName}.${payload.extension}`);
  let snapshot = await imageRef.put(payload.media);
  let downloadUrl = await snapshot.ref.getDownloadURL()
  return downloadUrl;
}


// export utils/refs
export {
  storage,
  uploadMedia
}