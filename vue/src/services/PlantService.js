import axios from 'axios';

export default {
  listPlantsByUserId() {
    return axios.get(`/plant`);
  },
  getPlantByPlantId(plantId) {
      return axios.get(`/plant/${plantId}`)
  },
  listAllPlants(){
      return axios.get(`plant/all`);
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