<template>
  <div>
    <h1>Plot Detail</h1>
    <plot-detail v-bind:plotId='$route.params.plotId'/>
  </div>
</template>

<script>
import PlotDetail from '../components/PlotDetail.vue';

export default {
  components: {
    PlotDetail
  },
methods: {
    addNewForm() {
      this.plots.unshift(this.newPlot);
      this.resetForm();
    },
    resetForm() {
      this.newPlot = {};
      this.showForm = false; 
    }
  }
}
</script>
