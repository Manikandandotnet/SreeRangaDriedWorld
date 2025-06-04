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
    public class HResourceController : Controller
    {

        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        // GET: HResource
        public ActionResult Index()
        {
            List<HResource>  hr = new List<HResource>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new  SqlCommand("usp_vwall_HResource", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    hr.Add(new HResource
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        EmployeeID = sdr["EmployeeID"].ToString(),
                        EmployeeName = sdr["EmployeeName"].ToString(),
                        Position = sdr["Position"].ToString(),
                        HireDate = Convert.ToDateTime(sdr["HireDate"]),
                        Salary = Convert.ToDecimal(sdr["Salary"]),
                        PerformanceRating = sdr["PerformanceRating"].ToString(),
                        Attendance = sdr["Attendance"].ToString()

                    });
                }
                conn.Close();
            }
            return View(hr);
        }



        private HResource objDetail(int id)
        {
            HResource hr = new HResource();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_vwone_HResource", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    hr = new HResource
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        EmployeeID = sdr["EmployeeID"].ToString(),
                        EmployeeName = sdr["EmployeeName"].ToString(),
                        Position = sdr["Position"].ToString(),
                        HireDate = Convert.ToDateTime(sdr["HireDate"]),
                        Salary = Convert.ToDecimal(sdr["Salary"]),
                        PerformanceRating = sdr["PerformanceRating"].ToString(),
                        Attendance = sdr["Attendance"].ToString()

                    };
                }
                conn.Close();
            }
            return hr;

        }



        // GET: HResource/Details/5
        public ActionResult Details(int id)
        {
            return View(objDetail(id));
        }

        // GET: HResource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HResource/Create
        [HttpPost]
        public ActionResult Create(HResource hr)
        {
            try
            {
                // TODO: Add insert logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("usp_insert_HResource", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeID", hr.EmployeeID);
                    cmd.Parameters.AddWithValue("@EmployeeName", hr.EmployeeName);
                    cmd.Parameters.AddWithValue("@Position", hr.Position);
                    cmd.Parameters.AddWithValue("@HireDate", hr.HireDate);
                    cmd.Parameters.AddWithValue("@Salary", hr.Salary);
                    cmd.Parameters.AddWithValue("@PerformanceRating", hr.PerformanceRating);
                    cmd.Parameters.AddWithValue("@Attendance", hr.Attendance);

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

        // GET: HResource/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objDetail(id));
        }

        // POST: HResource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HResource hr)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("usp_update_HResource", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.Parameters.AddWithValue("@EmployeeID", hr.EmployeeID);
                    cmd.Parameters.AddWithValue("@EmployeeName", hr.EmployeeName);
                    cmd.Parameters.AddWithValue("@Position", hr.Position);
                    cmd.Parameters.AddWithValue("@HireDate", hr.HireDate);
                    cmd.Parameters.AddWithValue("@Salary", hr.Salary);
                    cmd.Parameters.AddWithValue("@PerformanceRating", hr.PerformanceRating);
                    cmd.Parameters.AddWithValue("@Attendance", hr.Attendance);

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

        // GET: HResource/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objDetail(id));
        }

        // POST: HResource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("usp_delete_HResource", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id", id);
                
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
            List<HResource> hr = new List<HResource>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_vwall_HResource", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    hr.Add(new HResource
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        EmployeeID = sdr["EmployeeID"].ToString(),
                        EmployeeName = sdr["EmployeeName"].ToString(),
                        Position = sdr["Position"].ToString(),
                        HireDate = Convert.ToDateTime(sdr["HireDate"]),
                        Salary = Convert.ToDecimal(sdr["Salary"]),
                        PerformanceRating = sdr["PerformanceRating"].ToString(),
                        Attendance = sdr["Attendance"].ToString()




                    });
                }
                conn.Close();
            }
            return View(hr);
        }










        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<HResource> hr = new List<HResource>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("usp_search_HResource", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    hr.Add(new HResource
                    {
                        id = Convert.ToInt32(sdr["id"]),

                        EmployeeID = sdr["EmployeeID"].ToString(),
                        EmployeeName = sdr["EmployeeName"].ToString(),
                        Position = sdr["Position"].ToString(),
                        HireDate = Convert.ToDateTime(sdr["HireDate"]),
                        Salary = Convert.ToDecimal(sdr["Salary"]),
                        PerformanceRating = sdr["PerformanceRating"].ToString(),
                        Attendance = sdr["Attendance"].ToString()




                    });
                }
                conn.Close();
            }
            return View(hr);
        }









































































    }
}
