using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_Project.Models
{

    public class Product
    {

        public string name { get; set; }
        public int id { get; set; }
        public double price { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int quantity { get; set; } = 1;
        public int productTypeId { get; set; }
        public int tableId { get; set; }

        public Product()
        {

        }
   
    }
}
