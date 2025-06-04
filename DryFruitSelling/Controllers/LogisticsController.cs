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
    public class LogisticsController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: Logistics
        public ActionResult Index()
        {
            List<LogisticsModel> logistic = new List<LogisticsModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_Logistics", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    logistic.Add(new LogisticsModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ShipmentID = sdr["ShipmentID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        Destination = sdr["Destination"].ToString(),
                        ShipmentDate = Convert.ToDateTime(sdr["ShipmentDate"]),
                        DeliveryStatus = sdr["DeliveryStatus"].ToString()
                    });
                }

                conn.Close();
            }

                return View(logistic);
        }



        private LogisticsModel objDetails(int id)
        {

            LogisticsModel logistic = new LogisticsModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwone_Logistics", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    logistic = new LogisticsModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ShipmentID = sdr["ShipmentID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        Destination = sdr["Destination"].ToString(),
                        ShipmentDate = Convert.ToDateTime(sdr["ShipmentDate"]),
                        DeliveryStatus = sdr["DeliveryStatus"].ToString()
                    };
                }

                conn.Close();
            }

            return logistic;



        }

        // GET: Logistics/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetails(id));
        }

        // GET: Logistics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logistics/Create
        [HttpPost]
        public ActionResult Create(LogisticsModel logistic)
        {
            try
            {
                // TODO: Add insert logic here
                using(SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_logistics", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ShipmentID", logistic.ShipmentID);
                    cmd.Parameters.AddWithValue("@FruitType", logistic.FruitType);
                    cmd.Parameters.AddWithValue("@Quantity", logistic.Quantity);
                    cmd.Parameters.AddWithValue("@Destination", logistic.Destination);
                    cmd.Parameters.AddWithValue("@ShipmentDate", logistic.ShipmentDate);
                    cmd.Parameters.AddWithValue("@DeliveryStatus", logistic.DeliveryStatus);

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

        // GET: Logistics/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetails(id));
        }

        // POST: Logistics/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LogisticsModel logistic)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_update_logistics", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@ShipmentID", logistic.ShipmentID);
                    cmd.Parameters.AddWithValue("@FruitType", logistic.FruitType);
                    cmd.Parameters.AddWithValue("@Quantity", logistic.Quantity);
                    cmd.Parameters.AddWithValue("@Destination", logistic.Destination);
                    cmd.Parameters.AddWithValue("@ShipmentDate", logistic.ShipmentDate);
                    cmd.Parameters.AddWithValue("@DeliveryStatus", logistic.DeliveryStatus);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Success"] = "Data update Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data update Failure!";
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

        // GET: Logistics/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetails(id));
        }

        // POST: Logistics/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_delete_Logistics", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Success"] = "Data Delete Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data Delete Failure!";
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
            List<LogisticsModel> logistic = new List<LogisticsModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_Logistics", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    logistic.Add(new LogisticsModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ShipmentID = sdr["ShipmentID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        Destination = sdr["Destination"].ToString(),
                        ShipmentDate = Convert.ToDateTime(sdr["ShipmentDate"]),
                        DeliveryStatus = sdr["DeliveryStatus"].ToString()
                    });
                }

                conn.Close();
            }

            return View(logistic);
        }


        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<LogisticsModel> logistic = new List<LogisticsModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_search_Logistics", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    logistic.Add(new LogisticsModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ShipmentID = sdr["ShipmentID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        Destination = sdr["Destination"].ToString(),
                        ShipmentDate = Convert.ToDateTime(sdr["ShipmentDate"]),
                        DeliveryStatus = sdr["DeliveryStatus"].ToString()
                    });
                }

                conn.Close();
            }

            return View(logistic);
        }






















































    }
}
