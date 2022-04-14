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
        private readonly IUserDao userDao;

        public PlotController(IPlotDao _plotDao, IUserDao _userDao)
        {
            plotDao = _plotDao;
            userDao = _userDao;
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
        [HttpGet("plots")]
        public ActionResult<List<Plot>> ListPlotsById(int userId)
        {
            // string username = userDao.GetUsernameByUserId(userId) //do we need this?
            return plotDao.ListPlots(userId);
        }


        [HttpPost("create")]
        public ActionResult<Plot> CreatePlot(Plot plot)
        {

            Plot newPlot = plotDao.AddPlot(plot);

            if (newPlot != null)
            {
                return Created($"/plot/{newPlot.PlotId}", newPlot); //values aren't read on client
            }
            else
            {
                return NotFound();
            }

        }
    }
}

