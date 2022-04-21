<template>
  <div>
    <h1 id="allPlots">My Plots</h1>
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
  margin-left: 5px;
  padding-left: 120px;
}
</style>