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
    public class QuickContactController : Controller
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;


        // GET: QuickContact
        public ActionResult Index()
        {
            List<contactus> contact = new List<contactus>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwall_contactus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    contact.Add(new contactus                   {
                        id = Convert.ToInt32(sdr["id"]),
                       
                        Name = sdr["Name"].ToString(),
                       
                        Email = sdr["Email"].ToString(),
                        Phone = sdr["Phone"].ToString(),

                        Message = sdr["Message"].ToString()

                    });
                }

                conn.Close();

            }

            return View(contact);
        }



        private contactus objDetails(int id)
        {

            contactus contact = new contactus();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwone_contactus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    contact = new contactus
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Name = sdr["Name"].ToString(),

                        Email = sdr["Email"].ToString(),
                        Phone = sdr["Phone"].ToString(),

                        Message = sdr["Message"].ToString()

                    };
                }

                conn.Close();

            }

            return contact;


        }



        // GET: QuickContact/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetails(id));
        }

        // GET: QuickContact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuickContact/Create
        [HttpPost]
        public ActionResult Create(contactus contact)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_contactus", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", contact.Name);
                               
                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                    cmd.Parameters.AddWithValue("@Phone", contact.Phone);

                    cmd.Parameters.AddWithValue("@Message", contact.Message);


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

        // GET: QuickContact/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetails(id));
        }

        // POST: QuickContact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, contactus contact)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_contactus", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Name", contact.Name);

                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                    cmd.Parameters.AddWithValue("@Phone", contact.Phone);

                    cmd.Parameters.AddWithValue("@Message", contact.Message);


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

        // GET: QuickContact/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetails(id));
        }

        // POST: QuickContact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, contactus contact)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete_contactus", conn);
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
            List<contactus> contact = new List<contactus>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwall_contactus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    contact.Add(new contactus
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Name = sdr["Name"].ToString(),

                        Email = sdr["Email"].ToString(),
                        Phone = sdr["Phone"].ToString(),

                        Message = sdr["Message"].ToString()

                    });
                }

                conn.Close();

            }

            return View(contact);
        }










        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<contactus> contact = new List<contactus>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_search_contactus", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Searchdata",Search);

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    contact.Add(new contactus
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        Name = sdr["Name"].ToString(),

                        Email = sdr["Email"].ToString(),
                        Phone = sdr["Phone"].ToString(),

                        Message = sdr["Message"].ToString()

                    });
                }

                conn.Close();

            }

            return View(contact);
        }































































    }
}
