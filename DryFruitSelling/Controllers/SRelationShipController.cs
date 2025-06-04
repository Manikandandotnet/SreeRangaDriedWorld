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
    public class SRelationShipController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: SRelationShip
        public ActionResult Index()
        {
            List<SRelationShip> relation = new List<SRelationShip>();
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_SRelation", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    relation.Add(new SRelationShip
                    { 
                    id = Convert.ToInt32(sdr["id"]),
                        SupplierEngagementID = sdr["SupplierEngagementID"].ToString(),
                        SupplierID = sdr["SupplierID"].ToString(),
                        EngagementDate = Convert.ToDateTime(sdr["EngagementDate"]),
                        EngagementType = sdr["EngagementType"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    });
                }
                conn.Close();
            }

            return View(relation);
        }



        private SRelationShip objDetail(int id)
        {
            SRelationShip relation = new SRelationShip();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwone_SRelation", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    relation = new SRelationShip
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        SupplierEngagementID = sdr["SupplierEngagementID"].ToString(),
                        SupplierID = sdr["SupplierID"].ToString(),
                        EngagementDate = Convert.ToDateTime(sdr["EngagementDate"]),
                        EngagementType = sdr["EngagementType"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    };
                }
                conn.Close();
            }

            return relation;
        }





        // GET: SRelationShip/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetail(id));
        }

        // GET: SRelationShip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SRelationShip/Create
        [HttpPost]
        public ActionResult Create(SRelationShip relation)
        {
            try
            {
                // TODO: Add insert logic here


                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_SRelation", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SupplierEngagementID", relation.SupplierEngagementID);
                    cmd.Parameters.AddWithValue("@SupplierID", relation.SupplierID);
                    cmd.Parameters.AddWithValue("@EngagementDate", relation.EngagementDate);
                    cmd.Parameters.AddWithValue("@EngagementType", relation.EngagementType);
                    cmd.Parameters.AddWithValue("@Notes", relation.Notes);
                   
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

        // GET: SRelationShip/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetail(id));
        }

        // POST: SRelationShip/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SRelationShip relation)
        {
            try
            {
                // TODO: Add update logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_update_SRelation", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.Parameters.AddWithValue("@SupplierEngagementID", relation.SupplierEngagementID);
                    cmd.Parameters.AddWithValue("@SupplierID", relation.SupplierID);
                    cmd.Parameters.AddWithValue("@EngagementDate", relation.EngagementDate);
                    cmd.Parameters.AddWithValue("@EngagementType", relation.EngagementType);
                    cmd.Parameters.AddWithValue("@Notes", relation.Notes);

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

        // GET: SRelationShip/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetail(id));
        }

        // POST: SRelationShip/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_delete_SRelation", conn);
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
            List<SRelationShip> relation = new List<SRelationShip>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_SRelation", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    relation.Add(new SRelationShip
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        SupplierEngagementID = sdr["SupplierEngagementID"].ToString(),
                        SupplierID = sdr["SupplierID"].ToString(),
                        EngagementDate = Convert.ToDateTime(sdr["EngagementDate"]),
                        EngagementType = sdr["EngagementType"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    });
                }
                conn.Close();
            }

            return View(relation);
        }








        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<SRelationShip> relation = new List<SRelationShip>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_search_SRelation", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    relation.Add(new SRelationShip
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        SupplierEngagementID = sdr["SupplierEngagementID"].ToString(),
                        SupplierID = sdr["SupplierID"].ToString(),
                        EngagementDate = Convert.ToDateTime(sdr["EngagementDate"]),
                        EngagementType = sdr["EngagementType"].ToString(),
                        Notes = sdr["Notes"].ToString()


                    });
                }
                conn.Close();
            }

            return View(relation);
        }




















































    }
}
