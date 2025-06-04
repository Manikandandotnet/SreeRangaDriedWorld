using DryFruitSelling.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DryFruitSelling.Controllers
{
    public class SupplierController : Controller
    {


        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        
        
        // GET: Supplier
        public ActionResult Index()
        {
            List<Supplier>  suppliers = new List<Supplier>();
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwall_supplier", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr= cmd.ExecuteReader();
                while(sdr.Read())
                {
                    suppliers.Add(new Supplier
                    {
                        id =Convert.ToInt32(sdr["id"]),
                        SupplierID = sdr["SupplierID"].ToString(),
                        SupplierName = sdr["SupplierName"].ToString(),
                        ContactNumber = sdr["ContactNumber"].ToString(),
                        Address = sdr["Address"].ToString(),
                        OrderHistory = sdr["OrderHistory"].ToString()

                    });
                }
                conn.Close();
            }


            return View(suppliers);
        }

       


        
        
        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            Supplier suppliers = new Supplier();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_getone_supplier", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    suppliers = new Supplier
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        SupplierID = sdr["SupplierID"].ToString(),
                        SupplierName = sdr["SupplierName"].ToString(),
                        ContactNumber = sdr["ContactNumber"].ToString(),
                        Address = sdr["Address"].ToString(),
                        OrderHistory = sdr["OrderHistory"].ToString()

                    };


                }
                conn.Close();

            }


            return View(suppliers);
        }

        




        
        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(Supplier suppliers)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_supplier", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SupplierID", suppliers.SupplierID);
                    cmd.Parameters.AddWithValue("@SupplierName", suppliers.SupplierName);
                    cmd.Parameters.AddWithValue("@ContactNumber", suppliers.ContactNumber);
                    cmd.Parameters.AddWithValue("@Address", suppliers.Address);
                    cmd.Parameters.AddWithValue("@OrderHistory", suppliers.OrderHistory);

                     int i = cmd.ExecuteNonQuery();
                    
                    if (i > 0) 
                    {
                        TempData["Success"] = "Data send successfully!";  
                    
                    }
                    else
                    {
                        TempData["Error"] = "Data send Failure!";
                    }


                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }










        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {

            Supplier suppliers = new Supplier();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_getone_supplier", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    suppliers = new Supplier
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        SupplierID = sdr["SupplierID"].ToString(),
                        SupplierName = sdr["SupplierName"].ToString(),
                        ContactNumber = sdr["ContactNumber"].ToString(),
                        Address = sdr["Address"].ToString(),
                        OrderHistory = sdr["OrderHistory"].ToString()

                    };
                }
                conn.Close();
            }


            return View(suppliers);
        }






        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Supplier suppliers)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_update_supplier", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id",id);
                    cmd.Parameters.AddWithValue("@SupplierID", suppliers.SupplierID);
                    cmd.Parameters.AddWithValue("@SupplierName", suppliers.SupplierName);
                    cmd.Parameters.AddWithValue("@ContactNumber", suppliers.ContactNumber);
                    cmd.Parameters.AddWithValue("@Address", suppliers.Address);
                    cmd.Parameters.AddWithValue("@OrderHistory", suppliers.OrderHistory);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["Success"] = "Data Updated successfully!";


                    }
                    else
                    {
                        TempData["Error"] = "Data Updated Failure!";

                    }


                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }







        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {

            Supplier suppliers = new Supplier();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_getone_supplier", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    suppliers = new Supplier
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        SupplierID = sdr["SupplierID"].ToString(),
                        SupplierName = sdr["SupplierName"].ToString(),
                        ContactNumber = sdr["ContactNumber"].ToString(),
                        Address = sdr["Address"].ToString(),
                        OrderHistory = sdr["OrderHistory"].ToString()

                    };
                }
                conn.Close();
            }


            return View(suppliers);
        }









        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete_supplier", conn);
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
            List<Supplier> suppliers = new List<Supplier>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwall_supplier", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    suppliers.Add(new Supplier
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        SupplierID = sdr["SupplierID"].ToString(),
                        SupplierName = sdr["SupplierName"].ToString(),
                        ContactNumber = sdr["ContactNumber"].ToString(),
                        Address = sdr["Address"].ToString(),
                        OrderHistory = sdr["OrderHistory"].ToString()

                    });
                }
                conn.Close();
            }


            return View(suppliers);
        }

    



        



        
        [HttpPost]

        public ActionResult Search(string Search)
        {
            List<Supplier> suppliers = new List<Supplier>();
        
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_search_supplier", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata",Search);

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    suppliers.Add(new Supplier
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        SupplierID = sdr["SupplierID"].ToString(),
                        SupplierName = sdr["SupplierName"].ToString(),
                        ContactNumber = sdr["ContactNumber"].ToString(),
                        Address = sdr["Address"].ToString(),
                        OrderHistory = sdr["OrderHistory"].ToString()

                    });
                }
                conn.Close();
            }


            return View(suppliers);
        }








    }
}
