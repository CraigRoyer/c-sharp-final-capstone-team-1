<template>
  <div>
    <plant-detail v-bind:plantId='$route.params.plantId' />
  </div>
</template>

<script>
import PlantDetail from '../components/PlantDetail.vue';

export default {
  components: {
    PlantDetail
  }
};
</script>

<style>
</style>