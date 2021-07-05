using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_Project.Models
{

    public class Table
    {


        public int tableNumber { get; set; }
        public string odendi { get; set; }
        public List<Product> productList { get; set; } = new List<Product>();

        public double bill { get; set; }
        public bool isEmpty { get; set; } = true;
        public Table()
        {

        }
        public Table(int tableNumber, List<Product> productList, double bill)
        {
            this.tableNumber = tableNumber;
            this.productList = productList;
            this.bill = bill;
            if (bill == 0)
            {
                isEmpty = true;
            }
            else
            {
                isEmpty = false;
            }
        }

        public Table(int tableNumber)
        {
            this.tableNumber = tableNumber;
        }


    }
}
