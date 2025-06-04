using DryFruitSelling.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DryFruitSelling.Controllers
{
    public class HomePageController : Controller
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        // GET: HomePage
        public ActionResult Home()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Home(string a)
        {

            return View();
        }



        public ActionResult AboutPage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AboutPage(string a)
        {

            return View();
        }




        public ActionResult ContactPage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ContactPage(contactus contact)
        {

            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_contactus", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", contact.Name);

                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                    cmd.Parameters.AddWithValue("@Phone", contact.Phone);

                    cmd.Parameters.AddWithValue("@Message", contact.Message);


                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Success"] = "Data Send Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data Send Failure!";
                    }

                    conn.Close();
                }

                return RedirectToAction("ContactPage");
            }
            catch
            {
                return View();
            }
        }




        public ActionResult ShopPage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ShopPage(string a)
        {

            return View();
        }


        public ActionResult UserPage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UserPage(string a)
        {

            return View();
        }


        public ActionResult AdminPage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AdminPage(string a)
        {

            return View();
        }













































    }
}