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

            [HttpGet("all")]
            public ActionResult<List<Plant>> ListAllPlants()
            {
                return plantDao.ListAllPlants();
            }


            [HttpPost("create")]
            public ActionResult<Plant> AddPlant(Plant plant)
            {
                int userId = Convert.ToInt32(User.FindFirst("sub")?.Value);
                Plant newPlant = plantDao.AddPlant(plant);

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
        }
    }

}
}
