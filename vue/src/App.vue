<template>
  <div id="app"> 
    <div id="headAndBody">
    <header>
    <div id="nav">
      <div id="links">
      <router-link v-bind:to="{ name: 'home' }">Home </router-link>&nbsp;| &nbsp;
      <router-link v-bind:to="{ name: 'logout' }">Logout</router-link>  
      </div> 
      <div id="logoDiv">
        <h3>Welcome to the... </h3>
      <img src="https://i.imgur.com/F1ipLGJ.png" id="logo"/> 
      </div>
    </div>
    </header>
    <body>
    <div>
    <router-view />
    </div>
    </body>
    </div>
    <footer>
    <div id="foota">
      <img src="@/Pictures/FUCK.png" id="flora"/>
      <h5>Brought to you by the wonderful Team Circumflex</h5>&nbsp; <img src="@/Pictures/FUCK.png" id="flora"/>
      </div>
      </footer>
  </div>
</template>

<style scoped>

body { 
  padding: 0px;
  margin: 0px;
  font-family: "Mali", Arial, Helvetica, sans-serif;
 
}

* {
  font-family: "Mali", Arial, Helvetica, sans-serif;
}

 #links { 
  display: flex;
  flex-direction: row;
  align-items: flex-end;
  justify-content: flex-end;
} 


/* #aboutGardn {
display: flex;
flex-direction: column;
} */

a {
  display: flex;
  flex-direction: column;
  font-family: Helvetica, sans-serif;
  font-weight: bolder;
  /* border: solid 5px #fb8917; */
}

#logo {
  width: 500px;
  height: 200px;
  
} 

h3 {
  color: #36ba53;
  font-size: 2.5rem;
  margin-left: 30px;
}

#logoDiv {
  display:flex;
  align-items: flex-end;
  
}

#foota {
  display: flex;
  justify-content: flex-end;

}

h5 {
  font-size: 1.0rem;
}

#flora {
  width: 50px;
}

#app {
  height: 100vh;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: space-between;

}






</style>
