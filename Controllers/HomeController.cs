using Cafe_Project.Models;
using Cafe_Project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Product()
        //{
        //    DBConnect dBConnect = new DBConnect();
        //    return View(dBConnect.GetProducts());
        //}
        public IActionResult Product(int? ProductType)
        {
            DBConnect dBConnect = new DBConnect();
            var pros = dBConnect.GetProducts();
            if (ProductType != null)
                pros = pros.Where(x => x.productTypeId == ProductType).ToList();
            return View(pros);
        }
        public IActionResult EditProduct(int id)
        {
            DBConnect dBConnect = new DBConnect();
            return View(dBConnect.GetProducts().Find(x => x.id == id));
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            DBConnect dBConnect = new DBConnect();
            dBConnect.UpdateProduct(product);
            return RedirectToAction("Product", new { ProductType=product.productTypeId });
        }

        public IActionResult InsertProduct()
        {
            return View(new Product());
        }
        [HttpPost]
        public IActionResult InsertProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                DBConnect dBConnect = new DBConnect();
                int _records = dBConnect.InsertProduct(product);
                if (_records > 0)
                {
                    return RedirectToAction("Product");
                }
                else
                {
                    ModelState.AddModelError("", "Can Not Insert");
                }
            }
            return View();
        }

        public IActionResult DeleteProduct(int id)
        {
            DBConnect dBConnect = new DBConnect();
            dBConnect.DeleteProduct(id);
            return RedirectToAction("Product");
        }
        public static List<ProductType> GetProductTypes()
        {
            DBConnect dBConnect = new DBConnect();
            var pros = dBConnect.GetProductTypes();
            return pros;

        }
        public IActionResult Tables()
        {
            DBConnect dBConnect = new DBConnect();
            List<Table> tables = dBConnect.GetTables();
            return View(tables);
        }

        public IActionResult EditOrder(int id)
        {
            DBConnect dBConnect = new DBConnect();
            var orders = dBConnect.GetOrder(id);
            var table = dBConnect.GetTable(id);
            double bill = 0;
            table.productList.Clear();
            foreach (var pro in orders)
            {
                table.productList.Add(pro);
                bill += pro.price * pro.quantity;
            }
            ViewBag.Total = bill;
            
            return View(table);
        }

        public static List<Product> GetProducts(int? ProductType)
        {
            DBConnect dBConnect = new DBConnect();
            var pros = dBConnect.GetProducts();
            if (ProductType != 0)
                pros = pros.Where(x => x.productTypeId == ProductType).ToList();
            return pros;

        }

        public IActionResult CreateOrder(int tableId)
        {
            return View(new Product() { tableId=tableId, quantity=1});
        }

        [HttpPost]
        public IActionResult CreateOrder(Product product)
        {
            DBConnect dBConnect = new DBConnect();
            dBConnect.AddOrder(product.tableId, product);
            return RedirectToAction("EditOrder", new { id = product.tableId });
        }
        //[HttpPost]
        public IActionResult Payment(int id)
        {
            DBConnect dBConnect = new DBConnect();
            dBConnect.DeleteOrders(id);
            return RedirectToAction("EditOrder", new { id=id});
        }

        public static List<Product> GetOrders(int tableId)
        {
            DBConnect dBConnect = new DBConnect();
            var pros = dBConnect.GetOrder(tableId);
            return pros;

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
