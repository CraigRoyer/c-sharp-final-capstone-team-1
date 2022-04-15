<template>
 <div class="home">
    <h1>My Plot</h1>
    <create-plot/>
  </div>
</template>

<script>
import CreatePlot from '../components/CreatePlot.vue';

export default {
  name: "home",
  components: {
    CreatePlot
  }
};
</script>
