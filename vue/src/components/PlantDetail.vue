<template>
<div>
    <h1> {{this.plant.name}} </h1>
    <p> {{this.plant}}</p>
     <div class="actions">
      <button type="button" v-on:click="addPlantToPlot()">Add to my newest plot</button>
    </div>
    
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
  },
  methods: {
  addPlantToPlot(){
    plantService.addPlantToNewestPlot(this.$route.params.plantId).then((response) => {
         if (response.status === 202) {
            this.$router.push("/plot");
          }
        })
        .catch((error) => {
          console.error(error);
        });
      },
    }
  }

</script>