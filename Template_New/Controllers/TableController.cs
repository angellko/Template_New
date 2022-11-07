using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template_New.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Customer()
        {
            return View();
        }
        public IActionResult LoadData()
        {
            return PartialView();
        }
        public IActionResult SaveData(Customer customer)
        {
            int result = 0;
            string connectionString = "data source=DESKTOP-INKMT87;initial catalog=MyFirstDB;integrated security=true";
            string sqlQuery = @"Insert into tbl_Customer(Id, Name, Product, Price, Address) values(@Id,@Name,@Product,@Price,@Address)";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@Product", customer.Product);
            cmd.Parameters.AddWithValue("@Price", customer.Price);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            string res = result == -1 ? "Insertion Failed" : "Success";
            return Json(res);
        }
    }
}
