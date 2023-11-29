using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace FinalProject.Models
{
    public class ProductReceive : IEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public SqlDateTime DateOfReceive { get; set; }

        public int SupplierId {  get; set; } 
        public Supplier Supplier { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
