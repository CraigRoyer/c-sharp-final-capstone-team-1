using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly IPlantDao plantDao;
        private readonly IUserDao userDao;

            public PlantController(IPlantDao _plantDao, IUserDao _userDao)
            {
                plantDao = _plantDao;
                userDao = _userDao;
            }

            [HttpGet("{plantId}")]
            public ActionResult<Plant> GetPlantByPlantId(int plantId)
            {
                // Get the plot by plotId
                Plant plant = plantDao.GetPlantByPlantId(plantId);

                if (plant != null)
                {
                    //return plot;
                    return Ok(plant);
                }
                else return NotFound();
            }
            [HttpGet]
            public ActionResult<List<Plant>> ListPlantsByUserId()
            {
            int userId = Convert.ToInt32(User.FindFirst("sub")?.Value);
            return plantDao.ListPlantsByUserId(userId);
            }

            [HttpGet("in/{plotId}")]
            public ActionResult<List<Plant>> ListPlantsByPlotId(int plotId) //-------------------------GET PLANTS BY PLOT
            {
            return plantDao.ListPlantsByPlotId(plotId);   
            }

            [HttpGet("all")]
            public ActionResult<List<Plant>> ListAllPlants()
            {
                return plantDao.ListAllPlants();
            }


            [HttpPost("create")]
            public ActionResult<Plant> AddPlantNotInDatabase(Plant plant)
            {
                int userId = Convert.ToInt32(User.FindFirst("sub")?.Value);
                Plant newPlant = plantDao.AddPlantNotInDatabase(plant);

                if (newPlant != null)
                {
                    return Created($"/plant/{newPlant.PlantId}", newPlant);
                    //values aren't read on client
                }
                else
                {
                    return NotFound();
                }

            }
        [HttpPost("add/{plantId}")]
        public ActionResult AddPlantToNewestPlot(int plantId)
        {
            int userId = Convert.ToInt32(User.FindFirst("sub")?.Value);
            plantDao.AddPlantToNewestPlot(plantId, userId);

            Plant addedPlant = plantDao.GetPlantByPlantId(plantId);

            if (addedPlant != null)
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



