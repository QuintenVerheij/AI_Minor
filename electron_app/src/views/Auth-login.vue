<template>
  <body>
    <NavBar />
    <div>
      <div class="box-center">
        <h1 class="box-title">Login Form</h1>
        <div class="box-form">
          <div class="form-field">
            <input v-model="login_data.username" type="text" required />
            <span></span>
            <label>Username</label>
          </div>
          <div class="form-field">
            <input v-model="login_data.password" type="password" required />
            <span></span>
            <label>Password</label>
          </div>
          <div v-if="show_error_message">
            <pre class="error-message">{{ this.error_message }}</pre>
          </div>
          <div class="field-login">
          <div class="field-signup">
            Not a member? <a href="register">Signup</a>
          </div>
        </div>
      </div>
          <div class="field-signup">
            Not a member? <br>
            <a href="register-client">
                <button type="button" class="button-client my-auto mx-auto">Signup as Client</button>
            </a>
            <a href="register-therapist">
                <button type="button" class="button-therapist my-auto mx-auto">Signup as Therapist</button>
            </a>
          </div>
    </div>
  </body>
</template>
<script>
import NavBar from '@/components/NavBar.vue'
export default {
components: {NavBar},
    methods: {
        login(){
          if(this.$store.dispatch('authentication/debugLogin')) {
            this.$router.push({name: 'Home'});
          }
        },
    }
}
</script>
<style scoped>
body {
    margin: 0;
    padding: 0;
    font-family: montserrat;
    background-color:lightgrey !important;
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
    width: 420px;
    background: white;
    border-radius: 12px;
}

.box-title {
    text-align: center;
    padding: 0 0 20px 0;
    border-bottom: 1px solid silver;
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
    content: '';
    position: absolute;
    top: 40px;
    left: 0;
    width: 0%;
    height: 4px;
    background: #4646c5;
    transition: .5s;
}

.form-field input:focus ~ label,
.form-field input:valid ~ label {
    top: -5px;
    color: #4646c5;
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
    background: #4646c5;
    border-radius: 25px;
    font-size: 22px;
    color: antiquewhite;
    font-weight: 700;
    outline: none;
    cursor: pointer;
}

.button-client, .button-therapist{
  width: 40%;
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
		</style>

.error-message {
    color: red;
}
</style>
