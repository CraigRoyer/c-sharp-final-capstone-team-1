import axios from 'axios';

export default {
  listPlantsByUserId() {
    return axios.get(`/plant`);
  },
  listAllPlants(){
      return axios.get(`/all`);
  },
  create(plant) {
    return axios.post(`/plant/create`, plant);
  },
  
  update(plantId, plant) {
    return axios.put(`/plot/${plantId}`, plant);
  },

  delete(plantId) {
    return axios.delete(`/plant/${plantId}`);
  }



}