using DryFruitSelling.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DryFruitSelling.Controllers
{
    public class QualityController : Controller
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: Quality
        public ActionResult Index()
        {
            List<QualityModel> quality = new List<QualityModel>();
            
            
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_Quality", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    quality.Add(new QualityModel
                    { 
                    
                    id = Convert.ToInt32(sdr["id"]),
                        QualityCheckID = sdr["QualityCheckID"].ToString(),
                        ProductionID = sdr["ProductionID"].ToString(),
                        InspectionDate =Convert.ToDateTime(sdr["InspectionDate"]),
                        InspectorName = sdr["InspectorName"].ToString(),
                        InspectionOutcome = sdr["InspectionOutcome"].ToString(),
                        Comments = sdr["Comments"].ToString()



                    });
                }
                conn.Close();
            }
            
            
            
            return View(quality);
        }




        private QualityModel objDetail(int id)
        {

            QualityModel quality = new QualityModel();


            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwone_Quality", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    quality = new QualityModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        QualityCheckID = sdr["QualityCheckID"].ToString(),
                        ProductionID = sdr["ProductionID"].ToString(),
                        InspectionDate = Convert.ToDateTime(sdr["InspectionDate"]),
                        InspectorName = sdr["InspectorName"].ToString(),
                        InspectionOutcome = sdr["InspectionOutcome"].ToString(),
                        Comments = sdr["Comments"].ToString()



                    };
                }
                conn.Close();
            }



            return quality;


        }






        // GET: Quality/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetail(id));
        }

        // GET: Quality/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quality/Create
        [HttpPost]
        public ActionResult Create(QualityModel quality)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_Quality", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@QualityCheckID", quality.QualityCheckID);
                    cmd.Parameters.AddWithValue("@ProductionID", quality.ProductionID);
                    cmd.Parameters.AddWithValue("@InspectionDate", quality.InspectionDate);
                    cmd.Parameters.AddWithValue("@InspectorName", quality.InspectorName);
                    cmd.Parameters.AddWithValue("@InspectionOutcome", quality.InspectionOutcome);
                    cmd.Parameters.AddWithValue("@Comments", quality.Comments);

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

        // GET: Quality/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetail(id));
        }

        // POST: Quality/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, QualityModel quality)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    
                    SqlCommand cmd = new SqlCommand("usp_update_Quality", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@QualityCheckID", quality.QualityCheckID);
                    cmd.Parameters.AddWithValue("@ProductionID", quality.ProductionID);
                    cmd.Parameters.AddWithValue("@InspectionDate", quality.InspectionDate);
                    cmd.Parameters.AddWithValue("@InspectorName", quality.InspectorName);
                    cmd.Parameters.AddWithValue("@InspectionOutcome", quality.InspectionOutcome);
                    cmd.Parameters.AddWithValue("@Comments", quality.Comments);


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

        // GET: Quality/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetail(id));
        }

        // POST: Quality/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("usp_delete_Quality", conn);
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
            List<QualityModel> quality = new List<QualityModel>();


            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_Quality", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    quality.Add(new QualityModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        QualityCheckID = sdr["QualityCheckID"].ToString(),
                        ProductionID = sdr["ProductionID"].ToString(),
                        InspectionDate = Convert.ToDateTime(sdr["InspectionDate"]),
                        InspectorName = sdr["InspectorName"].ToString(),
                        InspectionOutcome = sdr["InspectionOutcome"].ToString(),
                        Comments = sdr["Comments"].ToString()



                    });
                }
                conn.Close();
            }



            return View(quality);
        }




        [HttpPost]

        public ActionResult Search(string Search)
        {
            List<QualityModel> quality = new List<QualityModel>();


            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_search_Quality", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    quality.Add(new QualityModel
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        QualityCheckID = sdr["QualityCheckID"].ToString(),
                        ProductionID = sdr["ProductionID"].ToString(),
                        InspectionDate = Convert.ToDateTime(sdr["InspectionDate"]),
                        InspectorName = sdr["InspectorName"].ToString(),
                        InspectionOutcome = sdr["InspectionOutcome"].ToString(),
                        Comments = sdr["Comments"].ToString()



                    });
                }
                conn.Close();
            }



            return View(quality);
        }











    }
}
