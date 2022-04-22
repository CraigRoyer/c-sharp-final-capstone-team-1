<template>
<div>
  <div class ="home">
    
    <div id="ah">
    <div id="topPlot">
    <h1 id="mngp" class="pulse">My Newest Garden Plot</h1>
    </div>
    <div id="topPlotInfo">
    <top-plot-detail v-bind:plotId='$route.params.plotId'/>
    </div>
    </div>
<div id="navTo">
    <h2 > </h2>
      <router-link class="navLinks" :to="{ name: 'CreatePlot' }"
      >Create New Plot</router-link>

    <h2 ></h2>
    <router-link class="navLinks" :to="{name: 'AllPlants' }"
    > View All Plants </router-link>

    <h2 ></h2>
    <router-link class="navLinks" :to="{name: 'AllUsersPlots' }"
    > View My Plots </router-link>
    <h2 > </h2>
      <router-link class="navLinks" :to="{ name: 'CreatePlant' }"
      >Add New Plant</router-link>
      </div>

    

  </div>
  <div class="weatherWidget" ></div>
  </div>
</template>

<script>
import TopPlotDetail from '../components/TopPlotDetail.vue';

   window.weatherWidgetConfig =  window.weatherWidgetConfig || [];
   window.weatherWidgetConfig.push({
       selector:".weatherWidget",
       apiKey:"8W8463BUE2J7NQ5ZH8WAVGXNJ", 
       location:"", 
       unitGroup:"us",
       forecastDays:5, 
       title:"",
       showTitle:true, 
       showConditions:true
   });
  
   (function() {
   var d = document, s = d.createElement('script');
   s.src = 'https://www.visualcrossing.com/widgets/forecast-simple/weather-forecast-widget-simple.js';
   s.setAttribute('data-timestamp', +new Date());
   (d.head || d.body).appendChild(s);
   })();

export default {
  components: {
    TopPlotDetail,
    
  }

};
</script>

<style scoped>

.home {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
#navTo {
  display:flex;
  justify-content: space-between;
  margin: 25px;
  width: 50vw;
}
.weatherWidget {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.navLinks {
  background-color: #36BA53;
  padding: 20px;
  margin: 20px;
  border: solid 2px #5C3E14;
  color: #5C3E14;
  text-decoration: none;
  border-radius: 50%;
  transition: all .6s ease-in-out; 
}

.navLinks:hover {
  transform: scale(1.3);
}

#topPlotInfo > div {
  display: flex;
  flex-direction: row;
  justify-content: space-evenly;
  align-items: center;
  padding: 15px;
}

h1 {
  text-decoration: underline;
  font-weight: bolder;
  font-size: 3.0rem;
  
}

#ah {
  background-color: #C78120;
  text-align: center;
  width: 1200px;
  height: 350px;
  border-radius: 50%;
}

#mngp {
  display: flex;
  align-items: center;
  justify-content: center;
  text-decoration: underline;
  color: #36BA53;
  text-decoration-color: #5C3E14; 
  font-size: 60px;
}

</style>
