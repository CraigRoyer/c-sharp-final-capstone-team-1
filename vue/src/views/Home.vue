<template>
  <div class ="home">
    <div id="ah">
    <div id="topPlot">
    <h1>My Newest Garden Plot</h1>
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
</template>

<script>
import TopPlotDetail from '../components/TopPlotDetail.vue';


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

</style>