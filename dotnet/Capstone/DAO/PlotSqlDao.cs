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

                    SqlCommand cmd = new SqlCommand("SELECT plot_id_number, user_id, plot_length, plot_width, sun_exposure_hours, zone_info, plot_name FROM plot WHERE plot_id_number = @plot_id_number", conn);
                    cmd.Parameters.AddWithValue("@plot_id_number", plotId);
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

                    SqlCommand cmd = new SqlCommand(@"INSERT INTO plot (user_id, plot_length, plot_width, sun_exposure_hours, zone_info, plot_name)
                                                            OUTPUT INSERTED.plot_id_number
                                                            VALUES (@user_id, @plot_length, @plot_width, @sun_exposure_hours, @zone_info, @plot_name)", conn);
                    cmd.Parameters.AddWithValue("@user_id", plot.UserId);
                    cmd.Parameters.AddWithValue("@plot_length", plot.Length);
                    cmd.Parameters.AddWithValue("@plot_width", plot.Width);
                    cmd.Parameters.AddWithValue("@sun_exposure_hours", plot.SunExposure);
                    cmd.Parameters.AddWithValue("@zone_info", plot.Zone);
                    cmd.Parameters.AddWithValue("@plot_name", plot.PlotName);
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
                PlotId = Convert.ToInt32(reader["plot_id_number"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                Length = Convert.ToInt32(reader["plot_length"]),
                Width = Convert.ToInt32(reader["plot_width"]),
                SunExposure = Convert.ToString(reader["sun_exposure_hours"]),
                Zone = Convert.ToInt32(reader["zone_info"]),
                PlotName = Convert.ToString(reader["plot_name"])    
            };

            return p;
        }
    }
}
