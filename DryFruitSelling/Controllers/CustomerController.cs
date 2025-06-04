using DryFruitSelling.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DryFruitSelling.Controllers
{
    public class CustomerController : Controller
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: Customer
        public ActionResult Index()
        {
            List<CustomerModel> cust = new List<CustomerModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_customer", conn);
               cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    cust.Add(new CustomerModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        CustomerID = sdr["CustomerID"].ToString(),
                        CustomerName = sdr["CustomerName"].ToString(),
                        ContactNumber = sdr["ContactNumber"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Address = sdr["Address"].ToString()

                    });
                }

                conn.Close();
            
            }

                return View(cust);
        }



        private CustomerModel objDetails(int id)
        {
            CustomerModel cust = new CustomerModel();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open(); 
                SqlCommand cmd = new SqlCommand("usp_vwone_customer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    cust = new CustomerModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        CustomerID = sdr["CustomerID"].ToString(),
                        CustomerName = sdr["CustomerName"].ToString(),
                        ContactNumber = sdr["ContactNumber"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Address = sdr["Address"].ToString()

                    };
                }

                conn.Close();

            }

            return cust;

        }





        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetails(id));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerModel customer)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon)) 
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insert_customer", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    cmd.Parameters.AddWithValue("@ContactNumber", customer.ContactNumber);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);


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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetails(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerModel customer)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_update_customer", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    cmd.Parameters.AddWithValue("@ContactNumber", customer.ContactNumber);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);


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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetails(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_delete_customer", conn);
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
            List<CustomerModel> cust = new List<CustomerModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_customer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    cust.Add(new CustomerModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        CustomerID = sdr["CustomerID"].ToString(),
                        CustomerName = sdr["CustomerName"].ToString(),
                        ContactNumber = sdr["ContactNumber"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Address = sdr["Address"].ToString()

                    });
                }

                conn.Close();

            }

            return View(cust);
        }



        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<CustomerModel> cust = new List<CustomerModel>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_search_customer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    cust.Add(new CustomerModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        CustomerID = sdr["CustomerID"].ToString(),
                        CustomerName = sdr["CustomerName"].ToString(),
                        ContactNumber = sdr["ContactNumber"].ToString(),
                        Email = sdr["Email"].ToString(),
                        Address = sdr["Address"].ToString()

                    });
                }

                conn.Close();

            }

            return View(cust);
        }

































    }
}
