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
          userId:null,
          length:null,
          width:null,
          sunExposure:null,
          zone:null,
          plotId:null,
          plotName:''
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