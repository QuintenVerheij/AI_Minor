<template>
  <body> 
    <div>
      <div class="box-center">
        <h1 class="box-title">Login Form</h1>
        <div class="box-form">
          <div class="form-field">
            <input v-model="login_data.username" v-on:keyup.enter="login" type="text" required />
            <span></span>
            <label>Username</label>
          </div>
            <p style="color: red" v-if="show_username_is_empty_error">Username is required</p>
          <div class="form-field">
            <input v-model="login_data.password" v-on:keyup.enter="login" type="password" required />
            <span></span>
            <label>Password</label>
          </div>
            <p style="color: red" v-if="show_password_is_empty_error">Password is required</p>
          <div v-if="show_error_message">
            <pre class="error-message">{{ this.error_message }}</pre>
          </div>
          <div class="field-login">
            <button class="button-login my-auto mx-auto text-center" v-on:click="login">
                <div v-if="!logging_in">Login</div>
                <pulse-loader v-else :color="'#FFFFFF'"></pulse-loader>
            </button>
          </div>
          <div class="field-signup">
            Not a member? <br>
            <a href="register-client">
                <button type="button" class="button-client my-auto mx-auto">Sign up as Client</button>
            </a>
            <a href="register-therapist">
                <button type="button" class="button-therapist my-auto mx-auto">Sign up as Therapist</button>
            </a>
          </div>
      </div>
    </div>
    </div>
  </body>
</template>
<script>
import PulseLoader from 'vue-spinner/src/PulseLoader.vue'
export default {
  components:{
    PulseLoader 
  },
  data() {
    return {
      logging_in: false,
      login_data: {
        username: "",
        password: "",
      },
      show_error_message: false,
      show_username_is_empty_error: false,
      show_password_is_empty_error: false,
      error_message: "",
    };
  },
  methods: {
    login() {
      this.logging_in = true;
      this.show_username_is_empty_error = false;
      this.show_password_is_empty_error = false;
      this.show_error_message = false;
      if(this.login_data.username === "" || this.login_data.password === ""){
        if(this.login_data.username === ""){
          this.show_username_is_empty_error = true;
        }
        if(this.login_data.password === ""){
          this.show_password_is_empty_error = true;
        }
        this.logging_in = false;
      }else{
        console.log(process.env.NODE_ENV)
        this.$store.dispatch('authentication/login',
          this.login_data
        ).then(()=>{
          this.$router.push({name: 'Home'})
        }).catch((ex)=> {
          this.show_error_message = true;
          console.log(ex.response)
          if(ex.response.status === 400){
            this.error_message = ex.response.data.message
          }
        }).finally(() =>{
          this.logging_in = false;
        });
      }
    },
    show_errors: function (errors) {
      if (typeof errors == "string") {
        this.error_message = errors;
      } else {
        this.error_message = errors.reduce(
          (acc, curr) => acc + "\n" + curr.description,
          ""
        );
      }
      this.show_error_message = true;
    },
  },
};
</script>
<style scoped>
body {
  margin: 0;
  padding: 0;
  font-family: montserrat;
  /* background-color:lightgrey !important; */
  height: 100vh;
  overflow: hidden;
}
.title {
  text-align: center;
  color: #081f5e;
  padding: 50px;
}

.box-center {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  min-width: 420px;
  width: fit-content;
  background: white;
  border-radius: 12px;
}

.box-title {
  text-align: center;
  color: #081f5e;
  padding: 0 0 20px 0;
  border-bottom: 1px solid #081f5e;
}

.box-form {
  padding: 0 42px;
  box-sizing: border-box;
}

.box-form .form-field {
  position: relative;
  border-bottom: 2px solid #adadad;
  margin: 30px 0;
}

.box-form p {
  line-height: 0.8;
}

.form-field input {
  width: 100%;
  padding: 0 5px;
  height: 40px;
  font-size: 16px;
  border: none;
  background: none;
  outline: none;
}

.form-field label {
  position: absolute;
  top: 50%;
  left: 5px;
  color: #adadad;
  transform: translateY(-50%);
  font-size: 16px;
  pointer-events: none;
  transition: 0.5s;
}

.form-field span::before {
  content: "";
  position: absolute;
  top: 40px;
  left: 0;
  width: 0%;
  height: 4px;
  background: #081f5e;
  transition: 0.5s;
}

.form-field input:focus ~ label,
.form-field input:valid ~ label {
  top: -5px;
  color: #081f5e;
  font-size: 16px;
}

.form-field input:focus ~ span::before,
.form-field input:valid ~ span::before {
  width: 100%;
}

.field-login {
  margin: -5px 0 20px 5px;
}

.button-login {
  width: 100%;
  height: 40px;
  border: 1px solid;
  background: #081f5e;
  border-radius: 25px;
  font-size: 22px;
  color: antiquewhite;
  font-weight: 700;
  outline: none;
  cursor: pointer;
}

.button-client,
.button-therapist {
  width: 45%;
  height: 40px;
  border: 1px solid;
  background: #e43f6f;
  border-radius: 25px;
  font-size: 22px;
  color: antiquewhite;
  font-weight: 700;
  outline: none;
  cursor: pointer;
  font-size: 14px;
}

.button-login:hover {
  border-color: black;
  transition: 0.5s;
}

.field-signup {
  margin: 30px 0;
  text-align: center;
  font-size: 17px;
  color: #adadad;
}

.field-signup a {
  color: #4646c5;
  text-decoration: none;
  padding-left: 5px;
}

.field-signup a:hover {
  text-decoration: underline;
}

.error-message {
  color: red;
}
</style>
