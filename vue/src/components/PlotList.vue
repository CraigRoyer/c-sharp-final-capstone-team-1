<template>
  <table>
    <thead>
      <tr>
        <th>&nbsp;</th>
        
      </tr>
    </thead>
    <tbody>
      <tr v-for="plot in plots" :key="plot.plotId" v-on:click="getPlot(plot.plotId)">
        <td class="PlotName">Plot Name: {{ plot.plotName }}</td>
        <td class="PlotId">Plot Id: {{ plot.plotId }}</td>
        <td class="PlotZone">Plot Zone: {{ plot.zone }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import plotService from "../services/PlotService";

export default {
  name: "plot-list",
  data() {
    return {
      plots: []
    };
  },
  methods: {
    getPlot(plotId) {
      this.$router.push(`/plot/${plotId}`);
    }
  },
  created() {
    plotService.getAllPlots().then((response) => {
      this.plots = response.data;
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