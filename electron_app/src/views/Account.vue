<template>
    <b-container class="text-left">
        <h1>Persoonlijke informatie</h1>
        <!-- <b-img v-if="!has_image && profile_picture" width="300" height="300" :src="selected_image_url"></b-img> -->
        <b-img v-if="has_image" :src="user.image_url"></b-img>
        <!-- <b-form-file
            v-else
            accept="image/*"
            v-model="profile_picture"
            :state="Boolean(profile_picture)"
            placeholder="Choose a file or drop it here..."
            drop-placeholder="Drop file here..."
        ></b-form-file> -->
        <custom-avatar></custom-avatar>
        <b-list-group>
            <b-list-group-item>Voornaam: {{user.first_name}}</b-list-group-item>
            <b-list-group-item>Achternaam: {{user.last_name}}</b-list-group-item>
            <b-list-group-item>Leeftijd: {{user.age}}</b-list-group-item>
        </b-list-group>
        <div v-if="user.trainer != null">
            Trainer: {{user.trainer}}
        </div>
        <div v-else>
            <h1>Trainer code:</h1>
            <b-form-input v-model="code" placeholder="Voer je code in"></b-form-input>
        </div>
    </b-container>
</template>
<script>
import CustomAvatar from '../components/CustomAvatar.vue';

export default {
  components: { CustomAvatar },

    computed: {
        user(){
            return this.$store.getters['authentication/get_user']
        },
        has_image(){
            return false;
        },
        selected_image_url(){
            if(this.profile_picture){
                return URL.createObjectURL(this.profile_picture);
            }
            return "";
        }
    },
    data(){
        return {
            // mainProps: { blank: true, blankColor: '#777', width: 75, height: 75, class: 'm1' },
            code: null,
            profile_picture: null,

        }
    }
}
</script>