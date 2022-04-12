using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Plot
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public string SunExposure { get; set; }
        public int Zone { get; set; }
        public bool IsEdible { get; set; }
        public int PlotId { get; set; }
        public string Username { get; set; }
    }
}
