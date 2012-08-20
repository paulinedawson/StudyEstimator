using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool AuthUser(string username, string password)
        {
            // process the credentials and return a true / false
            // call the database and make sure the user exists
            string _Connection = "Data Source=(local);Integrated Security=SSPI;initial catalog=Study_Estimator";

            SqlConnection conn = new SqlConnection(_Connection);
            SqlCommand cmd = conn.CreateCommand();
            using (conn)
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM tbl_plain_users WHERE username = @id and password = @pass";
                cmd.Parameters.AddWithValue("@id", username);
                cmd.Parameters.AddWithValue("@pass", password);

                using (var readerRec = cmd.ExecuteReader())
                {
                    if (!readerRec.Read())
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            } 
        }
    }
}
