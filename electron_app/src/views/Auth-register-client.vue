<template>
  <body>
    <div>
      <h1 class="title">Fysio App AI Minor</h1>
      <div class="box-center">
        <h1 class="box-title">Signup Client</h1>
        <form method="POST" class="box-form">
          <div class="form-field">
            <input type="text" required />
            <span></span>
            <label>Username</label>
          </div>
          <div class="form-field">
            <input type="text" required />
            <span></span>
            <label>Email</label>
          </div>
          <div class="form-field">
            <input type="text" required />
            <span></span>
            <label>Phonenumber</label>
          </div>
          <div class="form-field">
            <input type="password" required />
            <span></span>
            <label>Password</label>
          </div>
          <div class="field-login">
            <button type="submit" class="button-login">Signup</button>
          </div>
          <div class="field-signup">
            Already have account? <a href="/">Login</a>
          </div>
        </form>
      </div>
    </div>
  </body>
</template>
<script>
export default {
  methods: {
    login() {
      this.$router.replace("/home");
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
  width: 420px;
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
</style>
