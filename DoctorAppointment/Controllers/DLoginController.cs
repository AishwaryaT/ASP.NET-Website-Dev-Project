using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorAppointment.Models;
using System.Web.Configuration;


namespace DoctorAppointment.Models
{
    public class DLoginController : Controller
    {
        //
        // GET: /DLogin/
        public ActionResult MyLogin()
        {
            return View();
        }

        public ActionResult LogOut()
        {

            Session.Abandon();
            return RedirectToAction("MyLogin", "DLogin");
        }

        [HttpPost]
        public ActionResult MyLogin(LoginModel model)
        {
            string ConnString = WebConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            DBConnection objDB = new DBConnection(ConnString);
            //bool rtnval = objDB.GetLoginInfo(model.UserName, model.Password);
            if (model.Command == "Login")
              {
                  bool rtnval = objDB.GetLoginInfo(model.UserName, model.Password);
                  if(rtnval)
                        {
                            Session["UserName"] = model.UserName;  
                            return RedirectToAction("AddPatient", "Doctor");
                        }
                  else
                        {
                            model.LoginMessage = "Incorrect Credentials, Try again!!";
                         }
            
            }           
                if (model.Command == "SignUp")
                    return RedirectToAction("Register", "SignUp");

            return View(model);
        }


	}
}