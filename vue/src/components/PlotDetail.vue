<template>
<div>
    <h1> This Plot </h1>
    <p> {{plot}}</p>
</div>
</template>

<script>
import plotService from '../services/PlotService';

export default {
  name: 'plot-detail',
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