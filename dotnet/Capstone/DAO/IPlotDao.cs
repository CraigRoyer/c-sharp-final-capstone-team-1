using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPlotDao
    {       Plot GetPlot(int plotId);
            Plot AddPlot(Plot plot);
            List<Plot> ListPlots(int userId);
            Plot GetTopPlotByUserId(int userId);
    }
}