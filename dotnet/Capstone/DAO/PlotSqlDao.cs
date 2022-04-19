using System;
using System.Collections.Generic;
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

                    SqlCommand cmd = new SqlCommand("SELECT plot_id_number, user_id, plot_width, plot_length, sun_exposure_hours, zone_info, plot_name " +
                                                    "FROM plot WHERE plot_id_number = @plot_id_number", conn);
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
        public Plot GetTopPlotByUserId(int userId)
        {
            Plot returnPlot = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 plot_name, plot_id_number, user_id, plot_width, plot_length, sun_exposure_hours, zone_info FROM plot WHERE user_id = @user_id", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
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

        public Plot AddPlot(Plot newPlot)
        {
            int newPlotId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO plot (user_id, plot_length, plot_width, sun_exposure_hours, zone_info, plot_name) " +
                                                    "OUTPUT INSERTED.plot_id_number " +
                                                    "VALUES(@user_id, @plot_length, @plot_width, @sun_exposure_hours, @zone_info, @plot_name)", conn);
                    cmd.Parameters.AddWithValue("@plot_name", newPlot.PlotName);
                    cmd.Parameters.AddWithValue("@plot_width", newPlot.Width);
                    cmd.Parameters.AddWithValue("@plot_length", newPlot.Length);
                    cmd.Parameters.AddWithValue("@sun_exposure_hours", newPlot.SunExposure);
                    cmd.Parameters.AddWithValue("@zone_info", newPlot.Zone);
                    cmd.Parameters.AddWithValue("@user_id", newPlot.UserId);
                    //cmd.ExecuteNonQuery();
                    newPlotId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return GetPlot(newPlotId);
        }

        public List<Plot> ListPlots(int userId)
        {
            List<Plot> plots = new List<Plot>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT plot_name, plot_id_number, plot_length, plot_width, zone_info, sun_exposure_hours
                                                FROM plot JOIN users ON users.user_id = plot.user_id WHERE users.user_id = @user_id", conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        Plot plot = new Plot();
                        plot.UserId = Convert.ToInt32(reader["user_id"]);//do we need?
                        plot.PlotName = Convert.ToString(reader["plotName"]);
                        plot.PlotId = Convert.ToInt32(reader["plot_id"]);
                        plot.Length = Convert.ToInt32(reader["length"]);
                        plot.Width = Convert.ToInt32(reader["width"]);
                        plot.SunExposure = Convert.ToInt32(reader["sun_exposure_hours"]);
                        plot.Zone = Convert.ToInt32(reader["zone"]);
                        //Plot plot = GetPlotFromReader(reader);
                        plots.Add(plot);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    
                }
                return plots;
            }
            
        }

        private Plot GetPlotFromReader(SqlDataReader reader)
        {
            Plot p = new Plot()
            {
                PlotId = Convert.ToInt32(reader["plot_id_number"]),
                SunExposure = Convert.ToInt32(reader["sun_exposure_hours"]),
                Zone = Convert.ToInt32(reader["zone_info"]),
                Length = Convert.ToInt32(reader["plot_length"]),
                Width = Convert.ToInt32(reader["plot_width"]),
                UserId = Convert.ToInt32(reader["user_id"]), //????
                PlotName = Convert.ToString(reader["plot_name"])
            };

            return p;
        }
    }
}

