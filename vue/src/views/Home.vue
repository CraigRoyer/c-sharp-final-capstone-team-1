<template>
 <div class="home">
    <h1>My Plot</h1>
    <create-plot/>

    <h1>My Top Garden Plot</h1>
    <plot-detail v-bind:plotId='$route.params.plotId'/>

    <h2> Create New Plot </h2>
      <router-link :to="{ name: 'CreatePlot' }"
      >Create New Plot</router-link>

  </div>
</template>

<script>


import PlotDetail from '../components/PlotDetail.vue';

export default {
  components: {
    PlotDetail,
  }

};
</script>

<style scoped>

</style>