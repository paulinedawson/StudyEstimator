using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;

namespace AuthenticationServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = null;
        //    try
        //    {
            Int32 port = 8081;
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");

            listener = new TcpListener(ipAddr, port);
            // Start listening for incoming client requests
            listener.Start();
    
            while(true)
            {
                Console.Write("Waiting for a connection... ");
                TcpClient tcpClient = listener.AcceptTcpClient();
                // get a stream to read/write
                NetworkStream stream = tcpClient.GetStream();

                // read the data sent by the client.
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);
                string credentials = reader.ReadString();
                
                Array aryUsrID = credentials.Split('/');
                string strUsrID = aryUsrID.GetValue(0).ToString();
                string strPass = aryUsrID.GetValue(1).ToString();

                Console.WriteLine("credentials: " + credentials);
                
                // process the credentials and return a true / false
                // call the database and make sure the user exists
                string _Connection = "Data Source=(local);Integrated Security=SSPI;initial catalog=Study_Estimator";

                SqlConnection conn = new SqlConnection(_Connection);
                SqlCommand cmd = conn.CreateCommand();
                lock(conn)
                using (conn)
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * FROM tbl_plain_users WHERE username = @id and password = @pass";
                    cmd.Parameters.AddWithValue("@id", strUsrID);
                    cmd.Parameters.AddWithValue("@pass", strPass);
                    

                    using (var readerRec = cmd.ExecuteReader())
                    {
                        if (!readerRec.Read())
                        {
                            writer.Write(false);
                        }
                        else
                        {
                            writer.Write(true);
                        }
                    }
                } 
                
                // close the socket when you’re done using it
                tcpClient.Close();
                
                }
                listener.Stop();
            }
        }
    }

