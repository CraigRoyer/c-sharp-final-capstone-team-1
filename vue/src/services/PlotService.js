import axios from 'axios';

export default {
  getTopPlotOnLogin(){
   return axios.get(`/plot`);
  },
  // getPlot(plotId) {
  //   return axios.get(`/plot/${plotId}`);
  // },
  
  savePlotToLoggedInUser(plot) {
    return axios.post(`/plot/create`, plot);
  }
  
<<<<<<< HEAD
  // submitForm(){
  //   axios.post('/contact', this.form)
  //        .then((res) =>


  // create(plot) {
  //   return http.post(`/plot/create`, plot);
  // },

  // update(plotId, plot) {
  //   return http.put(`/plot/${plotId}`, plot);
  // },

  // delete(plotId) {
  //   return http.delete(`/plot/${plotId}`);
  // }
=======
  update(plotId, plot) {
    return axios.put(`/plot/${plotId}`, plot);
  },
>>>>>>> 75c58319ccbd5719ce754f7d444d2b4e90887421


  // update(plotId, plot) {
  //   return axios.put(`/plot/${plotId}`, plot);
  // },

  // delete(plotId) {
  //   return axios.delete(`/plot/${plotId}`);
  // }


//   getCards(boardID) {
//     return http.get(`/boards/${boardID}`)
//  we're gonna need this },

//   getCard(boardID, cardID) {
//     return http.get(`/boards/${boardID}`).then((response) => {
//       const cards = response.data.cards;
//       return cards.find(card => card.id == cardID);
//     })
//   }

}
