<template>
<div id="wholeField">
      <form v-on:submit.prevent>
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
  name: "create-plot",
  data() {
    return {
      plot: {
        PlotName: "",
        Length: 0,
        Width: 0,
        SunExposure: 0,
        Zone: 0,
      },
    };
  },
  methods: {
    savePlot() {
      this.plot.Length = parseInt(this.plot.Length);
      this.plot.Width = parseInt(this.plot.Width);
      this.plot.SunExposure = parseInt(this.plot.SunExposure);
      this.plot.Zone = parseInt(this.plot.Zone);
      PlotService.create(this.plot)
        .then((response) => {
          if (response.status === 201) {
            this.$router.push("/plot");
          }
        })
        .catch((error) => {
          console.error(error);
        });
    },
    cancel() {
      this.$router.push("/plot");
    },
  },
};
</script>






<style scoped>

#wholeField {
  width: 800px;
  height: 800px;
  margin: auto;
  background: #af7804;
  border-radius: 98%;
  box-shadow: 5px 20px 50px #8e4505;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

#wholeField > form {
  width: 300px;
  height: 600px;
}
label {
  color: #fff;
  font-size: 3rem;
  justify-content: center;
  display: flex;
  margin: 30px;
  font-weight: bold;
  transition: 0.5s ease-in-out;
}
/* .field {
  width: 10px;
  height: 10px;
} */

/* #wholeField > form > label:nth-child(5)
{
	font-size: 1.0rem;
	color: rgb(38, 180, 38);
	
} */
input {
  width: 100%;
  height: 20px;
  background: #e0dede;
  justify-content: center;
  display: flex;
  margin: 20px auto;
  padding: 10px;
  border: none;
  outline: none;
  border-radius: 5px;
}
button {
  width: 40%;
  height: 40px;
  margin: 10px auto;
  justify-content: center;
  display: block;
  color: #fff;
  background: #d1965e;
  font-size: 1em;
  font-weight: bold;
  margin-top: 20px;
  outline: none;
  border: none;
  border-radius: 5px;
  transition: 0.2s ease-in;
  cursor: pointer;
}
button:hover {
  background: #5c3e14;
  
}
.login label {
  color: #5c3e14;
}
.grow { 
transition: all .6s ease-in-out; 
}

.grow:hover { 
transform: scale(1.3); 
}

label {
  font-size: 1.2rem;
  margin: -10px;
  color: #5C3E14;
}



</style>
