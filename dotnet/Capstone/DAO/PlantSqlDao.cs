using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class PlantSqlDao : IPlantDao
    {

        private readonly string connectionString;

        public PlantSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Plant GetPlantByPlantId(int plantId)
        {
            Plant returnPlant = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT *" +
                                                    " FROM plants WHERE plant_id = @plant_id;", conn);
                    cmd.Parameters.AddWithValue("@plant_id", plantId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnPlant = GetPlantFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnPlant;
        }

        public Plant AddPlantNotInDatabase(Plant newPlant)
        {
            int newPlantId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO plants (plant_name, cost_per_25_seeds, sow_instructions, space_instructions, harvest_instructions, compatible_plants, avoid_instructions, img_url) " +
                                                    "OUTPUT INSERTED.plant_id " +
                                                    "VALUES(@plant_name, @cost_per_25_seeds, @sow_instructions, @space_instructions, @harvest_instructions, @compatible_plants, @avoid_instructions, @img_url)", conn);
                    cmd.Parameters.AddWithValue("@plant_name", newPlant.Name);
                    cmd.Parameters.AddWithValue("@cost_per_25_seeds", newPlant.CostPer25Seeds);
                    cmd.Parameters.AddWithValue("@sow_instructions", newPlant.SowInstructions);
                    cmd.Parameters.AddWithValue("@space_instructions", newPlant.SpaceInstructions);
                    cmd.Parameters.AddWithValue("@harvest_instructions", newPlant.HarvestInstructions);
                    cmd.Parameters.AddWithValue("@compatible_plants", newPlant.CompatiblePlants);
                    cmd.Parameters.AddWithValue("@avoid_instructions", newPlant.AvoidInstructions);
                    cmd.Parameters.AddWithValue("@img_url", newPlant.ImageUrl);


                    newPlantId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return GetPlantByPlantId(newPlantId);
        }

        public List<Plant> ListPlantsByUserId(int userId)
        {
            List<Plant> plants = new List<Plant>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT plant_name
                                                        FROM plants 
                                                        JOIN plants_users ON plants.plant_id = plants_users.plant_id
                                                        JOIN users ON users.user_id = plants_users.user_id
                                                        WHERE users.user_id = @user_id", conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        Plant plant = GetPlantFromReader(reader);
                        plants.Add(plant);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                return plants;
            }

        }
        public List<Plant> ListPlantsByPlotId(int plotId)
        {
            List<Plant> plants = new List<Plant>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT *
                                                        FROM plants 
                                                        JOIN plot_plants ON plants.plant_id = plot_plants.plant_id
                                                        JOIN plot ON plot.plot_id_number = plot_plants.plot_id_number
                                                        WHERE plot.plot_id_number = @plot_id_number", conn);
                cmd.Parameters.AddWithValue("@plot_id_number", plotId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        Plant plant = GetPlantFromReader(reader);
                        plants.Add(plant);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                return plants;
            }

        }
        public List<Plant> ListAllPlants()
        {
            List<Plant> plants = new List<Plant>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT *
                                                FROM plants", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        Plant plant = GetPlantFromReader(reader);
                        plants.Add(plant);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                return plants;
            }

        }
        public Plant AddPlantToNewestPlot(int plantId, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO plot_plants VALUES(@plant_id, (SELECT TOP 1 plot_id_number FROM plot WHERE user_id = @user_id ORDER BY plot_id_number DESC))", conn);
                    cmd.Parameters.AddWithValue("@plant_id", plantId);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return GetPlantByPlantId(plantId);
        }

        private Plant GetPlantFromReader(SqlDataReader reader)
        {
            Plant p = new Plant()
            {
                PlantId = Convert.ToInt32(reader["plant_id"]),
                Name = Convert.ToString(reader["plant_name"]),
                SowInstructions = Convert.ToString(reader["sow_instructions"]),
                SpaceInstructions = Convert.ToString(reader["space_instructions"]),
                HarvestInstructions = Convert.ToString(reader["harvest_instructions"]),
                CompatiblePlants = Convert.ToString(reader["compatible_plants"]),
                AvoidInstructions = Convert.ToString(reader["avoid_instructions"]),
                ImageUrl = Convert.ToString(reader["img_url"])
            };
            if (reader["cost_per_25_seeds"] != DBNull.Value)
            {
                p.CostPer25Seeds = Convert.ToDecimal(reader["cost_per_25_seeds"]);
            }
            return p;
        }

    }
}


