using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DoctorAppointment.Models
{
    public class DBConnection
    {
        private string connString { get; set; }
        public DBConnection(string conn)
        {
            connString = conn;
        }

        public bool GetLoginInfo(string username, string password)
        {
            bool rtnval = false;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();

            // create a SqlCommand object for this connection
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT Username,Password FROM MyUserTable WHERE UserName ='" + username + "' and password='" + password+"'";

            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader();

            // display the results
            while (reader.Read())
            {
               // string output = reader.ToString();
                if(reader.FieldCount > 0)
                { 
                    rtnval = true;
                    //string username = reader.GetSqlValue(0).ToString();
                }
                
               // Console.WriteLine(output);
            }

            // close the connection
            reader.Close();
            conn.Close();

            return rtnval;
        }

        public bool InsertSignUpInfo(SignUpModel objDm)
        {
            bool rtnval = false;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            // create a SqlCommand object for this connection
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "Insert into MyUserTable values ('" + objDm.ssn + "'" + ",'" + objDm.PatientFirstName + "'" + ",'" + objDm.PatientLastName + "'" + ",'" + objDm.UserName + "'" + ",'" + objDm.Password + "'" + ",'" + objDm.ConfirmPassword + "'" + ",'" + objDm.primaryinsurance + "'" + ",'" + objDm.phoneNo + "')";
            command.CommandType = CommandType.Text;
            int ival = command.ExecuteNonQuery();
            if (ival != -1)
            {
                rtnval = true;
            }
            return rtnval;
        }
        public bool InsertPatientInfo(DoctorModel objDm)
        {

            bool rtnval = false;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();

            // create a SqlCommand object for this connection
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "Insert into PatientTable values ('"+ objDm.ssn + "'"+ ",'" + objDm.PatientName + "'"+ ",'" + objDm.visittype + "'"+ ",'" +  objDm.Visitdate.ToString() + "'"+ ",'" +  objDm.visitlocation + "'"+ ",'" +  objDm.primaryinsurance + "'"+ ",'" +  objDm.Height.ToString() + "'"+ ",'" + objDm.Weight.ToString() + "'"+ ",'" + objDm.referredby + "'"+ ",0"+ "," + Convert.ToInt32(objDm.NoofMonth.ToString()) + ""+ ",'" + Convert.ToInt32(objDm.visitrequired.ToString()) + "'"+ ",'" + objDm.MedicalHistoryString + "'"+ ",'" +  objDm.RiskFactorString + "'"+ ",'" + objDm.IncidentalFindingsString +"')";        

            command.CommandType = CommandType.Text;

            int ival = command.ExecuteNonQuery(); 

            if(ival != -1)
            { rtnval = true;
            }

            return rtnval;
        }
    }
}