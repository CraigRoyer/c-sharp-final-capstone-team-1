<template>
  <div>
    <h1 id="allPlots" class="pulse">My Plots</h1>
    <plot-list />
  </div>
</template>


<script>
import PlotList from "@/components/PlotList";

export default {
  components: {
    PlotList
  }
};
</script>

<style scoped>
#allPlots {
  display: flex;
  align-items: center;
  justify-content: center;
  text-decoration: underline;
  color: #36BA53;
  text-decoration-color: #5C3E14; 
  font-size: 60px;
}
</style>
