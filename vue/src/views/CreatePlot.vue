<template>
  <div>
    <h1 id="createplots" class="pulse">Create Plot</h1>
    <create-plot />
  </div>
</template>


<script>
import CreatePlot from '../components/CreatePlot.vue';

export default {
  components: {
    CreatePlot
  }
};
</script>

<style scoped>
#createplots {
display: flex;
  align-items: center;
  justify-content: center;
  text-decoration: underline;
  color: #36BA53;
  text-decoration-color: #5C3E14; 
  font-size: 60px;
  }





</style>

