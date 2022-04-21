<template>
<div>
    <h1> {{this.plot.plotName}} </h1>
    <p> {{this.plot}}</p>

</div>
</template>

<script>
import plotService from '../services/PlotService';

export default {
  name: 'plot-detail',
  data() {
    return {
      plot: {
        plotName:'',
        length:0,
        width:0,
        sunExposure:0,
        zone:0,
        plotId:0,
        userId:0,
      }
    };
  },
  created() {
      plotService.getPlot(this.$route.params.plotId).then((response) => {
          this.plot = response.data;
          
      });
  }
};
</script>