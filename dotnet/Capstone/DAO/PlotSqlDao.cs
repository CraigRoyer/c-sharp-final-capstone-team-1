using System;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class PlotSqlDao : IPlotDao
    {
        private readonly string connectionString;

        public PlotSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Plot GetPlot(int plotId)
        {
            Plot returnPlot = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT username, width, length, sun_exposure, zone, is_edible FROM plots WHERE plotId = @plotId", conn);
                    cmd.Parameters.AddWithValue("@plot_Id", plotId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnPlot = GetPlotFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnPlot;
        }

        public Plot AddPlot(Plot plot)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO plots (username, width, length, sun_exposure, zone, is_edible, plot_id VALUES (@username, @width, @length, @sun_exposure, @zone, @is_edible, @plot_id)", conn);
                    cmd.Parameters.AddWithValue("@username", plot.Username);
                    cmd.Parameters.AddWithValue("@width", plot.Width);
                    cmd.Parameters.AddWithValue("@length", plot.Length);
                    cmd.Parameters.AddWithValue("@sun_exposure", plot.SunExposure);
                    cmd.Parameters.AddWithValue("@zone", plot.Zone);
                    cmd.Parameters.AddWithValue("@is_edible", plot.IsEdible);
                    cmd.Parameters.AddWithValue("@plot_id", plot.PlotId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetPlot(plot.PlotId);
        }

        private Plot GetPlotFromReader(SqlDataReader reader)
        {
            Plot p = new Plot()
            {
                PlotId = Convert.ToInt32(reader["plot_id"]),
                Username = Convert.ToString(reader["username"]),
                SunExposure = Convert.ToString(reader["sun_exposure"]),
                Zone = Convert.ToInt32(reader["zone"]),
                IsEdible = Convert.ToBoolean(reader["is_edible"]),
                Length = Convert.ToInt32(reader["length"]),
                Width = Convert.ToInt32(reader["width"])
            };

            return p;
        }
    }
}
