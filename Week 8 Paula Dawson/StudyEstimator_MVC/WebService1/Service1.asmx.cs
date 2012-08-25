using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace WebService1
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
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