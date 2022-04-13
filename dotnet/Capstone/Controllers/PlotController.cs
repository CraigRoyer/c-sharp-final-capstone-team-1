using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;


namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly IPlotDao plotDao;

        public PlotController (IPlotDao _plotDao)
        {
            plotDao = _plotDao;
        }

        [HttpGet("{plotId}")]
        public ActionResult<Plot> GetPlotByPlotId(int plotId)
        {
            // Get the plot by plotId
            Plot plot = plotDao.GetPlot(plotId);

            if (plot != null)
            {
                //return plot;
                return Ok(plot);
            }
            else return NotFound();
        }

        [HttpPost("create")]
        public ActionResult<Plot> CreatePlot(Plot plot)
        {

            Plot newPlot = plotDao.AddPlot(plot);

            if (newPlot != null)
            {
                return Created($"/plot/{newPlot.PlotId}",newPlot); //values aren't read on client
            }
            else
            {
                return NotFound();
            }

        }
    }
}
