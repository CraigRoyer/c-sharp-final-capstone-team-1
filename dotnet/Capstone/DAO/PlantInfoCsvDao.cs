using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PlantInfoCsvDao : IPlantInfoDao //----update interface with missing method names
    {
        Dictionary<string, PlantInfo> plantDictionary = new Dictionary<string, PlantInfo>();
        public Dictionary<string, PlantInfo> GetAllPlantInfos()
        {
            //read from csv file 
            string fileDirectory = @"C:\Users\Student\git\c-sharp-final-capstone-team-1\dotnet\Capstone";
            string fileNameClean = "plantInfo-raw.csv";

            string fullPath = Path.Combine(fileDirectory, fileNameClean);

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    string headerLine = sr.ReadLine(); //skips header line?
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] plantInfoAll = line.Split(",");

                        PlantInfo plant = new PlantInfo(plantInfoAll[0], plantInfoAll[1], plantInfoAll[2], plantInfoAll[3], plantInfoAll[4], plantInfoAll[5], plantInfoAll[8]); //map strings to PlantInfo Model
                        plantDictionary[plantInfoAll[0]] = plant; //Adds each plant to dictionary with plant name as key
                    }
                }
            }
            catch (IOException)
            {

                throw;
            }

            return plantDictionary; //return models 
        }

        public PlantInfo GetPlantInfo(string plantName)
        {
            GetAllPlantInfos(); //need to run previous method to update empty dictionary

            if (plantDictionary.TryGetValue(plantName, out PlantInfo value))
            {
                return value;
            }
            else return null; //else ask to add to dicationary on entered search term via new method??

        }

        private readonly string connectionString;

        public PlantInfoCsvDao (string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public void AddAllPlantInfosFromCsvToDatabase() //don't know how to excecute yet == add exclusive button for admin user??
        {
            GetAllPlantInfos();
            foreach (KeyValuePair<string, PlantInfo> entry in plantDictionary)
            {
                int newPlantId;
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO plants (plant_name, sow_instructions, space_instructions, harvest_instructions, compatible_plants, avoid_instructions, img_url) " +
                                                        "OUTPUT INSERTED.plant_id " +
                                                        "VALUES(@plant_name, @sow_instructions, @space_instructions, @harvest_instructions, @compatible_plants, @avoid_instructions, @img_url)", conn);
                        cmd.Parameters.AddWithValue("@plant_name", entry.Value.Name);
                        cmd.Parameters.AddWithValue("@sow_instructions", entry.Value.SowInstructions);
                        cmd.Parameters.AddWithValue("@space_instructions", entry.Value.SpaceInstructions);
                        cmd.Parameters.AddWithValue("@harvest_instructions", entry.Value.HavestInstructions);
                        cmd.Parameters.AddWithValue("@compatible_plants", entry.Value.CompatiblePlants);
                        cmd.Parameters.AddWithValue("@avoid_instructions", entry.Value.AvoidInstructions);
                        cmd.Parameters.AddWithValue("@img_url", entry.Value.ImageUrl);

                        newPlantId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        //------------------------------------------------------------- Above: Getting plant info off csv and into db
        //-------------------------------------------------------------
        //------------------------------------------------------------- Below: User get's their plants can add plants to their account 

        public void UserAddPlantToTheirOwnAccount(string plantName, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) 
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO plants_users (plant_id, user_id) " +
                                                    "SELECT plants_users.plant_id, plants_users.user_id " +
                                                    "FROM plants_users " +
                                                    "JOIN plants ON plants_users.plant_id = plants.plant_id " +
                                                    "JOIN users ON users.user_id = plants_users.user_id " +
                                                    "WHERE plants.plant_name = @plants.plant_name AND users.user_id = @users.user_id;", conn);
                    cmd.Parameters.AddWithValue("@plants.plant_name", plantName);
                    cmd.Parameters.AddWithValue("@users.user_id", userId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public List<PlantInfo> GetAllUsersPlantsFromDatabase(int userId)
        {
            List<PlantInfo> listOfLoggedInUsersPlants = new List<PlantInfo>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("SELECT plant_name, sow_instructions, space_instructions, harvest_instructions, compatible_plants, avoid_instructions, img_url " +
                                                        "FROM plants " +
                                                        "JOIN plants_users ON plants_users.plant_id = plants.plant_id " +
                                                        "JOIN users ON users.user_id = plants_users.user_id" +
                                                        " WHERE users.user_id = @users.user_id;", conn);
                    command.Parameters.AddWithValue("@users.user_id", userId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        PlantInfo plantInfo = GetPlantInfoFromReader(reader);
                        listOfLoggedInUsersPlants.Add(plantInfo);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listOfLoggedInUsersPlants;
        }

        //method to add to dictionary if doesn't already exist
        //method to write to new csv?? vs using database??

        private PlantInfo GetPlantInfoFromReader(SqlDataReader reader)

        {
            PlantInfo u = new PlantInfo() //-----???????????

            {
                Name = Convert.ToString(reader["plant_name"]),
                SowInstructions = Convert.ToString(reader["sow_instructions"]),
                SpaceInstructions = Convert.ToString(reader["space_instructions"]),
                HavestInstructions = Convert.ToString(reader["harvest_instructions"]),
                CompatiblePlants = Convert.ToString(reader["compatible_plants"]),
                AvoidInstructions = Convert.ToString(reader["avoid_instructions"]),
                ImageUrl = Convert.ToString(reader["img_url"])
            };

            return u;
        }
    }
}
