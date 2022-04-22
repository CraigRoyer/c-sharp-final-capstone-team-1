<template>
<div id="aye">
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
#aye {
  display: flex;
  justify-content: center;
  align-items: center;
}
th {
  font-size: 1.5rem;
}
td {
  font-size: 1.2rem;
  background-color: #C78120;
}
table {
  background-color: #D1965E;
  
}
table, td{
  border: 1px solid;
  width: auto;
  padding: 40px;
  text-align: center;
  
}

td:hover {
  background-color: #A4CC4E;
  }
</style>
