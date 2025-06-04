using DryFruitSelling.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DryFruitSelling.Controllers
{
    public class DResearchController : Controller
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: DResearch
        public ActionResult Index()
        {
            List<DRearchModel> research = new List<DRearchModel>();
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_Research", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    research.Add(new DRearchModel
                    { 
                    id = Convert.ToInt32(sdr["id"]),
                        RnDProjectID = sdr["RnDProjectID"].ToString(),
                        ProjectName = sdr["ProjectName"].ToString(),
                        StartDate = Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        ProjectStatus = sdr["ProjectStatus"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    });
                }

                conn.Close();
            }
            return View(research);
        }



        private DRearchModel  objDetail(int id)
        {

            DRearchModel research = new DRearchModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwone_Research", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    research = new DRearchModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        RnDProjectID = sdr["RnDProjectID"].ToString(),
                        ProjectName = sdr["ProjectName"].ToString(),
                        StartDate = Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        ProjectStatus = sdr["ProjectStatus"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    };
                }

                conn.Close();
            }
            return research;

        }



        // GET: DResearch/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetail(id));
        }

        // GET: DResearch/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: DResearch/Create
        [HttpPost]
        public ActionResult Create(DRearchModel research)
        {
            try
            {
                // TODO: Add insert logic here
                using(SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_Research", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RnDProjectID", research.RnDProjectID);
                    cmd.Parameters.AddWithValue("@ProjectName", research.ProjectName);
                    cmd.Parameters.AddWithValue("@StartDate", research.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", research.EndDate);
                    cmd.Parameters.AddWithValue("@ProjectStatus", research.ProjectStatus);
                    cmd.Parameters.AddWithValue("@Notes", research.Notes);
                    

                    int i = cmd.ExecuteNonQuery();
                    if(i>0)
                    {

                        TempData["Success"] = "Data send Successfully !";

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

        // GET: DResearch/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetail(id));
        }

        // POST: DResearch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DRearchModel research)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_update_Research", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@RnDProjectID", research.RnDProjectID);
                    cmd.Parameters.AddWithValue("@ProjectName", research.ProjectName);
                    cmd.Parameters.AddWithValue("@StartDate", research.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", research.EndDate);
                    cmd.Parameters.AddWithValue("@ProjectStatus", research.ProjectStatus);
                    cmd.Parameters.AddWithValue("@Notes", research.Notes);


                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {

                        TempData["Success"] = "Data updated Successfully !";

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

        // GET: DResearch/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetail(id));
        }

        // POST: DResearch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_delete_Research", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {

                        TempData["Success"] = "Data Deleted Successfully !";

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
            List<DRearchModel> research = new List<DRearchModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_Research", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    research.Add(new DRearchModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        RnDProjectID = sdr["RnDProjectID"].ToString(),
                        ProjectName = sdr["ProjectName"].ToString(),
                        StartDate = Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        ProjectStatus = sdr["ProjectStatus"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    });
                }

                conn.Close();
            }
            return View(research);
        }





        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<DRearchModel> research = new List<DRearchModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_search_Research", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    research.Add(new DRearchModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        RnDProjectID = sdr["RnDProjectID"].ToString(),
                        ProjectName = sdr["ProjectName"].ToString(),
                        StartDate = Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        ProjectStatus = sdr["ProjectStatus"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    });
                }

                conn.Close();
            }
            return View(research);
        }



































    }
}
