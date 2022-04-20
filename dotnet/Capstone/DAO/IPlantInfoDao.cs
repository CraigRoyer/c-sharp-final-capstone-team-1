using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPlantInfoDao
    {
        PlantInfo GetPlantInfo(string plantName); //Not sure if using, reads from csv
        Dictionary<string, PlantInfo> GetAllPlantInfos(); //takes csv file, makes dictionary
        void AddAllPlantInfosFromCsvToDatabase(PlantInfo newPlantInfo); //creates db enteries for each PlantInfo in cvs file



        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //----Below, user can get or add plant via existing database----------



        void UserAddPlantToTheirOwnAccount(string plantName, int userId);
        List<PlantInfo> GetAllUsersPlantsFromDatabase(int userId);


    }
}
