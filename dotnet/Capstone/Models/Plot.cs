using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Plot
    {
        public int PlotId { get; set; }
        public int UserId { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string SunExposure { get; set; }
        public int Zone { get; set; } 
        public string PlotName { get; set; }
    }
}
