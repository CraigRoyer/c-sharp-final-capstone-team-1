<template>
  <table>
    <thead>
      <tr>
        <th>&nbsp;</th>
        <th>Plants</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="plant in plants" :key="plant.plantId" v-on:click="getPlantByPlantId(plant.plantId)">
        <td> 
          <img :src="plant.image" class="plant-photo"/>
        </td>
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