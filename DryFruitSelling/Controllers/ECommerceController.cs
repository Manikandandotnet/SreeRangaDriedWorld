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
    public class ECommerceController : Controller
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: ECommerce
        public ActionResult Index()
        {
            List<ECommerceModel> commerce = new List<ECommerceModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_ECommerce", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    commerce.Add(new ECommerceModel
                    { 
                    
                    id = Convert.ToInt32(sdr["id"]),
                        OnlineOrderID = sdr["OnlineOrderID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity =Convert.ToInt32(sdr["Quantity"]),
                        OrderDate =Convert.ToDateTime(sdr["OrderDate"]),
                        PaymentStatus = sdr["PaymentStatus"].ToString()

                    });
                }

                conn.Close();
            }




                return View(commerce);
        }


        private ECommerceModel objDetail(int id)
        {

            ECommerceModel commerce = new ECommerceModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwone_ECommerce", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    commerce = new ECommerceModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        OnlineOrderID = sdr["OnlineOrderID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        OrderDate = Convert.ToDateTime(sdr["OrderDate"]),
                        PaymentStatus = sdr["PaymentStatus"].ToString()

                    };
                }

                conn.Close();
            }

            return commerce;

        }

        // GET: ECommerce/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetail(id));
        }

        // GET: ECommerce/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ECommerce/Create
        [HttpPost]
        public ActionResult Create(ECommerceModel commerce)
        {
            try
            {
                // TODO: Add insert logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_ECommerce", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OnlineOrderID", commerce.OnlineOrderID);
                    cmd.Parameters.AddWithValue("@CustomerID", commerce.CustomerID);
                    cmd.Parameters.AddWithValue("@FruitType", commerce.FruitType);
                    cmd.Parameters.AddWithValue("@Quantity", commerce.Quantity);
                    cmd.Parameters.AddWithValue("@OrderDate", commerce.OrderDate);
                    cmd.Parameters.AddWithValue("@PaymentStatus", commerce.PaymentStatus);

                    int i = cmd.ExecuteNonQuery();
                    if(i>0)
                    {
                        TempData["Success"] = "Data Send Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data Send Failure!";
                    }

                    conn.Close();
                }


                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ECommerce/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetail(id));
        }

        // POST: ECommerce/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ECommerceModel commerce)
        {
            try
            {
                // TODO: Add update logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_update_ECommerce", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@OnlineOrderID", commerce.OnlineOrderID);
                    cmd.Parameters.AddWithValue("@CustomerID", commerce.CustomerID);
                    cmd.Parameters.AddWithValue("@FruitType", commerce.FruitType);
                    cmd.Parameters.AddWithValue("@Quantity", commerce.Quantity);
                    cmd.Parameters.AddWithValue("@OrderDate", commerce.OrderDate);
                    cmd.Parameters.AddWithValue("@PaymentStatus", commerce.PaymentStatus);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Success"] = "Data updated Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data updated Failure!";
                    }

                    conn.Close();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ECommerce/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetail(id));
        }

        // POST: ECommerce/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_delete_ECommerce", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Success"] = "Data Deleted Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data Deleted Failure!";
                    }

                    conn.Close();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        public ActionResult Search()
        {
            List<ECommerceModel> commerce = new List<ECommerceModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_ECommerce", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    commerce.Add(new ECommerceModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        OnlineOrderID = sdr["OnlineOrderID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        OrderDate = Convert.ToDateTime(sdr["OrderDate"]),
                        PaymentStatus = sdr["PaymentStatus"].ToString()

                    });
                }

                conn.Close();
            }




            return View(commerce);
        }




        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<ECommerceModel> commerce = new List<ECommerceModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_search_ECommerce", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    commerce.Add(new ECommerceModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        OnlineOrderID = sdr["OnlineOrderID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        OrderDate = Convert.ToDateTime(sdr["OrderDate"]),
                        PaymentStatus = sdr["PaymentStatus"].ToString()

                    });
                }

                conn.Close();
            }

            return View(commerce);
        }

























































    }
}
