using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DTOs
{
    public class OrderDTO
    {
        [Key]
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
