using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointment.Models
{
    public class MedicalHistory
    {
        public bool AdrenalLeision { get; set; }
        public bool CardiacTransplant { get; set; }
        public bool HypoplasticLeftHeart { get; set; }
        public bool PulmonaryEdema { get; set; }
        public bool AdvancedLiverDisease { get; set; }

        public bool HistoryDisease { get; set; }
    }
}