using DryFruitSelling.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace DryFruitSelling.Controllers
{
    public class EnvironmentalController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: Environmental
        public ActionResult Index()
        {
            List<EnvironmentalModel> env = new List<EnvironmentalModel>();

            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_vwall_Environment", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    env.Add(new EnvironmentalModel
                    {
                        id= Convert.ToInt32(sdr["id"]),

                        SustainabilityPracticeID = sdr["SustainabilityPracticeID"].ToString(),
                        PracticeDescription = sdr["PracticeDescription"].ToString(),
                        ImplementationDate = Convert.ToDateTime(sdr["ImplementationDate"]),
                        Impact = sdr["Impact"].ToString()

                    });
                }
                conn.Close();
            }

            return View(env);
        }


        private EnvironmentalModel objDetail(int id)
        {

            EnvironmentalModel env = new EnvironmentalModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_vwone_Environment", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    env = new EnvironmentalModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        SustainabilityPracticeID = sdr["SustainabilityPracticeID"].ToString(),
                        PracticeDescription = sdr["PracticeDescription"].ToString(),
                        ImplementationDate = Convert.ToDateTime(sdr["ImplementationDate"]),
                        Impact = sdr["Impact"].ToString()

                    };
                }
                conn.Close();
            }

            return env;




        }




        // GET: Environmental/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetail(id));
        }

        // GET: Environmental/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Environmental/Create
        [HttpPost]
        public ActionResult Create(EnvironmentalModel env)
        {
            try
            {
                // TODO: Add insert logic here
                using(SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_Environment", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SustainabilityPracticeID", env.SustainabilityPracticeID);
                    cmd.Parameters.AddWithValue("@PracticeDescription", env.PracticeDescription);
                    cmd.Parameters.AddWithValue("@ImplementationDate", env.ImplementationDate);
                    cmd.Parameters.AddWithValue("@Impact", env.Impact);
               
                    int i = cmd.ExecuteNonQuery();
                    if (i>0)
                    {
                        TempData["Success"] = "Data Send Successfully!";
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

        // GET: Environmental/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetail(id));
        }

        // POST: Environmental/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EnvironmentalModel env)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_update_Environment", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.Parameters.AddWithValue("@SustainabilityPracticeID", env.SustainabilityPracticeID);
                    cmd.Parameters.AddWithValue("@PracticeDescription", env.PracticeDescription);
                    cmd.Parameters.AddWithValue("@ImplementationDate", env.ImplementationDate);
                    cmd.Parameters.AddWithValue("@Impact", env.Impact);
               
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

        // GET: Environmental/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetail(id));
        }

        // POST: Environmental/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_delete_Environment", conn);
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
            List<EnvironmentalModel> env = new List<EnvironmentalModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_vwall_Environment", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    env.Add(new EnvironmentalModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        SustainabilityPracticeID = sdr["SustainabilityPracticeID"].ToString(),
                        PracticeDescription = sdr["PracticeDescription"].ToString(),
                        ImplementationDate = Convert.ToDateTime(sdr["ImplementationDate"]),
                        Impact = sdr["Impact"].ToString()

                    });
                }
                conn.Close();
            }

            return View(env);
        }


        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<EnvironmentalModel> env = new List<EnvironmentalModel>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_search_Environment", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    env.Add(new EnvironmentalModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        SustainabilityPracticeID = sdr["SustainabilityPracticeID"].ToString(),
                        PracticeDescription = sdr["PracticeDescription"].ToString(),
                        ImplementationDate = Convert.ToDateTime(sdr["ImplementationDate"]),
                        Impact = sdr["Impact"].ToString()

                    });
                }
                conn.Close();
            }

            return View(env);
        }



















































    }
}
