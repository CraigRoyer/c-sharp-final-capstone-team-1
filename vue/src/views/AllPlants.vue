<template>
  <div id="allplants">
    <h1 id="plants" class="pulse">Plants</h1>
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
  align-items: center;
  justify-content: center;
  text-decoration: underline;
  color: #36BA53;
  text-decoration-color: #5C3E14; 
  font-size: 60px;
}
</style>
