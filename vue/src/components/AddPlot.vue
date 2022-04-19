<template>
<<<<<<< HEAD
    <div>
       <form class="plotEnterForm">
            <h2>Add new plot:</h2>
            <label for="name">Plot Name:</label><br/>
            <input v-model="plot.plotName" name="name" type="text">
            <br/><br/>
            <label for="length">Length:</label><br/>
            <input v-model="plot.length" name="number" type="number" >
            <br/><br/>
            <label for="width">Width:</label><br/>
            <input v-model="plot.width" name="number" type="number" >
            <br/><br/>
            <label for="sun">Hours of Sun Exposure:</label><br/>
            <input v-model="plot.sunExposure" type="number" >
            <br /><br/>
            <label for="zone">Zone:</label><br/>
            <input v-model="plot.zone" type="number">
            <!-- <br/><br/>
            <label for="color">What color would you like your plot?</label><br/>
            <input v-model="plotColor" name="color" type="color">
            <br/><br/> -->
            <button type="submit" v-on:click="savePlot()">Submit</button>
        </form> 
    </div>
</template>

<script>
import PlotService from '../services/PlotService';

export default {
    name: 'add-plot',
    data() {
        return {
            plot: {
                'plotId': Math.floor(Math.random() * (1000 - 100) + 100),
                'plotName': '',
                'length': 2,
                'width': 2,
                'sunExposure': 2,
                'zone': 2,
                'userId': 0 
            }
        };
    },
    methods: {
        savePlot() {
            PlotService
            .savePlotToLoggedInUser(this.plot)
            // .then(response => {
            //     if (response.data === 201) {
            //         this.$router.push("/plot");
            //     }
         //   })
            .catch(error => {
                console.error(error);
            })
        }
    }
};

</script>

<style></style>
=======
<div>
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
        .create(this.plot)
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

>>>>>>> 75c58319ccbd5719ce754f7d444d2b4e90887421
