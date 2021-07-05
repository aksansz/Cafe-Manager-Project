using Cafe_Project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cafe_Project.Services
{
    public class DBConnect
    {
        public DBConnect()
        {

        }
        public MySqlConnection GetConnection()
        {
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=1234;database=mydb";

            var conn = new MySqlConnection(myConnectionString);
            conn.Open();
            return conn;
        }
        public DataTable GetProductType()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM mydb.product_types", GetConnection());
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM mydb.product", GetConnection());
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                products.Add(
                    new Product()
                    {
                        id = Convert.ToInt32(item["product_id"]),
                        name = item["product_name"].ToString(),
                        price = Convert.ToDouble(item["price"]),
                        productTypeId = Convert.ToInt32(item["product_type_id"])




                    });
            }
            return products;
        }
        public void UpdateProduct(Product product)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE mydb.product SET product_name ='" + product.name + "', price ='" + product.price + "', product_type_id ='" + product.productTypeId + "' WHERE product_id ='" + product.id + "' ", GetConnection());
            cmd.ExecuteNonQuery();
            //sql update
        }

        public int InsertProduct(Product product)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO mydb.product(product_name, price, product_type_id)VALUES('" + product.name + "','" + product.price + "','" + product.productTypeId + "')", GetConnection());
            return cmd.ExecuteNonQuery();
        }

        public void DeleteProduct(int productId)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM mydb.product WHERE product_id = '" + productId + "' ", GetConnection());
            cmd.ExecuteNonQuery();
        }

        public List<ProductType> GetProductTypes()
        {
            List<ProductType> products = new List<ProductType>();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM mydb.product_types", GetConnection());
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                products.Add(
                    new ProductType()
                    {
                        typeId = Convert.ToInt32(item["type_id"]),
                        typeName = item["type_name"].ToString()
                    });
            }
            return products;
        }

        public List<Table> GetTables()
        {
            List<Table> tables = new List<Table>();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM mydb.table", GetConnection());
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                tables.Add(
                    new Table()
                    {
                        tableNumber = Convert.ToInt32(item["table_id"]),
                        odendi = item["payment_status"].ToString()
                    });
            }
            return tables;
        }

        public Table GetTable(int tableId)
        {
            Table table = new Table();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM mydb.table WHERE table_id = '" + tableId + "' ", GetConnection());
            var dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                table.tableNumber = Convert.ToInt32(dr.GetString(0));
                table.odendi = dr.GetString(1);
            }
            dr.Close();
            return table;
        }

        public List<Product> GetOrder(int tableId)
        {
            List<Product> orderProducts = new List<Product>();
            MySqlDataAdapter da = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT order.product_id, product.product_name, product.price, order.quantity FROM mydb.order, mydb.product "
                    + "WHERE product.product_id = order.product_id AND order.table_id = '" + tableId + "'" , GetConnection());
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                orderProducts.Add(
                    new Product()
                    {
                        name = item["product_name"].ToString(),
                        id = Convert.ToInt32(item["product_id"]),
                        price = Convert.ToDouble(item["price"]),
                        quantity = Convert.ToInt32(item["quantity"]),
                        tableId=tableId
                    });
            }
            return orderProducts;
        }

        public void AddOrder(int tableId, Product product )
        {
            string payment = "Not Paid";
            MySqlCommand cmd = new MySqlCommand("INSERT INTO mydb.order (table_id, product_id, quantity)VALUES('" + tableId + "','" + product.id + "','" + product.quantity + "')", GetConnection());
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand("UPDATE mydb.table SET payment_status = '" + payment + "' WHERE table_id = '" + tableId + "' ", GetConnection());
            cmd.ExecuteNonQuery();
        }

        public void DeleteOrders(int tableId)
        {
            string payment = "Paid";
            MySqlCommand cmd = new MySqlCommand("DELETE FROM mydb.order WHERE table_id = '" + tableId + "' ", GetConnection());
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand("UPDATE mydb.table SET payment_status = '" + payment + "' WHERE table_id = '" + tableId + "' ", GetConnection());
            cmd.ExecuteNonQuery();
        }
    }
}
