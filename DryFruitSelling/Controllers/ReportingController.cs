using DryFruitSelling.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;

namespace DryFruitSelling.Controllers
{
    public class ReportingController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: Reporting
        public ActionResult Index()
        {
            List<ReportingModel> report = new List<ReportingModel>();
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_vwall_Report", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    report.Add(new ReportingModel
                    { 
                    
                    id = Convert.ToInt32(sdr["id"]),
                        ReportID = sdr["ReportID"].ToString(),
                        ReportName = sdr["ReportName"].ToString(),
                        GeneratedDate = Convert.ToDateTime(sdr["GeneratedDate"]),
                        ReportType = sdr["ReportType"].ToString(),
                        DataRange = sdr["DataRange"].ToString(),
                        GeneratedBy = sdr["GeneratedBy"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    });
                }

                conn.Close();
            }

            return View(report);
        }


        private ReportingModel objDetails(int id)
        {
            ReportingModel report = new ReportingModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_vwone_Report", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    report = new ReportingModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        ReportID = sdr["ReportID"].ToString(),
                        ReportName = sdr["ReportName"].ToString(),
                        GeneratedDate = Convert.ToDateTime(sdr["GeneratedDate"]),
                        ReportType = sdr["ReportType"].ToString(),
                        DataRange = sdr["DataRange"].ToString(),
                        GeneratedBy = sdr["GeneratedBy"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    };
                }

                conn.Close();
            }

            return report;
        }






        // GET: Reporting/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetails(id));
        }

        // GET: Reporting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reporting/Create
        [HttpPost]
        public ActionResult Create(ReportingModel report)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_Report", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ReportID", report.ReportID);
                    cmd.Parameters.AddWithValue("@ReportName", report.ReportName);
                    cmd.Parameters.AddWithValue("@GeneratedDate", report.GeneratedDate);
                    cmd.Parameters.AddWithValue("@ReportType", report.ReportType);
                    cmd.Parameters.AddWithValue("@DataRange", report.DataRange);
                    cmd.Parameters.AddWithValue("@GeneratedBy", report.GeneratedBy);
                    cmd.Parameters.AddWithValue("@Notes", report.Notes);


                    int i = cmd.ExecuteNonQuery();

                    if(i>0)
                    {
                        TempData["Success"] = "Data send Successfully!";
                    }
                    else
                    {
                        
                            TempData["Error"] = "Data send Failure!";
                        
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

        // GET: Reporting/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetails(id));
        }

        // POST: Reporting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,ReportingModel report)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_update_Report", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.Parameters.AddWithValue("@ReportID", report.ReportID);
                    cmd.Parameters.AddWithValue("@ReportName", report.ReportName);
                    cmd.Parameters.AddWithValue("@GeneratedDate", report.GeneratedDate);
                    cmd.Parameters.AddWithValue("@ReportType", report.ReportType);
                    cmd.Parameters.AddWithValue("@DataRange", report.DataRange);
                    cmd.Parameters.AddWithValue("@GeneratedBy", report.GeneratedBy);
                    cmd.Parameters.AddWithValue("@Notes", report.Notes);


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

        // GET: Reporting/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetails(id));
        }

        // POST: Reporting/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_delete_Report", conn);
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
            List<ReportingModel> report = new List<ReportingModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_vwall_Report", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    report.Add(new ReportingModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        ReportID = sdr["ReportID"].ToString(),
                        ReportName = sdr["ReportName"].ToString(),
                        GeneratedDate = Convert.ToDateTime(sdr["GeneratedDate"]),
                        ReportType = sdr["ReportType"].ToString(),
                        DataRange = sdr["DataRange"].ToString(),
                        GeneratedBy = sdr["GeneratedBy"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    });
                }

                conn.Close();
            }

            return View(report);
        }


        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<ReportingModel> report = new List<ReportingModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_search_Report", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    report.Add(new ReportingModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        ReportID = sdr["ReportID"].ToString(),
                        ReportName = sdr["ReportName"].ToString(),
                        GeneratedDate = Convert.ToDateTime(sdr["GeneratedDate"]),
                        ReportType = sdr["ReportType"].ToString(),
                        DataRange = sdr["DataRange"].ToString(),
                        GeneratedBy = sdr["GeneratedBy"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    });
                }

                conn.Close();
            }

            return View(report);
        }






























    }
}
