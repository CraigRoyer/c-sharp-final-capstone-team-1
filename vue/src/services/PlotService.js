import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:3000"
});

export default {

  getPlot(plotId) {
    return http.get(`https://localhost:44315/plot/${plotId}`);
  },

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
