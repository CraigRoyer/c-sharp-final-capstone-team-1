<template>
<div id="allPages" class="columnBoth">
      <h1 id="createAcc" class="pulse">
<span class="emoji">🌻</span>
<span class="c1">C</span>
<span class="c2">R</span>
<span class="c3">E</span>
<span class="c4">A</span>
<span class="c5">T</span>
<span class="c6">E</span>
<span class="emoji">🌻</span>
<span class="c7">A</span>
<span class="c8">C</span>
<span class="c9">C</span>
<span class="c10">O</span>
<span class="c11">U</span>
<span class="c12">N</span>
<span class="c13">T</span>
<span class="emoji">🌻</span>
<br>
<br>
</h1>
 
  <div id="register" class="login">
    <form class="form-register" @submit.prevent="register">
      
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

#allPages {
  width: 650px;
  height: 650px;
  margin: auto;
  background: #af7804;
  border-radius: 98%;
  box-shadow: 5px 20px 50px #8e4505;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

#allPages > form {
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
#allPages > form > .sr-only {
  font-size: 4.0rem;
}

#allPages > form > label:nth-child(5)
{
	font-size: 1.0rem;
	color: rgb(38, 180, 38);
	
}
input {
  width: 100%;
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
  width: 50%;
  height: 40px;
  margin: auto;
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


#need {
  align-items: center;
  font-size: 20px;
  
}

label {
  text-align: center;
 
}

#createAcc {
  text-align: center;
  margin: 0;
  text-decoration: wavy;
  text-decoration-color: green;
  text-decoration-line: underline;
  text-decoration-thickness: 1px;
  font-weight: bold;
}

h1 span {
text-align: center;
font-size: 20px;
width: auto;
margin: 2px;
text-decoration: wavy;
  text-decoration-color: green;
  text-decoration-line: underline;
  text-decoration-thickness: 1px;
/* position: absolute; */
}
#register {
  margin-top: -75px;
}

.pulse {
  -webkit-animation: pulsate 2.5s ease-out;
    -webkit-animation-iteration-count: infinite; 
    opacity: 0.3;
}
@-webkit-keyframes pulsate {
    0% { opacity: 0.3; }
    50% { opacity: 1.0; }
    100% { opacity: 0.3; }
}
.c1 {
transform: rotate(-60deg);
color: #086320;

}
.c2 {
transform: rotate(-50deg);
color: #C78120;

}
.c3 {
/* transform: rotate(-40deg); */
color: #36BA53;

}
.c4 {
/* transform: rotate(-30deg); */
color: #A4CC4E;

}
.c5 {
/* transform: rotate(-20deg); */
color: #D1965E;

}
.c6 {
/* transform: rotate(-10deg); */
color: #F09713;

}
.c7 {
/* transform: rotate(0deg); */
color: #5C3E14;

}
.c8 {
/* transform: rotate(10deg); */
color: #086320;

}
.c9 {
/* transform: rotate(20deg); */
color: #C78120;

}
.c10 {
/* transform: rotate(30deg); */
color: #36BA53;

}
.c11 {
/* transform: rotate(40deg); */
color: #A4CC4E;

}
.c12 {
/* transform: rotate(50deg); */
color: #D1965E;

}
.c13 {
/* transform: rotate(60deg); */
color: #F09713;

}








</style>
