<template>
<div>
      <form v-on:submit.prevent>
          <div class="field">
            <label for="plotName">Plot Name:</label>
            <input type="text" v-model="plot.PlotName" />
            </div>
            <div class="field">
            <label for="length">Length:</label>
            <input type="number" v-model="plot.Length" />
            </div>
            <div class = "field">
            <label for="width">Width:</label>
            <input type="number" v-model="plot.Width" />
            </div>
            <div class="field">
            <label for="sunExposure">Hours of Sun Exposure:</label>
            <input type="number" v-model="plot.SunExposure" />
            </div>
            <div class ="field">
            <label for="zone">Zone:</label>
            <input type="number" v-model="plot.Zone" />
            </div>
    <div class="actions">
      <button type="button" v-on:click="cancel()">Cancel</button>&nbsp;
      <button type="submit" v-on:click="savePlot()">Save Plot</button>
    </div>
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
        PlotName: "",
        Length: 0,
        Width: 0,
        SunExposure: 0,
        Zone: 0,
      },
    };
  },
  methods: {
    saveDocument() {
      this.plot.Length = parseInt(this.plot.Length);
      this.plot.Width = parseInt(this.plot.Width);
      this.plot.SunExposure = parseInt(this.plot.SunExposure);
      this.plot.Zone = parseInt(this.plot.Zone);
      PlotService.create(this.plot)
        .then((response) => {
          if (response.status === 201) {
            this.$router.push("/");
          }
        })
        .catch((error) => {
          console.error(error);
        });
    },
    cancel() {
      this.$router.push("/");
    },
  },
};
</script>

<style scoped>
</style>