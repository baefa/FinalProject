using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Product : ModelObject
    {
        public Producer Producer { get; set; }
        public string Name { get; set; }
        public int Article { get; set; }
        public string Category { get; set; }
        public double Cost { get; set; }
    }
}
