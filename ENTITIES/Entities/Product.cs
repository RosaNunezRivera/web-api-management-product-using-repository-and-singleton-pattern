using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entities
{
    /// <summary>
    /// CLass to entity products 
    /// </summary>
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }


    }
}
