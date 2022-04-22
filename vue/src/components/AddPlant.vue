<template>
<div id="laforma">
      <form v-on:submit.prevent>
          <div class="field">
            <label for="plotName">Plant Name:</label>
            <input type="text" v-model="plant.name" />
            </div>
            <div class="field">
            <label for="costPer25Seeds">Cost Per 25 Seeds:</label>
            <input type="number" v-model="plant.costPer25Seeds" />
            </div>
             <div class="field">
            <label for="sowInstructions">Sow Instructions:</label>
            <input type="text" v-model="plant.sowInstructions" />
            </div>
             <div class="field">
            <label for="spaceInstructions">Space Instructions:</label>
            <input type="text" v-model="plant.spaceInstructions" />
            </div>
             <div class="field">
            <label for="harvestInstructions">Harvest Instructions:</label>
            <input type="text" v-model="plant.harvestInstructions" />
            </div>
             <div class="field">
            <label for="compatiblePlants">Compatible Plants:</label>
            <input type="text" v-model="plant.compatiblePlants" />
            </div>
             <div class="field">
            <label for="avoidInstructions">Avoid Instructions:</label>
            <input type="text" v-model="plant.avoidInstructions" />
           </div>
    <div class="actions">
      <button type="button" v-on:click="cancel()">Cancel</button>&nbsp;
      <button type="submit" v-on:click="savePlant()">Add Plant</button>
    </div>
        </form>
        </div>
</template>

<script>
import plantService from "../services/PlantService";

export default {
  name: "add-plot",
  data() {
    return {
      plant: {
        name:'',
        costPer25Seeds:0,
       sowInstructions:'',
       spaceInstructions:'',
       harvestInstructions:'',
       compatiblePlants:'',
       avoidInstructions:'',
       // UserId:0,
        
      }
    };
  },
  methods: {
    savePlant() {
      this.plant.costPer25Seeds = parseInt(this.plant.costPer25Seeds);
      plantService
        .create(this.plant)
        .then(response => {
          if (response.status === 201) {
            console.log(this.plant)
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
      this.$router.push("/plant/all");
    }
  }
};
</script>

<style scoped>
#laforma {
  width: 400px;
  height: 400px;
  margin: auto;
  background: #af7804;
  border-radius: 98%;
  box-shadow: 5px 20px 50px #8e4505;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

#laforma > form {
  width: 300px;
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
  height: 10px;
  background: #e0dede;
  justify-content: center;
  display: flex;
  margin: 5px auto;
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
  font-size: 2.0rem;
  margin: 0;
  color: #5C3E14;
}
</style>
