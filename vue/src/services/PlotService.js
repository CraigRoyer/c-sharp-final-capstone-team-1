import axios from 'axios';

export default {
getTopPlotOnLogin(){
   return axios.get(`/plot`);
  },
  getPlot(plotId) {
    return axios.get(`/plot/${plotId}`);
  },
  
  create(plot) {
    return axios.post(`/plot/create`, plot);
  },

  update(plotId, plot) {
    return axios.put(`/plot/${plotId}`, plot);
  },

  delete(plotId) {
    return axios.delete(`/plot/${plotId}`);
  }


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
