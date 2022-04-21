<template>
  <div id="allplants">
    <h1 id="plants">Plants</h1>
    <plant-list />
  </div>
</template>

<script>
import PlantList from "@/components/PlantList";

export default {
  components: {
    PlantList
  }
};
</script>

<style scoped>

#plants {
  display: flex;
  margin-left: 5px;
  padding-left: 120px;
}
</style>
