using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicProject.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace ClinicProject.DAL
{
    public class ClinicDAL
    {
        public string cnn = "";

        public ClinicDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:ClinicConn").Value;
        }

        public int LogCon(LoginDetails log)
        {


            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Validate", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", log.UserName);
            cmd.Parameters.AddWithValue("@pass", log.UserPassword);
            con.Open();
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return (0);

            con.Close();
            return (1);

        }

        public int DoctorDetail(Doctor doc)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Doctorproc", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Doc_Fname", doc.Doctor_FirstName);
            cmd.Parameters.AddWithValue("@Doc_Lname", doc.Doctor_LastName);
            cmd.Parameters.AddWithValue("@Gen", doc.Gender);
            cmd.Parameters.AddWithValue("@Spl", doc.Specialization);
            cmd.Parameters.AddWithValue("@hrs", doc.Visiting_Hours);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int PatientDetail(Patients pat)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("Patientproc", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pat_Fname", pat.Patient_FirstName);
            cmd.Parameters.AddWithValue("@pat_Lname", pat.Patient_LastName);
            cmd.Parameters.AddWithValue("@Gen", pat.Gender);
            cmd.Parameters.AddWithValue("@age", pat.Age);
            cmd.Parameters.AddWithValue("@dob", pat.DOB);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
         
        public int ScheduleDetail(Schedules sch)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("ScheduleProc", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patid", sch.PatientId);
            cmd.Parameters.AddWithValue("@Spl", sch.Specialization);
            cmd.Parameters.AddWithValue("@doc", sch.Doctor);
            cmd.Parameters.AddWithValue("@visit", sch.VisitDate);
            cmd.Parameters.AddWithValue("@v_time", sch.AppointmentTime);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public List<Schedules> ScheduleView()
        {
            List<Schedules> Listschedule = new List<Schedules>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetSchedule", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Listschedule.Add(new Schedules()
                        {
                            AppointmentID = int.Parse(reader["AppointmentID"].ToString()),
                            PatientId = int.Parse(reader["PatientId"].ToString()),
                            Specialization = reader["Specialization"].ToString(),
                            Doctor = reader["Doctor"].ToString(),
                             VisitDate = reader["VisitDate"].ToString(),
                            AppointmentTime = reader["AppointmentTime"].ToString()
                        });
                    }
                }
            }
            return Listschedule;
         }


        public List<Schedules> Cancellation ()
        {
            List<Schedules> Listcancel = new List<Schedules>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetSchedule", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Listcancel.Add(new Schedules()
                        {
                            AppointmentID = int.Parse(reader["AppointmentID"].ToString()),
                            PatientId = int.Parse(reader["PatientId"].ToString()),
                            Specialization = reader["Specialization"].ToString(),
                            Doctor = reader["Doctor"].ToString(),
                            VisitDate = reader["VisitDate"].ToString(),
                            AppointmentTime = reader["AppointmentTime"].ToString()
                        });
                    }
                }
            }
            return Listcancel;
        }

        public int CancelDetails(Schedules cad)
        {
            SqlConnection con = new SqlConnection(cnn);
            SqlCommand cmd = new SqlCommand("CancelAppoint", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patid", cad.PatientId);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }



        public List<Doctor>DoctorAppoint()
        {
            List<Doctor> Listdoctor = new List<Doctor>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("DoctorApp", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Listdoctor.Add(new Doctor()
                        {
                            DoctorID = int.Parse(reader["DoctorID"].ToString()),
                            Doctor_FirstName = reader["Doctor_FirstName"].ToString(),
                            Doctor_LastName = reader["Doctor_LastName"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Specialization = reader["Specialization"].ToString(),
                            Visiting_Hours=reader["Visiting_Hours"].ToString()
                        });
                    }
                }
            }
            return Listdoctor;
        }

        public List<Patients> PatientAppoint()
        {
            List<Patients> Listpatient = new List<Patients>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("PatientApp", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Listpatient.Add(new Patients()
                        {
                            PatientId = int.Parse(reader["PatientId"].ToString()),
                            Patient_FirstName = reader["Patient_FirstName"].ToString(),
                            Patient_LastName = reader["Patient_LastName"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Age = int.Parse(reader["Age"].ToString()),
                            DOB = reader["DOB"].ToString()
                        });
                    }
                }
            }
            return Listpatient;
        }

    }
    }
