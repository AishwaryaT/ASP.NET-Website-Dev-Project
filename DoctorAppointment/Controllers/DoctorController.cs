using DoctorAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace DoctorAppointment.Controllers
{
    public class DoctorController : Controller
    {
        //
        // GET: /Doctor/
        public ActionResult AddPatient()
        {
                if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {

                return RedirectToAction("MyLogin", "DLogin");
            }
        }

        [HttpPost]
        public ActionResult AddPatient(DoctorModel model)
        {
            bool rtnfield = false;
            if(model.Command == "Save")
            {
                for(int i=0; i< model.MedicalHistoryList.Count; i++)
                {

                    if(!rtnfield)
                    {
                        if(model.MedicalHistoryList[i])
                        {
                            model.MedicalHistoryString = i.ToString();
                            rtnfield = true;
                        }
                       
                    }
                    else
                    {
                        if (model.MedicalHistoryList[i])
                        {
                            model.MedicalHistoryString =  model.MedicalHistoryString  + "," + i.ToString();
                           
                        }
                    }
                }
                rtnfield = false;
                for (int i = 0; i < model.RiskFactorList.Count; i++)
                {

                    if (!rtnfield)
                    {
                        if (model.RiskFactorList[i])
                        {
                            model.RiskFactorString = i.ToString();
                            rtnfield = true;
                        }

                    }
                    else
                    {
                        if (model.RiskFactorList[i])
                        {
                            model.RiskFactorString = model.RiskFactorString + "," + i.ToString();

                        }
                    }
                }
                rtnfield = false;
                for (int i = 0; i < model.IncidentalFindingsList.Count; i++)
                {

                    if (!rtnfield)
                    {
                        if (model.IncidentalFindingsList[i])
                        {
                            model.IncidentalFindingsString = i.ToString();
                            rtnfield = true;
                        }

                    }
                    else
                    {
                        if (model.IncidentalFindingsList[i])
                        {
                            model.IncidentalFindingsString = model.IncidentalFindingsString + "," + i.ToString();

                        }
                    }
                }
            }

            else if (model.Command == "Cancel") 
            {
                return RedirectToAction("AddPatient", "Doctor");
            }

            string ConnString = WebConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            DBConnection objDB = new DBConnection(ConnString);
            bool rtnval = objDB.InsertPatientInfo(model);

            if(rtnval)
            {
                model.MessageString = "Patient Record added successfully!!";

            }
            else
            {
                model.MessageString = "Patient Record not added!";
            }

            return View(model);
        }
        
	}
}