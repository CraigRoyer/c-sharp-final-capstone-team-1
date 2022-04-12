using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPlotDao
    {       Plot GetPlot(int plotId);
            Plot AddPlot(Plot plot);
    }
}