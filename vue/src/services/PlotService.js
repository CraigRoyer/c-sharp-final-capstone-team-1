import axios from 'axios';

export default {
  getTopPlotOnLogin(){
   return axios.get(`/plot`);
  },

  getPlot(plotId) {
    return axios.get(`/plot/${plotId}`);
  },

  getAllPlots() {
    return axios.get(`/plot/allplots`);
  },

  create(plot) {
    return axios.post(`/plot/create`, plot);
  },

  update(plotId, plot) {
    return axios.put(`/plot/${plotId}`, plot);
  },

  delete(plotId) {
    return axios.delete(`/plot/${plotId}`);
  },

  addPlantToPlot(plantId,plotId){
    return axios.post(`/plot/${plotId}/plant`)
  },
  
  getAllPlantsFromAPlot(plotId) {
    return axios.get(`/plot/${plotId}`)
  }

}
