<template>
  <div>
    <h1 id="createplant" class="pulse">Create Plant</h1>
    <add-plant />
  </div>
</template>

<script>
import AddPlant from '../components/AddPlant.vue';

export default {
  components: {
    AddPlant
  }
};
</script>

<style scoped>

#createplant {
display: flex;
  align-items: top;
  
  text-decoration: underline;
  color: #36BA53;
  text-decoration-color: #5C3E14; 
  font-size: 60px;
  }

</style>

