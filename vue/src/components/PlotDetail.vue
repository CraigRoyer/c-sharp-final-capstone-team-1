<template>
<div id="oh">

    <h1  id="latitle"> {{this.plot.plotName}} </h1>
    <p> <em>Length:</em> {{this.plot.length}}</p>
    <p> <em>Width:</em> {{this.plot.width}}</p>
    <p> <em>Sun Exposure:</em> {{this.plot.sunExposure}}</p>
    <p> <em>Zone:</em> {{this.plot.zone}}</p>

    <h2> Plants In This Plot </h2>
     <table id="yo">
    <thead>
      <tr>
        <th>&nbsp;</th>
        
      </tr>
    </thead>
    <tbody>
      <tr v-for="plant in plants" :key="plant.plantId" v-on:click="getPlantByPlantId(plant.plantId)">
      <td> 
          <img :src="plant.imageUrl" class="plant-photo"/>
        </td>
        <td class="name">{{ plant.name }}</td>
      </tr>
    </tbody>
  </table>
 
</div>
</template>

<script>
import plotService from '../services/PlotService';
import plantService from '../services/PlantService';

export default {
  name: 'plot-detail',
  data() {
    return {
      plot: {
        plotName:'',
        length:0,
        width:0,
        sunExposure:0,
        zone:0,
        plotId:0,
        userId:0,
      },
      plants: []
    };
  },
 methods: {
   getPlantByPlantId(plantId) {
      this.$router.push(`/plant/${plantId}`);
    }
 },
     created() {
      plotService.getPlot(this.$route.params.plotId).then((response) => {
          this.plot = response.data;});
      plantService.getPlantsByPlotId(this.$route.params.plotId).then((response) => {
      this.plants = response.data;
      });
    }
  };


</script>

<style scoped>
#oh {
  background-color: olivedrab;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  text-align: center;
  font-size: 1.5rem;
}

table, td{
  border: 1px solid;
  width: auto;
  padding: 20px;
  text-align: center;
  
}
#latitle {
  text-decoration: underline;
}

td:hover {
  background-color: #A4CC4E;
  }

</style>