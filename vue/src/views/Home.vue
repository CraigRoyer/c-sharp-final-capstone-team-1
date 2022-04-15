<template>
  <div class ="home">
    <h1>Plot Detail</h1>
    <plot-detail v-bind:plotId='$route.params.plotId'/>
    <form>
            <h2>Add new plot:</h2>
            <label for="name">Plot Name:</label><br/>
            <input v-model="plotName" name="name" type="text">
            <br/><br/>
            <label for="length">Length:</label><br/>
            <input v-model="length" name="number" type="number" min="1">
            <br/><br/>
            <label for="width">Width:</label><br/>
            <input v-model="width" name="number" type="number" min="1">
            <br/><br/>
            <label for="sun">Hours of Sun Exposure:</label><br/>
            <input v-model="sunExposure" type="number" min="1" max="24">
            <br /><br/>
            <label for="zone">Zone:</label><br/>
            <input v-model="zoneInfo" type="number" min="1" max="10">
            <br/><br/>
            <label for="color">What color would you like your plot?</label><br/>
            <input v-model="plotColor" name="color" type="color">
            <br/><br/>
            <button>Submit</button>
        </form>
  </div>
</template>

<script>
import PlotDetail from '../components/PlotDetail.vue';

export default {
  components: {
    PlotDetail
  }
};
</script>
