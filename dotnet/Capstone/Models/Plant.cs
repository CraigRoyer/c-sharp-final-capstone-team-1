using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Plant
    {
       public int PlantId { get; set; }
       public string Name { get; set; }
       public decimal CostPer25Seeds { get; set; }
       public string SowInstructions { get; set; } //[1]
       public string SpaceInstructions { get; set; } //[2]
       public string HarvestInstructions { set; get; } //[3]
       public string CompatiblePlants { get; set; } //[4]
       public string AvoidInstructions { get; set; } //[5]
       public string ImageUrl { get; set; } //[8]
    }
}
