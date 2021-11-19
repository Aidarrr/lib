using System;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;

namespace SimpleHTTP
{
    class Client
    {
        string url;
        public string answerForSolution;

        public bool Ping(string port)
        {
            url = String.Format("http://127.0.0.1:{0}/Ping", port);
            Ping ping = new Ping();
            PingReply reply = ping.Send(url);

            return reply.Status == IPStatus.Success;
        }

        public string GetInputData(string port)
        {
            url = String.Format("http://127.0.0.1:{0}/GetInputData", port);
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            string responseFromServer; 

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }

            response.Close();
            return responseFromServer;
        }
        public bool WriteAnswer(string port, string jsonOutput)
        {
            url = String.Format("http://127.0.0.1:{0}/WriteAnswer", port);
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";

            byte[] byteOutput = Encoding.UTF8.GetBytes(jsonOutput);
            request.ContentLength = byteOutput.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteOutput, 0, byteOutput.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            string responseFromServer;

            using (dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }

            answerForSolution = responseFromServer;
            response.Close();
            return true;
        }
    }
}
