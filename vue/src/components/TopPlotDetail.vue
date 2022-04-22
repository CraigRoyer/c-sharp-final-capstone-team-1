<template>
<div class="topPlot">
  <p>🏵️</p>
  <h2>Plot Name: {{plot.plotName}}</h2>&nbsp;
  <p>🏵️</p>
    <p> Plot Length: {{plot.length}} feet</p>&nbsp;
    <p>🏵️</p>
    <p> Plot Width: {{plot.width}} feet</p>&nbsp;
    <p>🏵️</p>
    <p> Sun Exposure: {{plot.sunExposure}} hours</p>&nbsp;
    <p>🏵️</p>
    <p> Zone: {{plot.zone}} </p>
    <p>🏵️</p>
</div>
</template>

<script>
import plotService from '../services/PlotService';

export default {
  name: 'top-plot-detail',
  data() {
    return {
      plot: {
         PlotName:'',
        Length:0,
        Width:0,
        SunExposure:0,
        Zone:0,
        PlotId:0,
        UserId:0,
      }
    };
  },
  created() {
      plotService.getTopPlotOnLogin().then((response) => {
          this.plot = response.data;
          
      });
  }
};
</script>

<style scoped>

#flora {
 width: 50px;
 height: auto; 
}
</style>