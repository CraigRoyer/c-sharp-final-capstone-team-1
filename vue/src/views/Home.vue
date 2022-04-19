<template>
  <div class ="home">
    <h1>My Top Garden Plot</h1>
    <plot-detail v-bind:plotId='$route.params.plotId'/>
<<<<<<< HEAD
    <!-- <add-plot-form v-bind:plotId='$route.params.plotId'>YOOOO</add-plot-form>> -->
    <add-plot></add-plot>
=======

    <h2> Create New Plot </h2>
      <router-link :to="{ name: 'CreatePlot' }"
      >Create New Plot</router-link>

>>>>>>> 75c58319ccbd5719ce754f7d444d2b4e90887421
  </div>
</template>

<script>
import PlotDetail from '../components/PlotDetail';
import AddPlot from '../components/AddPlot';

export default {
  components: {
    PlotDetail,
<<<<<<< HEAD
    AddPlot
=======
>>>>>>> 75c58319ccbd5719ce754f7d444d2b4e90887421
  }
};
</script>
