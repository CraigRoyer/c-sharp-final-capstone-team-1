<template>
<div>
      <form id="formy" v-on:submit.prevent>
          <div class="field">
            <label for="plotName">Plot Name:</label>
            <input type="text" v-model="plot.PlotName" />
            </div>
            <div class="field">
            <label for="length">Length:</label>
            <input type="number" v-model="plot.Length" />
            </div>
            <div class = "field">
            <label for="width">Width:</label>
            <input type="number" v-model="plot.Width" />
            </div>
            <div class="field">
            <label for="sunExposure">Hours of Sun Exposure:</label>
            <input type="number" v-model="plot.SunExposure" />
            </div>
            <div class ="field">
            <label for="zone">Zone:</label>
            <input type="number" v-model="plot.Zone" />
            </div>
    <div class="actions">
      <button type="button" v-on:click="cancel()">Cancel</button>&nbsp;
      <button type="submit" v-on:click="savePlot()">Save Plot</button>
    </div>
        </form>
        </div>
</template>

<script>
import PlotService from "../services/PlotService";

export default {
  name: "add-plot",
  data() {
    return {
      plot: {
        PlotName:'',
        Length:0,
        Width:0,
        SunExposure:0,
        Zone:0,
       // PlotId:0,
       // UserId:0,
        
      }
    };
  },
  methods: {
    savePlot() {
      this.plot.Length = parseInt(this.plot.Length);
      this.plot.Width = parseInt(this.plot.Width);
      this.plot.SunExposure = parseInt(this.plot.SunExposure);
      this.plot.Zone = parseInt(this.plot.Zone);
      PlotService
        .savePlotToLoggedInUser(this.plot)
        .then(response => {
          if (response.status === 201) {
            console.log(this.plot)
            this.$router.push("/plot");
          }
        })
       .catch((error) => {
          if (error.response) {
            this.errorMsg =
              "Error adding Profile Information. Response received was '" +
              error.response.statusText +
              "'.";
          } else if (error.request) {
            this.errorMsg = "Error adding Profile Information. Server could not be reached.";
          } else {
            this.errorMsg = "Error adding Profile Information. Request could not be created.";
          }
        });

    },
    cancel() {
      this.$router.push("/plot");
    }
  }
};
</script>


<style>

#formy { 
  display: flex;
  flex-direction: column;
  justify-content: flex-end;
  align-items: flex-end;
}

button {
  width: 100%;
  height: 30px;
  justify-content: center;
  display: block;
  color: #fff;
  background: #d1965e;
  font-size: 1em;
  font-weight: bold;
  margin-top: 8px;
  outline: none;
  border: none;
  border-radius: 5px;
  transition: 0.2s ease-in;
  cursor: pointer;

}

button:hover {
  background: #5c3e14;
  transform: scale(1.3); 

}

.actions { 
transition: all .6s ease-in-out; 
}




</style>
