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
    public class InventoryController : Controller
    {


        string strcon = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        // GET: Inventory
        public ActionResult Index()
        {
            List<inventory> inventory = new List<inventory>();

            using(SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwall_inventory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                    inventory.Add(new inventory
                    { 
                    
                    id=Convert.ToInt32(sdr["id"]),
                        InventoryID = sdr["InventoryID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        PreservationStatus = sdr["PreservationStatus"].ToString(),
                        ExpirationDate = Convert.ToDateTime(sdr["ExpirationDate"])


                    });
                }
                conn.Close();
            }


            return View(inventory);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            inventory inventory = new inventory();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_getone_inventory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id",id);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    inventory = new inventory
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        InventoryID = sdr["InventoryID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        PreservationStatus = sdr["PreservationStatus"].ToString(),
                        ExpirationDate = Convert.ToDateTime(sdr["ExpirationDate"])


                    };
                }
                conn.Close();
            }


            return View(inventory);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(inventory inventory)
        {
            try
            {
                // TODO: Add insert logic here


                using(SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert_inventory", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@InventoryID", inventory.InventoryID);
                    cmd.Parameters.AddWithValue("@FruitType", inventory.FruitType);

                    cmd.Parameters.AddWithValue("@Quantity", inventory.Quantity);


                    cmd.Parameters.AddWithValue("@PreservationStatus", inventory.PreservationStatus);
                    cmd.Parameters.AddWithValue("@ExpirationDate", inventory.ExpirationDate);
                    
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["success"] = "Data send successfully!";

                    }
                    else
                    {
                        TempData["error"] = "Data send failure!";
                    }
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            inventory inventory = new inventory();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_getone_inventory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    inventory = new inventory
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        InventoryID = sdr["InventoryID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        PreservationStatus = sdr["PreservationStatus"].ToString(),
                        ExpirationDate = Convert.ToDateTime(sdr["ExpirationDate"])


                    };
                }
                conn.Close();
            }


            return View(inventory);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, inventory inventory)
        {
            try
            {
                // TODO: Add update logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_update_inventory", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);

                    cmd.Parameters.AddWithValue("@InventoryID", inventory.InventoryID);
                    cmd.Parameters.AddWithValue("@FruitType", inventory.FruitType);

                    cmd.Parameters.AddWithValue("@Quantity", inventory.Quantity);

                    cmd.Parameters.AddWithValue("@PreservationStatus", inventory.PreservationStatus);
                    cmd.Parameters.AddWithValue("@ExpirationDate", inventory.ExpirationDate);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["success"] = "Data updated successfully!";

                    }
                    else
                    {
                        TempData["error"] = "Data updated failure!";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            inventory inventory = new inventory();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_getone_inventory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    inventory = new inventory
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        InventoryID = sdr["InventoryID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        PreservationStatus = sdr["PreservationStatus"].ToString(),
                        ExpirationDate = Convert.ToDateTime(sdr["ExpirationDate"])


                    };
                }
                conn.Close();
            }


            return View(inventory);
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_delete_inventory", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        TempData["success"] = "Data Deleted successfully!";

                    }
                    else
                    {
                        TempData["error"] = "Data Deleted failure!";
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
            List<inventory> inventory = new List<inventory>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_vwall_inventory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    inventory.Add(new inventory
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        InventoryID = sdr["InventoryID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        PreservationStatus = sdr["PreservationStatus"].ToString(),
                        ExpirationDate = Convert.ToDateTime(sdr["ExpirationDate"])


                    });
                }
                conn.Close();
            }


            return View(inventory);
        }







        [HttpPost]
        public ActionResult Search(string Search)
        {
            List<inventory> inventory = new List<inventory>();

            using (SqlConnection conn = new SqlConnection(strcon))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_search_inventory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Searchdata", Search);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    inventory.Add(new inventory
                    {

                        id = Convert.ToInt32(sdr["id"]),
                        InventoryID = sdr["InventoryID"].ToString(),
                        FruitType = sdr["FruitType"].ToString(),
                        Quantity = Convert.ToInt32(sdr["Quantity"]),
                        PreservationStatus = sdr["PreservationStatus"].ToString(),
                        ExpirationDate = Convert.ToDateTime(sdr["ExpirationDate"])


                    });
                }
                conn.Close();
            }


            return View(inventory);
        }











    }
}
