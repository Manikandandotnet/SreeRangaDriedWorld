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
    public class MarketingController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: Marketing
        
        
        public ActionResult Index()
        {

            List<MarketingModel> market = new List<MarketingModel>();

            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_marketing", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    market.Add(new MarketingModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        CampaignID = sdr["CampaignID"].ToString(),
                        CampaignName = sdr["CampaignName"].ToString(),
                        StartDate = Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        Budget = sdr["Budget"].ToString(),
                        Outcome = sdr["Outcome"].ToString()

                    });
                }
                conn.Close();
            }



            return View(market);
        }

       
        
        private MarketingModel objDetail(int id)
        {

           MarketingModel market = new MarketingModel();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwone_marketing", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    market = new MarketingModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        CampaignID = sdr["CampaignID"].ToString(),
                        CampaignName = sdr["CampaignName"].ToString(),
                        StartDate = Convert.ToDateTime(sdr["StartDate"]),
                        EndDate = Convert.ToDateTime(sdr["EndDate"]),
                        Budget = sdr["Budget"].ToString(),
                        Outcome = sdr["Outcome"].ToString()

                    };
                }
                conn.Close();
            }



            return market;



        }
        
        
        
        
        
        
        // GET: Marketing/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetail(id));
        }

        // GET: Marketing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marketing/Create
        [HttpPost]
        public ActionResult Create(MarketingModel market)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_marketing", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CampaignID", market.CampaignID);
                    cmd.Parameters.AddWithValue("@CampaignName", market.CampaignName);
                    cmd.Parameters.AddWithValue("@StartDate", market.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", market.EndDate);
                    cmd.Parameters.AddWithValue("@Budget", market.Budget);
                    cmd.Parameters.AddWithValue("@Outcome", market.Outcome);
               

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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marketing/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetail(id));
        }

        // POST: Marketing/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MarketingModel market)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_update_marketing", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@CampaignID", market.CampaignID);
                    cmd.Parameters.AddWithValue("@CampaignName", market.CampaignName);
                    cmd.Parameters.AddWithValue("@StartDate", market.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", market.EndDate);
                    cmd.Parameters.AddWithValue("@Budget", market.Budget);
                    cmd.Parameters.AddWithValue("@Outcome", market.Outcome);


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

        // GET: Marketing/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetail(id));
        }

        // POST: Marketing/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_delete_marketing", conn);
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

                List<MarketingModel> market = new List<MarketingModel>();

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_vwall_marketing", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        market.Add(new MarketingModel
                        {
                            id = Convert.ToInt32(sdr["id"]),
                            CampaignID = sdr["CampaignID"].ToString(),
                            CampaignName = sdr["CampaignName"].ToString(),
                            StartDate = Convert.ToDateTime(sdr["StartDate"]),
                            EndDate = Convert.ToDateTime(sdr["EndDate"]),
                            Budget = sdr["Budget"].ToString(),
                            Outcome = sdr["Outcome"].ToString()

                        });
                    }
                    conn.Close();
                }



                return View(market);
            }



            [HttpPost]

            public ActionResult Search(string Search)
            {

                List<MarketingModel> market = new List<MarketingModel>();

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_search_marketing", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Searchdata", Search);
                   
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        market.Add(new MarketingModel
                        {
                            id = Convert.ToInt32(sdr["id"]),
                            CampaignID = sdr["CampaignID"].ToString(),
                            CampaignName = sdr["CampaignName"].ToString(),
                            StartDate = Convert.ToDateTime(sdr["StartDate"]),
                            EndDate = Convert.ToDateTime(sdr["EndDate"]),
                            Budget = sdr["Budget"].ToString(),
                            Outcome = sdr["Outcome"].ToString()

                        });
                    }
                    conn.Close();
                }



                return View(market);
            }







        
    }
}
