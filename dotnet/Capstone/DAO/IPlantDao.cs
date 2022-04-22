using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IPlantDao
    {
        Plant GetPlantByPlantId(int plantId);
        //Plant AddPlant(Plant plant);
        List<Plant> ListPlantsByUserId(int userId);  
        List<Plant> ListPlantsByPlotId(int plotId);

        List<Plant> ListAllPlants();
        Plant AddPlantNotInDatabase(Plant newPlant);

        Plant AddPlantToNewestPlot(int plantId, int userId);


    }
}
