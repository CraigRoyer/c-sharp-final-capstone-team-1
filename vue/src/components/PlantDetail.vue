<template>
<div>
    <h1> {{this.plant.name}} </h1>
    <p> {{this.plant}}</p>
    
</div>
</template>

<script>
import plantService from '../services/PlantService';

export default {
  name: 'plant-detail',
  data() {
    return {
      plant: {
        name:'',
        plantId:0,
        costPer25Seeds:0
      }
    };
  },
  created() {
      plantService.getPlantByPlantId(this.$route.params.plantId).then((response) => {
          this.plant = response.data;
          
      });
  }
};
</script>