using DryFruitSelling.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DryFruitSelling.Controllers
{
    public class RegisterController : Controller
    {
        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: Register
        public ActionResult Index()
        {

            List<Register> reg = new List<Register>();
            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_Register", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    reg.Add(new Register
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        UserID = sdr["UserID"].ToString(),
                        UserName = sdr["UserName"].ToString(),
                        Email = sdr["Email"].ToString(),
                        PhoneNumber = sdr["PhoneNumber"].ToString(),
                        Password = sdr["Password"].ToString(),
                        CPassword = sdr["CPassword"].ToString(),
                        Address = sdr["Address"].ToString()

                    });
                }
                conn.Close();
            }

            return View(reg);
        }


        private Register objDetail(int id)
        {

            Register reg = new Register();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwone_Register", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    reg = new Register
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        UserID = sdr["UserID"].ToString(),
                        UserName = sdr["UserName"].ToString(),
                        Email = sdr["Email"].ToString(),
                        PhoneNumber = sdr["PhoneNumber"].ToString(),
                        Password = sdr["Password"].ToString(),
                        CPassword = sdr["CPassword"].ToString(),
                        Address = sdr["Address"].ToString()

                    };
                }
                conn.Close();
            }

            return reg;
        }


        // GET: Register/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetail(id));
        }

        // GET: Register/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        [HttpPost]
        public ActionResult Create(Register reg)
        {
            try
            {
                // TODO: Add insert logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    if (reg.Password == reg.CPassword)
                    {


                        conn.Open();
                        SqlCommand cmd = new SqlCommand("usp_insert_Register", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserID", reg.UserID);
                        cmd.Parameters.AddWithValue("@UserName", reg.UserName);
                        cmd.Parameters.AddWithValue("@Email", reg.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", reg.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Password", reg.Password);
                        cmd.Parameters.AddWithValue("@CPassword", reg.CPassword);
                        cmd.Parameters.AddWithValue("@Address", reg.Address);


                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            TempData["Success"] = " Data Send Successfully!";
                        }
                        else
                        {
                            TempData["Error"] = "Data Send Failure!";
                        }


                    }
                    else
                    {
                        TempData["Error"] = "Password is not Match Conform Password!";
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

        // GET: Register/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetail(id));
        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Register reg)
        {
            try
            {
                // TODO: Add update logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    if (reg.Password == reg.CPassword)
                    {


                        conn.Open();
                        SqlCommand cmd = new SqlCommand("usp_update_Register", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@UserID", reg.UserID);
                        cmd.Parameters.AddWithValue("@UserName", reg.UserName);
                        cmd.Parameters.AddWithValue("@Email", reg.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", reg.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Password", reg.Password);
                        cmd.Parameters.AddWithValue("@CPassword", reg.CPassword);
                        cmd.Parameters.AddWithValue("@Address", reg.Address);


                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            TempData["Success"] = " Data updated Successfully!";
                        }
                        else
                        {
                            TempData["Error"] = "Data updated Failure!";
                        }


                    }
                    else
                    {
                        TempData["Error"] = "Password is not Match Conform Password!";
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

        // GET: Register/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetail(id));
        }

        // POST: Register/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {


                        conn.Open();
                        SqlCommand cmd = new SqlCommand("usp_delete_Register", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id",id);
                        

                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            TempData["Success"] = " Data Deleted Successfully!";
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

            List<Register> reg = new List<Register>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_vwall_Register", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    reg.Add(new Register
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        UserID = sdr["UserID"].ToString(),
                        UserName = sdr["UserName"].ToString(),
                        Email = sdr["Email"].ToString(),
                        PhoneNumber = sdr["PhoneNumber"].ToString(),
                        Password = sdr["Password"].ToString(),
                        CPassword = sdr["CPassword"].ToString(),
                        Address = sdr["Address"].ToString()

                    });
                }
                conn.Close();
            }

            return View(reg);
        }


        [HttpPost]
        public ActionResult Search(string Search)
        {

            List<Register> reg = new List<Register>();
            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_search_Register", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    reg.Add(new Register
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        UserID = sdr["UserID"].ToString(),
                        UserName = sdr["UserName"].ToString(),
                        Email = sdr["Email"].ToString(),
                        PhoneNumber = sdr["PhoneNumber"].ToString(),
                        Password = sdr["Password"].ToString(),
                        CPassword = sdr["CPassword"].ToString(),
                        Address = sdr["Address"].ToString()

                    });
                }
                conn.Close();
            }

            return View(reg);
        }



















        public ActionResult RegisteredUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegisteredUser(Register reg)
        {

            try
            {
                // TODO: Add insert logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {

                    if (reg.Password == reg.CPassword)
                    {


                        conn.Open();
                        SqlCommand cmd = new SqlCommand("usp_insert_Register", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserID", reg.UserID);
                        cmd.Parameters.AddWithValue("@UserName", reg.UserName);
                        cmd.Parameters.AddWithValue("@Email", reg.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", reg.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Password", reg.Password);
                        cmd.Parameters.AddWithValue("@CPassword", reg.CPassword);
                        cmd.Parameters.AddWithValue("@Address", reg.Address);


                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            TempData["Success"] = " Data Send Successfully!";
                        }
                        else
                        {
                            TempData["Error"] = "Data Send Failure!";
                        }


                    }
                    else
                    {
                        TempData["Error"] = "Password is not Match Conform Password!";
                    }



                    conn.Close();
                }

                return RedirectToAction("RegisteredUser","Register");
            }
            catch
            {
                return View();
            }
        }

















        public ActionResult UserLogin()
        {
            return View();
        }


        [HttpPost]

        public ActionResult UserLogin(Register reg)
        {


            using (SqlConnection conn = new SqlConnection(strcon))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_login", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", reg.UserID);
                cmd.Parameters.AddWithValue("@UserName", reg.UserName);
                cmd.Parameters.AddWithValue("@CPassword", reg.CPassword);

                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {


                    string a = reg.UserID;

                    if (a[0] == 'A' && a[1] == 'I' && a[2] == 'D' && a != "")
                    {
                        RedirectToAction("AdminPage", "HomePage");
                       
                    }
                    else if(a[0] == 'U' && a[1] == 'S' && a[2] == 'R' && a != "")
                    {
                      return  RedirectToAction("UserPage", "HomePage");
                    }
                    TempData["Success"] = " Login Successfully!";

                }
                else
                {
                    TempData["Error"] = " Login Failure!";
                }

                conn.Close();
            }

            return View();
        }



























    }
}
