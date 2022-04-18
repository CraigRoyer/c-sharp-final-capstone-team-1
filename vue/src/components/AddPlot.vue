<template>
      <form v-on:submit.prevent>
          <div class="field">
            <label for="plotName">Plot Name:</label>
            <input type="text" v-model="plot.plotName" />
            </div>
            <div class="field">
            <label for="length">Length:</label>
            <input type="number" min="1" v-model="plot.length" />
            </div>
            <div class = "field">
            <label for="width">Width:</label>
            <input  type="number" min="1" v-model="plot.width" />
            </div>
            <div class="field">
            <label for="sunExposure">Hours of Sun Exposure:</label>
            <input  type="number" min="1" max="24" v-model="plot.sunExposure" />
            </div>
            <div class ="field">
            <label for="zone">Zone:</label>
            <input type="number" min="1" max="10" v-model="plot.zone" />
            </div>
    <div class="actions">
      <button type="button" v-on:click="cancel()">Cancel</button>&nbsp;
      <button type="submit" v-on:click="savePlot()">Save Plot</button>
    </div>
        </form>
</template>

<script>
import PlotService from "../services/PlotService";

export default {
  name: "add-plot",
  data() {
    return {
      plot: {
        //userId:0,//what should this be
        length:null,
        width:null,
        sunExposure:null,
        zone:null,
        //plotId:0,//maybe not here
        plotName:''
      }
    };
  },
  methods: {
    savePlot() {
      PlotService
        .create(this.plot)
        .then(response => {
          if (response.status === 201) {
            this.$router.push("/plot");
          }
        })
        .catch(error => {
          console.error(error);
        });
    },
    cancel() {
      this.$router.push("/plot");
    }
  }
};
</script>