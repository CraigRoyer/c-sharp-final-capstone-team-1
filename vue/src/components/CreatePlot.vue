<template>
   <div class="createNewPlot">
    <h1>Create a new plot:</h1>
    <form v-on:submit.prevent>
            <label for="name">Plot Name:</label><br/>
            <input v-model="plot.plotName" name="name" type="text">
            <br/><br/>
            <label for="length">Length:</label><br/>
            <input v-model="plot.lengths" name="number" type="number" min="1">
            <br/><br/>
            <label for="width">Width:</label><br/>
            <input v-model="plot.width" name="number" type="number" min="1">
            <br/><br/>
            <label for="sun">Hours of Sun Exposure:</label><br/>
            <input v-model="plot.sunExposure" type="number" min="1" max="24">
            <br /><br/>
            <label for="zone">Zone:</label><br/>
            <input v-model="plot.zoneInfo" type="number" min="1" max="10">
            <br/><br/>
            <label for="color">What color would you like your plot?</label><br/>
            <input v-model="plot.plotColor" name="color" type="color">
            <br/><br/>
            <button type="button" v-on:click="cancel()">Cancel</button>&nbsp;
            <button type="submit" v-on:click="saveDocument()">Submit</button>
        </form>
  </div> 
</template>

<script>
import PlotService from "../services/PlotService";

export default {
  name: "create-plot",
  data() {
    return {
      plot: {
          plotId:null,
          userId:null,
          lengths:null,
          width:null,
          sunExposure:null,
          zoneInfo:null,
          plotName:''
      }
    };
  },
  methods: {
    saveDocument() {
      PlotService
        .create(this.plot)
        .then(response => {
          if (response.status === 201) {
            this.$router.push("/");
          }
        })
        .catch(error => {
          console.error(error);
        });
    },
    cancel() {
      this.$router.push("/");
    }
  }
};
</script>

<style scoped>

</style>