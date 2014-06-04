using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace DoctorAppointment.Models
{
    public class DoctorModel
    {
        public string ssn { get; set; }
        public string PatientName { get; set; }
        public string visittype { get; set; }
        [DataType(DataType.Date)]
        public DateTime Visitdate { get; set; }
       // public DateTime ? Visitdate { get; set; }
        public string visitlocation { get; set; }
        public string primaryinsurance { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string referredby { get; set; }
        public bool Followup { get; set; }
        public int NoofMonth { get; set; }
        public string visitrequired { get; set; }
        public string MedicalHistoryString { get; set; }
        public string RiskFactorString { get; set; }
        public string IncidentalFindingsString { get; set; }
        public string Command { get; set; }
        public string MessageString { get; set; }
        public MedictionModel Medication { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public List<bool> MedicalHistoryList { get; set; }
        public List<bool> RiskFactorList { get; set; }
        public List<bool> IncidentalFindingsList { get; set; }
    }
}