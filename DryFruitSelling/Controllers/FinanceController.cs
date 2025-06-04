using DryFruitSelling.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;

namespace DryFruitSelling.Controllers
{
    public class FinanceController : Controller
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: Finance
        public ActionResult Index()
        {
            List<Finance> finance = new List<Finance>();
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_finance", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    finance.Add(new Finance
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        TransactionID = sdr["TransactionID"].ToString(),
                        TransactionType = sdr["TransactionType"].ToString(),
                        Amount = Convert.ToDecimal(sdr["Amount"]),

                        TodayDate = Convert.ToDateTime(sdr["TodayDate"])

                    });
                }
                conn.Close();
            }

            return View(finance);
        }

        private Finance objDetail(int id)
        {
            Finance finance = new Finance();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwone_finance", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    finance = new Finance
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        TransactionID = sdr["TransactionID"].ToString(),
                        TransactionType = sdr["TransactionType"].ToString(),
                        Amount = Convert.ToDecimal(sdr["Amount"]),

                        TodayDate = Convert.ToDateTime(sdr["TodayDate"])

                    };
                }
                conn.Close();
            }

            return finance;

        }


        // GET: Finance/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetail(id));
        }

        // GET: Finance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Finance/Create
        [HttpPost]
        public ActionResult Create(Finance finance)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_finance", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TransactionID", finance.TransactionID);
                    cmd.Parameters.AddWithValue("@TransactionType", finance.TransactionType);
                    cmd.Parameters.AddWithValue("@Amount", finance.Amount);
                    cmd.Parameters.AddWithValue("@TodayDate", finance.TodayDate);


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

        // GET: Finance/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetail(id));
        }

        // POST: Finance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Finance finance)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_update_finance", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@TransactionID", finance.TransactionID);
                    cmd.Parameters.AddWithValue("@TransactionType", finance.TransactionType);
                    cmd.Parameters.AddWithValue("@Amount", finance.Amount);
                    cmd.Parameters.AddWithValue("@TodayDate", finance.TodayDate);


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

        // GET: Finance/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetail(id));
        }

        // POST: Finance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_delete_finance", conn);
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
            List<Finance> finance = new List<Finance>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_finance", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    finance.Add(new Finance
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        TransactionID = sdr["TransactionID"].ToString(),
                        TransactionType = sdr["TransactionType"].ToString(),
                        Amount = Convert.ToDecimal(sdr["Amount"]),

                        TodayDate = Convert.ToDateTime(sdr["TodayDate"])

                    });
                }
                conn.Close();
            }

            return View(finance);
        }





        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<Finance> finance = new List<Finance>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_search_finance", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    finance.Add(new Finance
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        TransactionID = sdr["TransactionID"].ToString(),
                        TransactionType = sdr["TransactionType"].ToString(),
                        Amount = Convert.ToDecimal(sdr["Amount"]),

                        TodayDate = Convert.ToDateTime(sdr["TodayDate"])

                    });
                }
                conn.Close();
            }

            return View(finance);
        }






















































    }
}
