<template>
  <div class ="home">
    <h1>Plot Detail</h1>
    <plot-detail v-bind:plotId='$route.params.plotId'/>
    <!-- <add-plot-form v-bind:plotId='$route.params.plotId'>YOOOO</add-plot-form>> -->
    <add-plot></add-plot>
  </div>
</template>

<script>
import PlotDetail from '../components/PlotDetail';
import AddPlot from '../components/AddPlot';

export default {
  components: {
    PlotDetail,
    AddPlot
  }
};
</script>
