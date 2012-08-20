using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace StudyEstimator_MVC.Models.Services
{
    public class ILogInSVC_Sockets_Impl : ILogInSVC
    {
        public string AuthenticateLogIn(string username, string password)
        {
            //call the Socket service
            // bool retVal = false;
            //Call listener//
            Socket socket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Int32 port = 8081;
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");

            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint
                (ipAddr, port);
                socket.Connect(ipEndPoint);
                NetworkStream stream = new NetworkStream(socket);
                BinaryWriter writer = new BinaryWriter(stream);
                BinaryReader reader = new BinaryReader(stream);
                writer.Write(username + "/" + password);
                bool result = reader.ReadBoolean();

                return result.ToString();
            }
            catch
            { 
                return "Did you start the Service";
            }
            finally
            {
            

            }
        }
    }
}