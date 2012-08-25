using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace StudyEstimator_MVC.Models.Services
{
    public class IStudySvcSQLImpl : IStudySVC
    {
 
        private SqlConnection GetConnection()
        {
            string _Connection = ConfigurationManager.ConnectionStrings["SQLDBConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(_Connection);

            return conn;
        }

        public List<Study> FindAllStudies()
        {        
            SqlConnection conn = GetConnection();
            SqlCommand cmd = conn.CreateCommand();
	        List<Study> studies = new List<Study>();

            using (conn) 
            { 
                conn.Open();
                cmd.CommandText = "SELECT * FROM tbl_studies"; 
                
                 using (var reader = cmd.ExecuteReader()) 
                 { 
                     if (!reader.Read()) 
                         { 
                             return null; 
                         }
                     else
	                 {
                         while (reader.Read())
                         {
                             Study study = new Study(); 
                            study.StudyID = reader.GetInt32(reader.GetOrdinal("study_ID"));
                            study.StudyName = reader.GetString(reader.GetOrdinal("study_name"));
                            study.StudyManager = reader.GetString(reader.GetOrdinal("study_manager"));
                            study.StudyCreated = reader.GetDateTime(reader.GetOrdinal("Study_DateCreated"));
                            studies.Add(study);
                         }
                        
                     } 
                     
                  }
            } 
            conn.Close();
            return studies;
            
        }

        public Study FindStudy(int id)
        {
            // “find” code goes here 
            SqlConnection conn = GetConnection();
            SqlCommand cmd = conn.CreateCommand();

            using (conn)
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM tbl_studies WHERE Study_ID = @id";
                cmd.Parameters.AddWithValue("@id", id);
           
                using (var reader = cmd.ExecuteReader()) 
                { 
                    if (!reader.Read()) 
                    { 
                        return null; 
                    }
                    else
                    {
                        Study study = new Study(); 
                        study.StudyID = reader.GetInt32(reader.GetOrdinal("study_ID"));
                        study.StudyName = reader.GetString(reader.GetOrdinal("study_name"));
                        study.StudyManager = reader.GetString(reader.GetOrdinal("study_manager"));
                        study.StudyCreated = reader.GetDateTime(reader.GetOrdinal("Study_DateCreated"));
                        reader.Close();
                        conn.Close();
                        return study;
                    }                    
                }
            } 
        }


        public Study StoreStudy(Study study)
        {
            // “store” code goes here
             SqlConnection conn = GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            int retVal = 0;

            using (conn)
            {
                conn.Open();
                cmd.CommandText = "Insert into tbl_studies (Study_Name,study_Manager,study_DateCreated) values " +
                   "('" + study.StudyName + "','" + study.StudyManager + "','" + study.StudyCreated + "')";
                
                retVal = cmd.ExecuteNonQuery();
                return study;
            }
        }

        public Study UpdateStudy(Study study)
        {
            // “update” code goes here
            SqlConnection conn = GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            int retVal = 0;

            using (conn)
            {
                conn.Open();
                cmd.CommandText = "Update tbl_studies set Study_Name = '" + study.StudyName +
                    "',study_Manager = '" + study.StudyManager + 
                    "',study_DateCreated = '" + study.StudyCreated +
                    "' WHERE Study_ID = @id";
                cmd.Parameters.AddWithValue("@id", study.StudyID);
                retVal = cmd.ExecuteNonQuery();

                return study;
            }
        }

        public int DeleteStudy(int id)
        {
            // “delete” code goes here
            SqlConnection conn = GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            int retVal = 0;

            using (conn)
            {
                conn.Open();
                cmd.CommandText = "Delete From tbl_studies " + 
                    " WHERE Study_ID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                retVal = cmd.ExecuteNonQuery();

                return retVal;
            }
        }
    }
}