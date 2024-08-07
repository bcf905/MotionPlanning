using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime;

namespace MotionPlanning.Auxiliary
{
    public class RobotConnection
    {
        /// <summary>
        ///	A method that is only used to test connection to UR5e
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>A string containing test result</returns>
        public static string TestConnection()
        {
            string result = "Message send!";
            string message = "power off\n";
            byte[] bytemessage = Encoding.ASCII.GetBytes(message);

            try
            {
                IPAddress host = IPAddress.Parse("192.168.56.101");
                int port = 29999;
                IPEndPoint endpoint = new IPEndPoint(host, port);
                using Socket socket = new(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(endpoint);
                socket.Send(bytemessage);
                socket.Close();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        /// <summary>
        ///	A method that sends a message or script to UR5e
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="ip">IP address to robot</param>
        /// <param name="message">The message send to robot</param>
        /// <returns>A string containing the result</returns>
        public static string SendMessage(string ip, string message)
        {
            int port = 30001;
            string result = "Message send!";
            byte[] msg = Encoding.ASCII.GetBytes(message);

            try
            {
                IPAddress host = IPAddress.Parse(ip);
                IPEndPoint endpoint = new IPEndPoint(host, port);
                using Socket socket = new(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(endpoint);
                socket.Send(msg);
                socket.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;

        }

    }
}
