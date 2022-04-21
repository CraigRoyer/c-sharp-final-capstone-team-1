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

                    SqlCommand cmd = new SqlCommand("SELECT plant_id, plant_name, cost_per_25_seeds" +
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

        public Plant AddPlant(Plant newPlant)
        {
            int newPlantId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO plants (plant_name, cost_per_25_seeds) " +
                                                    "OUTPUT INSERTED.plant_id" +
                                                    "VALUES(@plant_name)", conn);
                    cmd.Parameters.AddWithValue("@plant_name", newPlant.Name);
                    cmd.Parameters.AddWithValue("@cost_per_25_seeds", newPlant.CostPer25Seeds);
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

                SqlCommand cmd = new SqlCommand(@"SELECT plant_name
                                                        FROM plants 
                                                        JOIN plot_plants ON plants.plant_id = plot_plants.plant_id
                                                        JOIN plot ON plot.plot_id = plot_plants.plot_id
                                                        WHERE plot.plot_id = @plot_id", conn);
                cmd.Parameters.AddWithValue("@user_id", plotId);
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

        private Plant GetPlantFromReader(SqlDataReader reader)
        {
            Plant p = new Plant()
            {
                PlantId = Convert.ToInt32(reader["plant_id"]),
                Name = Convert.ToString(reader["plant_name"]),

            };
            if (reader["cost_per_25_seeds"] != DBNull.Value)
            {
                p.CostPer25Seeds = Convert.ToDecimal(reader["cost_per_25_seeds"]);
            }
            return p;
        }

    }
}


