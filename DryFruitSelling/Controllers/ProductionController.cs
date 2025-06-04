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
    public class ProductionController : Controller
    {



        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;




        // GET: Production
        public ActionResult Index()
        {
            List<Production> productions = new List<Production>();
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwall_production", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    productions.Add(new Production
                        {
                    
                        id = Convert.ToInt32(sdr["id"]),
                        ProductionID = sdr["ProductionID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        ProcessingStage = sdr["ProcessingStage"].ToString(),
                        PackagingDate = Convert.ToDateTime(sdr["PackagingDate"])



                    });
                }


                conn.Close();

            }


            return View(productions);
        }




        // GET: Production/Details/5
        public ActionResult Details(int id)
        {

            Production productions = new Production();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_getone_production", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    productions = new Production
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        ProductionID = sdr["ProductionID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        ProcessingStage = sdr["ProcessingStage"].ToString(),
                        PackagingDate = Convert.ToDateTime(sdr["PackagingDate"])



                    };
                }


                conn.Close();

            }


            return View(productions);
        }




        // GET: Production/Create
        public ActionResult Create()
        {
            return View();
        }





        // POST: Production/Create
        [HttpPost]
        public ActionResult Create(Production productions)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_production", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductionID",productions.ProductionID);
                    cmd.Parameters.AddWithValue("@FruitType",productions.FruitType);
                    cmd.Parameters.AddWithValue("@ProcessingStage",productions.ProcessingStage);
                    cmd.Parameters.AddWithValue("@PackagingDate",productions.PackagingDate);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Success"] = "Data Send Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data send failure!";
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




        // GET: Production/Edit/5
        public ActionResult Edit(int id)
        {

            Production productions = new Production();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_getone_production", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    productions = new Production
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        ProductionID = sdr["ProductionID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        ProcessingStage = sdr["ProcessingStage"].ToString(),
                        PackagingDate = Convert.ToDateTime(sdr["PackagingDate"])



                    };
                }


                conn.Close();

            }


            return View(productions);
        }




        // POST: Production/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Production productions)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_production", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@ProductionID", productions.ProductionID);
                    cmd.Parameters.AddWithValue("@FruitType", productions.FruitType);
                    cmd.Parameters.AddWithValue("@ProcessingStage", productions.ProcessingStage);
                    cmd.Parameters.AddWithValue("@PackagingDate", productions.PackagingDate);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Success"] = "Data updated Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data updated failure!";
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




        // GET: Production/Delete/5
        public ActionResult Delete(int id)
        {
            Production productions = new Production();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_getone_production", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    productions = new Production
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        ProductionID = sdr["ProductionID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        ProcessingStage = sdr["ProcessingStage"].ToString(),
                        PackagingDate = Convert.ToDateTime(sdr["PackagingDate"])



                    };
                }


                conn.Close();

            }


            return View(productions);
        }




        // POST: Production/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Production productions)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete_production", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Success"] = "Data Deleted Successfully!";
                    }
                    else
                    {
                        TempData["Error"] = "Data Deleted failure!";
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
            List<Production> productions = new List<Production>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwall_production", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    productions.Add(new Production
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        ProductionID = sdr["ProductionID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        ProcessingStage = sdr["ProcessingStage"].ToString(),
                        PackagingDate = Convert.ToDateTime(sdr["PackagingDate"])



                    });
                }


                conn.Close();

            }


            return View(productions);
        }





        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<Production> productions = new List<Production>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_search_production", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    productions.Add(new Production
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        ProductionID = sdr["ProductionID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        ProcessingStage = sdr["ProcessingStage"].ToString(),
                        PackagingDate = Convert.ToDateTime(sdr["PackagingDate"])

                    });
                }


                conn.Close();

            }


            return View(productions);
        }










































    }
}
