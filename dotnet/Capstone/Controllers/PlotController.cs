﻿using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly IPlotDao plotDao;

        [HttpGet("{plotId}")]
        public IActionResult GetPlotByPlotId(int plotId)
        {
            IActionResult result;

            // Get the plot by plotId
            Plot plot = plotDao.GetPlot(plotId);
            if (plot != null)
            {
                result = Ok(plot);
                return result;
            }
            else return NotFound();
        }

        [HttpPost("create")]
        public IActionResult CreatePlot(Plot plot)
        {
            IActionResult result;

            Plot newPlot = plotDao.AddPlot(plot);
            if (newPlot != null)
            {
                result = Created($"/plot/{newPlot.PlotId}",newPlot); //values aren't read on client
            }
            else
            {
                result = BadRequest(new { message = "An error occurred and your plot was not created." });
            }

            return result;
        }
    }
}