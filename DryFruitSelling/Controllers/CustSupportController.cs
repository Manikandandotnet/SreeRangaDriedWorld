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
    public class CustSupportController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: CustSupport
        public ActionResult Index()
        {
            List<CustSupportModel> cust = new List<CustSupportModel>();
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_csupport", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

               SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    cust.Add(new CustSupportModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        SupportTicketID = sdr["SupportTicketID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        IssueDescription = sdr["IssueDescription"].ToString(),
                        ResolutionStatus = sdr["ResolutionStatus"].ToString(),
                        ResolutionDate = Convert.ToDateTime(sdr["ResolutionDate"])


                    });
                }
                conn.Close();
            }

            return View(cust);
        }


        private CustSupportModel objDetail(int id)
        {

            CustSupportModel cust = new CustSupportModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwone_csupport", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    cust = new CustSupportModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        SupportTicketID = sdr["SupportTicketID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        IssueDescription = sdr["IssueDescription"].ToString(),
                        ResolutionStatus = sdr["ResolutionStatus"].ToString(),
                        ResolutionDate = Convert.ToDateTime(sdr["ResolutionDate"])


                    };
                }
                conn.Close();
            }

            return cust;

        }



        // GET: CustSupport/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetail(id));
        }

        // GET: CustSupport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustSupport/Create
        [HttpPost]
        public ActionResult Create(CustSupportModel cust)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_csupport", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SupportTicketID", cust.SupportTicketID);
                    cmd.Parameters.AddWithValue("@CustomerID", cust.CustomerID);
                    cmd.Parameters.AddWithValue("@IssueDescription", cust.IssueDescription);
                    cmd.Parameters.AddWithValue("@ResolutionStatus", cust.ResolutionStatus);
                    cmd.Parameters.AddWithValue("@ResolutionDate", cust.ResolutionDate);

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

        // GET: CustSupport/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetail(id));
        }

        // POST: CustSupport/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustSupportModel cust)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_update_csupport", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@SupportTicketID", cust.SupportTicketID);
                    cmd.Parameters.AddWithValue("@CustomerID", cust.CustomerID);
                    cmd.Parameters.AddWithValue("@IssueDescription", cust.IssueDescription);
                    cmd.Parameters.AddWithValue("@ResolutionStatus", cust.ResolutionStatus);
                    cmd.Parameters.AddWithValue("@ResolutionDate", cust.ResolutionDate);

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

        // GET: CustSupport/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetail(id));
        }

        // POST: CustSupport/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_delete_csupport", conn);
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
            List<CustSupportModel> cust = new List<CustSupportModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_csupport", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    cust.Add(new CustSupportModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        SupportTicketID = sdr["SupportTicketID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        IssueDescription = sdr["IssueDescription"].ToString(),
                        ResolutionStatus = sdr["ResolutionStatus"].ToString(),
                        ResolutionDate = Convert.ToDateTime(sdr["ResolutionDate"])


                    });
                }
                conn.Close();
            }

            return View(cust);
        }



        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<CustSupportModel> cust = new List<CustSupportModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_search_csupport", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    cust.Add(new CustSupportModel
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        SupportTicketID = sdr["SupportTicketID"].ToString(),
                        CustomerID = sdr["CustomerID"].ToString(),
                        IssueDescription = sdr["IssueDescription"].ToString(),
                        ResolutionStatus = sdr["ResolutionStatus"].ToString(),
                        ResolutionDate = Convert.ToDateTime(sdr["ResolutionDate"])


                    });
                }
                conn.Close();
            }

            return View(cust);
        }






















































    }
}
