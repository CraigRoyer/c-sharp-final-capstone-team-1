<template>
  <div>
    <div id="all-plant-fields">
      <h1 id="daname" class="pulse">{{ this.plant.name }}</h1>
      <div class="plant-information">
        <p><strong class="headx">Sow Instructions:</strong>{{ this.plant.sowInstructions }}</p>
      </div>
      <div class="plant-information">
        <p><strong class="headx">Space Instructions:</strong>{{ this.plant.spaceInstructions }}</p>
      </div>
      <div class="plant-information">
        <p><strong class="headx">Harvest Instructions:</strong>{{ this.plant.harvestInstructions }}</p>
      </div>
      <div class="plant-information">
        <p><strong class="headx">Plant Information:</strong>{{ this.plant.compatiblePlants }}</p>
      </div>
      <div class="plant-information">
        <p><strong class="headx">Avoid Instructions:</strong>{{ this.plant.avoidInstructions }}</p>
      </div>
      <div class="plant-information" id="plantPic">
        <img strong class="headx"  :src="plant.imageUrl"/>
      </div>
    </div>
    <div class="actions">
      <button class ="grow" id="addtonew" type="button" v-on:click="addPlantToPlot()">
        Add to my newest plot
      </button>
    </div>
  </div>
</template>

<script>
import plantService from "../services/PlantService";

export default {
  name: "plant-detail",
  data() {
    return {
      plant: {
        name: "",
        plantId: 0,
        costPer25Seeds: 0,
        sowInstructions: "",
        spaceInstructions: "",
        harvestInstructions: "",
        compatiblePlants: "",
        avoidInstructions: "",
        imageUrl: "",
      },
    };
  },
  created() {
    plantService
      .getPlantByPlantId(this.$route.params.plantId)
      .then((response) => {
        this.plant = response.data;
      });
  },
  methods: {
    addPlantToPlot() {
      plantService
        .addPlantToNewestPlot(this.$route.params.plantId)
        .then((response) => {
          if (response.status === 202) {
            this.$router.push("/plot");
          }
        })
        .catch((error) => {
          console.error(error);
        });
    },
    displayPlantThumbnail() {
      this.srcString = `${this.imageUrl}`;
    },
  },
};
</script>

<style>

#all-plant-fields {
  display: flex;
  flex-direction: column;
  margin: 500px;
  margin-top:0px;
  margin-bottom:0px
  
}

.plant-information > p {
  background-color:olivedrab;
  display: flex;
 
  padding: 10px;
  white-space: initial;
}

#daname {
display: flex;
  align-items: center;
  justify-content: center;
  text-decoration: underline;
  color: #36BA53;
  text-decoration-color: #5C3E14; 
  font-size: 60px;
  }

#addtonew {
  width: 20%;
}

.headx {
  padding: 10px;
  margin: 10px;
  color: #5C3E14;
  border: solid 1px #5C3E14;
  background-color: #A4CC4E;
  text-align: center;
}
#plantPic{
  display:flex;
  justify-content: center;
  align-items: center;
}
</style>
