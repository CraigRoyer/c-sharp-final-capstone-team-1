<template>
  <div id="main" class="login">

    <form class="form-signin" @submit.prevent="login">
      
      <h2>PLEASE SIGN IN</h2>
    

      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>
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
      <label for="chk" aria-hidden="true">
      <router-link :to="{ name: 'register' }">Need an account?</router-link>
      </label>
      <button type="submit">Sign in</button>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/plot");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style scoped>
path {
  fill: transparent;
}

text {
  fill: #FF9800;
}
 /* #simple_arc {
	display: block;
             text-align: center;
             font-size: 3rem;
	}


#simple_arc>span[class^=w]:nth-of-type(n+0){
					display:block;
					position:absolute;
          -moz-transform-origin:50% 100%;
					-webkit-transform-origin:50% 100%;
					-o-transform-origin:50% 100%;
					-ms-transform-origin:50% 100%;
					transform-origin:50% 100%;
					}


#simple_arc .w0 {
					-moz-transform: rotate(-1.14rad);
					-webkit-transform: rotate(-1.14rad);
					-o-transform: rotate(-1.14rad);
					-ms-transform: rotate(-1.14rad);
					transform: rotate(-1.14rad);
                     width: 21px;
					height: 24px;
					left: 42.7px;
					top: 93.95px;
					}
          #simple_arc .w1 {
					-moz-transform: rotate(-1.14rad);
					-webkit-transform: rotate(-1.14rad);
					-o-transform: rotate(-1.14rad);
					-ms-transform: rotate(-1.14rad);
					transform: rotate(-1.14rad);
                     width: 21px;
					height: 24px;
					left: 42.7px;
					top: 93.95px;
					} 
#simple_arc .w1 {
					-moz-transform: rotate(-1.14rad);
					-webkit-transform: rotate(-1.14rad);
					-o-transform: rotate(-1.14rad);
					-ms-transform: rotate(-1.14rad);
					transform: rotate(-1.14rad);
                     width: 21px;
					height: 24px;
					left: 42.7px;
					top: 93.95px;
					}
          #simple_arc .w1 {
					-moz-transform: rotate(-1.14rad);
					-webkit-transform: rotate(-1.14rad);
					-o-transform: rotate(-1.14rad);
					-ms-transform: rotate(-1.14rad);
					transform: rotate(-1.14rad);
                     width: 21px;
					height: 24px;
					left: 42.7px;
					top: 93.95px;
					} 
#simple_arc .w2 {
					-moz-transform: rotate(-1.14rad);
					-webkit-transform: rotate(-1.14rad);
					-o-transform: rotate(-1.14rad);
					-ms-transform: rotate(-1.14rad);
					transform: rotate(-1.14rad);
                     width: 21px;
					height: 24px;
					left: 42.7px;
					top: 93.95px;
					}
          #simple_arc .w1 {
					-moz-transform: rotate(-1.14rad);
					-webkit-transform: rotate(-1.14rad);
					-o-transform: rotate(-1.14rad);
					-ms-transform: rotate(-1.14rad);
					transform: rotate(-1.14rad);
                     width: 21px;
					height: 24px;
					left: 42.7px;
					top: 93.95px;
					}  */
body{
	margin: 0;
	padding: 0;
	min-height: 100vh;
}

h2 {
  text-align: center;
}
#main{
	width: 650px;
	height: 650px;
  margin: auto;
	background: #af7804;
	border-radius: 98%;
	box-shadow: 5px 20px 50px #8e4505;
} 
label{
	color: #fff;
	font-size: 3.0rem;
	justify-content: center;
	display: flex;
	margin: 30px;
	font-weight: bold;	
	transition: .5s ease-in-out;
}
#main > form > label:nth-child(6) {
  font-size: 1.5rem;
}
#main > form > label:nth-child(1) {
  font-size: 4.0rem;
}
input{
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
button{
	width: 60%;
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
	transition: .2s ease-in;
	cursor: pointer;
}
button:hover{
	background: #5c3e14;
}
.login label{
	color: #5c3e14;

}
</style>
