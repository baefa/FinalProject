using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ProductReceive : ModelObject
    {
        public Supplier Supplier { get; set; }
        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
        public int Quantity { get; set; }
        public SqlDateTime DateOfReceive { get; set; }
    }
}
