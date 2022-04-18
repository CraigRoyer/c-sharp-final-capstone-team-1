<template>
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