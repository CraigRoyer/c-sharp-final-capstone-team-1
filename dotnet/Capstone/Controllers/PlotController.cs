using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Capstone.Controllers
{
    [Route("plot")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly IPlotDao plotDao;
        private readonly IUserDao userDao;
        private readonly IPlantInfoDao plantInfoDao;
        private readonly IPlantDao plantDao;

        public PlotController(IPlotDao _plotDao, IUserDao _userDao, IPlantInfoDao _plantInfoDao, IPlantDao _plantDao)
        {
            plotDao = _plotDao;
            userDao = _userDao;
            plantDao = _plantDao;
            plantInfoDao = _plantInfoDao;
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


        [HttpGet]
        public ActionResult<Plot> GetPlotByUserId()
        {
            int userId = Convert.ToInt32(User.FindFirst("sub")?.Value);
            Plot plot = plotDao.GetTopPlotByUserId(userId);

            if (plot != null)
            {
                //return plot;
                return Ok(plot);
            }
            else return StatusCode(418);
        }
        [HttpGet("allplots")]
        public ActionResult<List<Plot>> ListPlotsById()
        {
            int userId = Convert.ToInt32(User.FindFirst("sub")?.Value);
            return plotDao.ListPlots(userId);
        }


        [HttpPost("/plot/create")]
        public ActionResult<Plot> CreatePlot(Plot plot)
        {
            int userId = Convert.ToInt32(User.FindFirst("sub")?.Value);
            plot.UserId = userId;
            Plot newPlot = plotDao.AddPlot(plot);

            if (newPlot != null)
            {
                return Created($"/plot/{newPlot.PlotId}", newPlot);
                //values aren't read on client
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost("{plotId}/plant")]
        public ActionResult AddPlantToPlot(int plantId, int plotId)
        {
            plotDao.AddPlantToPlot(plantId, plotId);
            Plot addedPlot = plotDao.GetPlot(plotId);
            Plant addedPlant = plantDao.GetPlantByPlantId(plantId);

            if (addedPlot != null && addedPlant != null)
            {
                return Accepted();
                //values aren't read on client
            }
            else
            {
                return NotFound();
            }

        }
    }
}

