using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;


namespace Capstone.Controllers
{
    [Route("plot")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly IPlotDao plotDao;
        private readonly IUserDao userDao;

<<<<<<< HEAD
        public PlotController(IPlotDao _plotDao, IUserDao _userDao)
=======
        public PlotController(IPlotDao _plotdao)
        {
            plotDao = _plotdao;
        }

        [HttpGet("{plotId}")]
        public IActionResult GetPlotByPlotId(int plotId)
>>>>>>> main
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
            else return StatusCode(420);
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

<<<<<<< HEAD
=======
            return result;

            
>>>>>>> main
        }
    }
}

