<template>
<div id="allPages" class="columnBoth">
  
 
  <div id="register" class="login">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <label id="need" for="chk" class="grow">
      <router-link id="back" :to="{ name: 'login' }">Have an account?</router-link>
      </label>
      <button class="grow" type="submit">
        Create Account
      </button>
    </form>
  </div>
  </div>
</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: '/login',
                query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
  },
};
</script>

<style>
body {
  background: linear-gradient(90deg, #fcff9e 0%, #c67700 100%);
background-position: fixed;
white-space: nowrap;
}

body {
  margin: 0;
  padding: 0;
  min-height: 100vh;
}

#register {
  width: 700px;
  height: 700px;
  margin: auto;
  background: #af7804;
  border-radius: 98%;
  box-shadow: 5px 20px 50px #8e4505;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

#register > form {
  width: 500px;
}
label {
  color: #fff;
  font-size: 3rem;
  justify-content: center;
  display: flex;
  margin: 30px;
  font-weight: bold;
  transition: 0.5s ease-in-out;
}
#register > form > .sr-only {
  font-size: 4.0rem;
}

#register > form > label:nth-child(5)
{
	font-size: 1.0rem;
	color: rgb(38, 180, 38);
	
}
input {
  width: 60%;
  height: 20px;
  background: #e0dede;
  justify-content: center;
  display: flex;
  margin: 20px auto;
  padding: 10px;
  border: none;
  outline: none;
  border-radius: 5px;
}
button {
  width: 40%;
  height: 40px;
  margin: 10px auto;
  justify-content: center;
  display: block;
  color: #fff;
  background: #d1965e;
  font-size: 1em;
  font-weight: bold;
  margin-top: 20px;
  outline: none;
  border: none;
  border-radius: 5px;
  transition: 0.2s ease-in;
  cursor: pointer;
}
button:hover {
  background: #5c3e14;
  
}
.login label {
  color: #5c3e14;
}
.grow { 
transition: all .6s ease-in-out; 
width: 200px;
}

.grow:hover { 
transform: scale(1.3); 
}

h1 {
  text-align: center;
  color: #F09713;
}

#need {
  align-items: center;
  font-size: 20px;
  margin-left: 150px;
}

label {
  text-align: center;
 
}



</style>
