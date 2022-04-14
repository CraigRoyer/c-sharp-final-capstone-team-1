using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Plot
    {
        public int UserId { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int SunExposure { get; set; }
        public int Zone { get; set; }
        public int PlotId { get; set; }
        public string PlotName { get; set; }
    }
}

