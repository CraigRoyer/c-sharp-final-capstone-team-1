<template>
  <table>
    <thead>
      <tr>
        <th>&nbsp;</th>
        <th>My Plots</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="plot in plots" :key="plot.plotId" v-on:click="getPlot(plot.plotId)">
        <td class="PlotName">{{ plot.plotName }} Test</td>
        <td class="PlotId">{{ plot.plotId }}Plot Id</td>
        <td class="PlotZone">{{ plot.zone }} Zone</td>
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