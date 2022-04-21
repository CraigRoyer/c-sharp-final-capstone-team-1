<template>
  <table id="yo">
    <thead>
      <tr>
        <th>&nbsp;</th>
        
      </tr>
    </thead>
    <tbody>
      <tr v-for="plant in plants" :key="plant.plantId" v-on:click="getPlantByPlantId(plant.plantId)">
        <!-- <td> 
          <img :src="plant.image" class="plant-photo"/>
        </td> -->
        <td class="name">{{ plant.name }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import plantService from "../services/PlantService";

export default {
  name: "plant-list",
  data() {
    return {
      plants: []
    };
  },
  methods: {
    getPlantByPlantId(plantId) {
      this.$router.push(`/plant/${plantId}`);
    }
  },
  created() {
    plantService.listAllPlants().then((response) => {
      this.plants = response.data;
    });
  }
};
</script>

<style scoped>
table, td{
  border: 1px solid;
  width: auto;
  padding: 20px;
  text-align: center;
  
}

td:hover {
  background-color: #A4CC4E;
  }

</style>