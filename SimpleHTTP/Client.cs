using System;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;

namespace SimpleHTTP
{
    class Client
    {
        string url;
        HttpWebRequest request;

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
            
        }
        public bool WriteAnswer(String port, byte[] outp_byte)
        {
            url = String.Format("http://127.0.0.1:{0}/WriteAnswer", port);
      
        }
    }
}
