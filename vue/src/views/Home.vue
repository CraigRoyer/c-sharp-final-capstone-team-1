<template>
  <div class ="home">
    <h1>My Newest Garden Plot</h1>
    <top-plot-detail v-bind:plotId='$route.params.plotId'/>
<div id="navTo">
    <h2> </h2>
      <router-link :to="{ name: 'CreatePlot' }"
      >Create New Plot</router-link>

    <h2></h2>
    <router-link :to="{name: 'AllPlants' }"
    > View All Plants </router-link>

    <h2></h2>
    <router-link :to="{name: 'AllUsersPlots' }"
    > View My Plots </router-link>
    <h2> </h2>
      <router-link :to="{ name: 'CreatePlant' }"
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

#navTo {
  display:flex;
  justify-content: space-around;
}



</style>