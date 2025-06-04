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
    public class SalesController : Controller
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: Sales
        public ActionResult Index()
        {
            List<SalesModel> sale = new List<SalesModel>();
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwall_sales", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    sale.Add(new SalesModel
                    { 
                    
                        id = Convert.ToInt32(sdr["id"]),
                        SaleID = sdr["SaleID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        SaleDate = Convert.ToDateTime(sdr["SaleDate"]),
                        Revenue = Convert.ToDecimal(sdr["Revenue"])

                    });
                }
                conn.Close();
            }


            return View(sale);
        }



        private SalesModel objDetail(int id)
        {
            SalesModel sale = new SalesModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwone_sales", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    sale = new SalesModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        SaleID = sdr["SaleID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        SaleDate = Convert.ToDateTime(sdr["SaleDate"]),
                        Revenue = Convert.ToDecimal(sdr["Revenue"])

                    };
                }
                conn.Close();
            }
            return sale; 
        }



        // GET: Sales/Details/5
        public ActionResult Details(int id)
        {


            return View(objDetail(id)); 
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        public ActionResult Create(SalesModel sale)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open() ;
                    SqlCommand cmd = new SqlCommand("sp_insert_sales", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SaleID", sale.SaleID);
                    cmd.Parameters.AddWithValue("@CustomerID", sale.CustomerID);
                    cmd.Parameters.AddWithValue("@FruitType", sale.FruitType);
                    cmd.Parameters.AddWithValue("@Quantity", sale.Quantity);
                    cmd.Parameters.AddWithValue("@SaleDate", sale.SaleDate);
                    cmd.Parameters.AddWithValue("@Revenue", sale.Revenue);
                    int i = cmd.ExecuteNonQuery();

                    if(i>0)
                    {
                        TempData["Success"] = "Data Send successfully!";
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

        // GET: Sales/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetail(id));
        }

        // POST: Sales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SalesModel sale)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_sales", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@SaleID", sale.SaleID);
                    cmd.Parameters.AddWithValue("@CustomerID", sale.CustomerID);
                    cmd.Parameters.AddWithValue("@FruitType", sale.FruitType);
                    cmd.Parameters.AddWithValue("@Quantity", sale.Quantity);
                    cmd.Parameters.AddWithValue("@SaleDate", sale.SaleDate);
                    cmd.Parameters.AddWithValue("@Revenue", sale.Revenue);
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        TempData["Success"] = "Data Updated successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data Updated Failure!";
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

        // GET: Sales/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetail(id));
        }

        // POST: Sales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete_sales", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                
                    
                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        TempData["Success"] = "Data Deleted successfully!";
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
            List<SalesModel> sale = new List<SalesModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwall_sales", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    sale.Add(new SalesModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        SaleID = sdr["SaleID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        SaleDate = Convert.ToDateTime(sdr["SaleDate"]),
                        Revenue = Convert.ToDecimal(sdr["Revenue"])

                    });
                }
                conn.Close();
            }


            return View(sale);
        }




        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<SalesModel> sale = new List<SalesModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_search_sales", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    sale.Add(new SalesModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        SaleID = sdr["SaleID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        SaleDate = Convert.ToDateTime(sdr["SaleDate"]),
                        Revenue = Convert.ToDecimal(sdr["Revenue"])

                    });
                }
                conn.Close();
            }


            return View(sale);
        }























































    }
}
