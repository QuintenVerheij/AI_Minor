<template>
  <body>
    <div>
      <div class="box-center">
        <h1 class="box-title">Signup Form</h1>
        <br/>
        <b-form class="box-form" @submit="register">
          <b-form-group class="form-field" label="Username" label-for="username-input">
            <b-form-input id="username-input" v-model="register_data.username" type="text" required />
            <span></span>
          </b-form-group>
          <b-form-group class="form-field" label="E-mail" label-for="email-input">
            <b-form-input id="email-input" v-model="register_data.email" type="email" required />
            <span></span>
          </b-form-group>
          <b-form-group class="form-field" label="Phone number" label-for="phone-input">
            <b-form-input id="phone-input" v-model="register_data.phoneNumber" type="text" required />
            <span></span>
          </b-form-group>
          <b-form-group class="form-field" label="Password" label-for="password-input">
            <b-form-input id="password-input" v-model="register_data.password" type="password" required />
            <span></span>
          </b-form-group>
          <b-form-invalid-feedback :state=validatePassword>
            <p v-for="info in password_validation_info" v-bind:key="info">{{info}}</p>
          </b-form-invalid-feedback>
          <b-form-group class="form-field" label="Confirm password" label-for="password-confirm-input">
            <b-form-input id="password-confirm-input" v-model="password_confirm" type="password" required />
            <span></span>
          </b-form-group>
          <b-form-invalid-feedback :state=validatePasswordsMatch>
            Passwords do not match
          </b-form-invalid-feedback>
          <div v-if="show_error_message">
            <pre class="error-message">{{ this.error_message }}</pre>
          </div>
          <br/>
          <div class="field-login">
            <b-button type="submit" class="button-login">Sign up</b-button>
          </div>
          <p v-if="register_succesful">Registratie compleet. Naar inlogpagina...</p>
          <div class="field-signup">
            Already have account? <a href="login">Login</a>
          </div>
        </b-form>
      </div>
    </div>
  </body>
</template>
<script>
export default {
  computed: {
    password_validation_info(){
      var res = []
      if (!this.validatePasswordLength){
        res.push("Password must be at least 8 characters long")
      }
      if (!this.validatePasswordDigit){
        res.push("Password must contain at least 1 digit (0-9)")
      }
      if (!this.validatePasswordUpper){
        res.push("Password must contain at least 1 uppercase letter (A-Z)")
      }
      if (!this.validatePasswordNonAlpha){
        res.push("Password must contain at least 1 non-alphanumeric character (@, !, etc.)")
      }
      return res
    },
    validatePassword(){
      return this.validatePasswordLength && this.validatePasswordDigit && this.validatePasswordUpper && this.validatePasswordNonAlpha
    },
    validatePasswordLength(){
      return this.register_data.password.length >= 8 
    },
    validatePasswordDigit(){
      return /\d/.test(this.register_data.password)
    },
    validatePasswordUpper(){
      return /[A-Z]/.test(this.register_data.password)
    },
    validatePasswordNonAlpha(){
      return /[^a-zA-Z0-9]/.test(this.register_data.password)
    },
    validatePasswordsMatch() {
      return this.register_data.password === this.password_confirm
    }
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
      register_succesful: false,
      show_error_message: false,
      error_message: "",
      register_response: {
        succeeded: true,
        errors: [],
      },
    };
  },
  methods: {
    register(event) {
      event.preventDefault()
      // console.log('register');
        this.$store
          .dispatch("authentication/register", this.register_data)
          .then((success) => {
            if (success) {
              this.register_succesful = true;
              setTimeout(() => {
                this.$router.push({name: "Auth"});
              }, 2000);
            }
          })
          .catch((error) => this.show_errors(error));
    },
    show_errors: function (error) {
      this.error_message = error.data.errors.reduce(
        (aggr, curr) => aggr + "\n" + curr.description,
        ""
      );
      this.show_error_message = true;
    },
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

.invalid-feedback {
  margin-bottom: 20px;
}

.box-form .form-field {
  position: relative;
  border-bottom: 2px solid #adadad;
  margin-top: 35px;
  margin-bottom: 10px;
}

.form-field input {
  width: 100%;
  margin-top: 5px;
  padding: 0 5px;
  height: 40px;
  font-size: 16px;
  border: none;
  background: none;
  outline: none;
}

.form-field label {
  position: absolute;
  top: -50%;
  color: #adadad;
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
  top: -10px;
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
