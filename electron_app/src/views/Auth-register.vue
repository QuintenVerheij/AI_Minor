<template>
  <body>
    <div>
      <div class="box-center">
        <h1 class="box-title">Signup Form</h1>
        <div class="box-form">
          <div class="form-field">
            <input v-model="register_data.username" type="text" required />
            <span></span>
            <label>Username</label>
          </div>
          <div class="form-field">
            <input v-model="register_data.email" type="text" required />
            <span></span>
            <label>Email</label>
          </div>
          <div class="form-field">
            <input v-model="register_data.phoneNumber" type="text" required />
            <span></span>
            <label>Phonenumber</label>
          </div>
          <div class="form-field">
            <input v-model="register_data.password" type="password" required />
            <span></span>
            <label>Password</label>
          </div>
          <div class="form-field">
            <input v-model="password_confirm" type="password" required />
            <span></span>
            <label>Confirm Password</label>
          </div>
          <div v-if="show_error_message">
            <pre class="error-message">{{ this.error_message }}</pre>
          </div>
          <div class="field-login">
            <button @click="register" class="button-login">Sign up</button>
          </div>
          <div class="field-signup">
            Already have account? <a href="login">Login</a>
          </div>
        </div>
      </div>
    </div>
  </body>
</template>
<script>
export default {
  created() {
    // console.log(this.$store.getters["api/GET_REGISTER_ENDPOINT"]);
  },
  data() {
    return {
      // LOCAL STATE GOES HERE
      register_data: {
        username: "",
        email: "",
        phoneNumber: "",
        password: "",
        role: "Client",
      },
      password_confirm: "",
      show_error_message: false,
      error_message: "",
      register_response: {
        succeeded: true,
        errors: [],
      },
    };
  },
  methods: {
    register(){
      // console.log('register');
      this.$store.dispatch('authentication/register', this.register_data).then(()=>this.$router.go(-1));
    },
    
    show_errors: function(errors) {
        this.error_message = errors.reduce((acc, curr) => acc + "\n" + curr.description, "")
        this.show_error_message = true;
    }
  },
};
</script>
<style>
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
