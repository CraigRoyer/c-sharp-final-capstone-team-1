<template>
  <table id="tablePlot">
    <thead>
      <tr>
        <th>&nbsp;</th>
        
      </tr>
    </thead>
    <tbody>
      <tr v-for="plot in plots" :key="plot.plotId" v-on:click="getPlot(plot.plotId)">
        <td class="PlotName">Plot Name: {{ plot.plotName }}</td>
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

#tablePlot {
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
