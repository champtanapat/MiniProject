﻿using ABCOnline.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCOnline.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        TestEntities1 db = new TestEntities1();
        SqlCommand cmd = null;
        SqlConnection sqlConn = null;
        SqlDataReader reader = null;
        public ActionResult Index(int? Id)
        {
            Registers register = new Registers();
            var allRegister = (from s in db.Registers select s).ToList();
            ViewBag.dataList = allRegister;
            return View(register);
        }
        [HttpPost]
        public ActionResult Save(Register register)
        {
            try
            {
                #region update 
                if (register.id != 0)
                {
                    Register update_Data = db.Registers.Where(s => s.id == register.id).FirstOrDefault();
                    update_Data.FirstName = register.FirstName.ToString();
                    update_Data.LastName = register.LastName;
                    update_Data.Birthday = register.Birthday;
                    update_Data.Address = register.Address;
                    update_Data.Age = CalAge(register.Birthday);
                }
                #endregion update 

                #region insert 
                else
                {
                    
                    register.Age = CalAge(register.Birthday);
                    db.Registers.Add(register);
                }
                #endregion insert 

                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            var allRegister = (from s in db.Registers select s).ToList();
            ViewBag.dataList = allRegister;
            return PartialView("_AddMember");
        }

        private int CalAge(DateTime? birthday)
        {
            DateTime thisDay = DateTime.Today;
            

            if (birthday <= thisDay)
            {
                string dateToday_ = thisDay.Year.ToString();
                string birthday_ = Convert.ToDateTime(birthday).ToString("yyyy");
                int temp = Convert.ToInt32(dateToday_) - Convert.ToInt32(birthday_);
                return temp;
            }
            return 0;
        }

        public ActionResult Edit(int? Id)
        {
            Registers register = new Registers();
                if (Id == null)
                {
                    return new HttpStatusCodeResult(400, null);
                }
                else
                {
                    var del = db.Registers.Find(Id);
                    register = new Registers()
                        {
                            Id = del.id,
                            firstName = del.FirstName,
                            lastName = del.LastName,
                            address = del.Address,
                            birthday = Convert.ToDateTime(del.Birthday).ToString("MM/dd/yyyy"),
                        };
              
                }
            return View("Index", register);
        }

        public ActionResult Delete(int? Id) 
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectBase"].ConnectionString);
            cnn.Open();
            var del = db.Registers.Find(Id);
            try
            {
                if (Id == null)
                {
                    return new HttpStatusCodeResult(400, null);
                }
                else
                {
                    string sql = "EXEC  dbo.DeleteMember @IdMember ";
                    cmd = new SqlCommand(sql);
                    cmd.Connection = cnn;
                    cmd.Parameters.Add("@IdMember", SqlDbType.NVarChar, 10);
                    cmd.Parameters["@IdMember"].Value = Id.ToString();
                    var ss = cmd.ExecuteNonQuery();
                    cnn.Close();

                    //reader = cmd.ExecuteReader();
                    //Register register = new Register();
                    //while (reader.Read())
                    //{
                    //    register.FirstName = reader["FirstName"].ToString();
                    //    register.LastName = reader["LastName"].ToString();
                    //    register.Address = reader["Address"].ToString();
                    //    register.Age = reader["Age"] != null ? Convert.ToInt32(reader["Age"]) : 0;
                    //}

                }
            }
            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }


        public ActionResult Detail(int? Id)
        {
            Register register = db.Registers.Where(s => s.id == Id).FirstOrDefault();

            Registers registers = new Registers();
            registers.firstName = register.FirstName;
            registers.lastName = register.LastName;
            registers.address = register.Address;
            registers.birthday = Convert.ToDateTime(register.Birthday).ToString("MM/dd/yyyy");
            registers.age = register.Age != 0 ? register.Age.Value : 0;
            return View(registers);
        }
    }
}