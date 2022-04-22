using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class PlantInfo
    {
        //clean csv column names (not using / yet):
        //Name,alternateName,sowInstructions,spaceInstructions,
        //harvestInstructions,compatiblePlants,avoidInstructions,
        //culinaryHints,culinaryPreservation,imgurl

        //raw csv column names (using):
        //Name,sowInstructions,spaceInstructions,harvestInstructions,
        //compatiblePlants,avoidInstructions,culinaryHints,culinaryPreservation,
        //image,url

        public string Name { get; set; } //Is dictionary key + [0]
        public string SowInstructions { get; set; } //[1]
        public string SpaceInstructions { get; set; } //[2]
        public string HavestInstructions { set; get; } //[3]
        public string CompatiblePlants { get; set; } //[4]
        public string AvoidInstructions { get; set; } //[5]
        public string ImageUrl { get; set; } //[8]


        public PlantInfo(string name, string sowInstructions, string spaceInstructions, string harvestInstructions, string compatiblePlants, string avoidInstructions, string imageUrl)
        {
            this.Name = name;
            this.SowInstructions = sowInstructions;
            this.SpaceInstructions = spaceInstructions;
            this.HavestInstructions = harvestInstructions;
            this.CompatiblePlants = compatiblePlants;
            this.AvoidInstructions = avoidInstructions;
            this.ImageUrl = imageUrl;
        }

        public PlantInfo()
        {

        }

        public PlantInfo(string name, string sowInstructions, string spaceInstructions, string harvestInstructions, string compatiblePlants, string avoidInstructions)
        {
            this.Name = name;
            this.SowInstructions = sowInstructions;
            this.SpaceInstructions = spaceInstructions;
            this.HavestInstructions = harvestInstructions;
            this.CompatiblePlants = compatiblePlants;
            this.AvoidInstructions = avoidInstructions;
        }

    }
  
}
