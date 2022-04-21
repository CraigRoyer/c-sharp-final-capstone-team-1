<template>
  <div>
    <h1>Create Plot</h1>
    <add-plot class="create"/>
  </div>
</template>

<script>
import AddPlot from '../components/AddPlot.vue';

export default {
  components: {
    AddPlot
  }
};
</script>

<style scoped>
body > div > div{
  width: 500px;
  height: 500px;
  margin: auto;
  background: #af7804;
  border-radius: 98%;
  box-shadow: 5px 20px 50px #8e4505;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;  
}

body > div > div > div > form {
  display: flex;
  flex-direction: row-reverse;
  
}

body > div > div > div {
  
}



</style>
