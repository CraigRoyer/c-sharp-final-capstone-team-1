<template>
<div>
      <form v-on:submit.prevent>
          <div class="field">
            <label for="plotName">Plant Name:</label>
            <input type="text" v-model="plant.name" />
            </div>
            <div class="field">
            <label for="length">Length:</label>
            <input type="number" v-model="plant.costPer25Seeds" />
            </div>
    <div class="actions">
      <button type="button" v-on:click="cancel()">Cancel</button>&nbsp;
      <button type="submit" v-on:click="savePlant()">Add Plant</button>
    </div>
        </form>
        </div>
</template>

<script>
import plantService from "../services/PlantService";

export default {
  name: "add-plot",
  data() {
    return {
      plant: {
        name:'',
        costPer25Seeds:0,
       // PlotId:0,
       // UserId:0,
        
      }
    };
  },
  methods: {
    savePlant() {
      this.plant.costPer25Seeds = parseInt(this.plant.costPer25Seeds);
      plantService
        .create(this.plant)
        .then(response => {
          if (response.status === 201) {
            console.log(this.plant)
            this.$router.push("/plant/:plantId");
          }
        })
       .catch((error) => {
          if (error.response) {
            this.errorMsg =
              "Error adding Profile Information. Response received was '" +
              error.response.statusText +
              "'.";
          } else if (error.request) {
            this.errorMsg = "Error adding Profile Information. Server could not be reached.";
          } else {
            this.errorMsg = "Error adding Profile Information. Request could not be created.";
          }
        });

    },
    cancel() {
      this.$router.push("/plant/all");
    }
  }
};
</script>

