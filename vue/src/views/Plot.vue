<template>
  <div>
    <plot-detail v-bind:plotId='$route.params.plotId'/>
  </div>
</template>

<script>
import PlotDetail from '../components/PlotDetail.vue';

export default {
  components: {
    PlotDetail
  },

};
</script>
