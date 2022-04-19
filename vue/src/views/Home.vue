<template>
 <div class="home">
    <h1>My Plot</h1>
    <create-plot/>

  <div class ="home">
    <h1>Plot Detail</h1>
    <plot-detail v-bind:plotId='$route.params.plotId'/>
    <add-plot></add-plot>
  </div>
</template>

<script>


import PlotDetail from '../components/PlotDetail.vue';

export default {
  components: {
    PlotDetail
  }

};
</script>
