using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoctorAppointment.Models;
using System.Web.Configuration;

namespace DoctorAppointment.Controllers
{
    public class SignUpController : Controller
    {
        //
        // GET: /SignUp/
        public ActionResult Register()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(SignUpModel model)
        {
            string ConnString = WebConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            DBConnection objDB = new DBConnection(ConnString);
            bool rtnval = objDB.InsertSignUpInfo(model);

            if (rtnval && model.Command=="SignUp")
            {
                model.MessageString = "Registered Successfully!!";
                return RedirectToAction("AddPatient", "Doctor");

            }
            else
            {
                model.MessageString = "Registration Unsuccessful";
            }
            return View(model);
        }

    }
}
