using System;
using System.IO;
using System.Net;

namespace lab2
{
    class Vars
    {
        String url;
        HttpWebRequest request;

        public bool Ping(String port)
        {
            url = String.Format("http://127.0.0.1:{0}/Ping", port);
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 1000;
            request.Method = "GET";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                return true;
            }

            catch (WebException exception)
            {
                if (exception.Status == WebExceptionStatus.Timeout || exception.Status == WebExceptionStatus.ReceiveFailure || exception.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    return false;
                }
                else throw;
            }
        }
         public String GetInputData(String port)
        {
            url = String.Format("http://127.0.0.1:{0}/GetInputData", port);
            request = (HttpWebRequest)WebRequest.Create(url);

            request.Timeout = 1000;
            request.Method = "GET";

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                Stream str = response.GetResponseStream();
                StreamReader reader = new StreamReader(str);
                String inp_str = reader.ReadToEnd();
                str.Close();
                return inp_str;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.Timeout ||ex.Status == WebExceptionStatus.ReceiveFailure ||ex.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    return null;
                }
               else throw;
            }
        }
         public bool WriteAnswer(String port, byte[] outp_byte)
        {
            url = String.Format("http://127.0.0.1:{0}/WriteAnswer", port);
            request = (HttpWebRequest)WebRequest.Create(url);

            request.Timeout = 1000;
            request.Method = "POST";
            request.ContentLength = outp_byte.Length;

            Stream str = request.GetRequestStream();

            str.Write(outp_byte, 0, outp_byte.Length);
            str.Close();

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.Timeout ||ex.Status == WebExceptionStatus.ReceiveFailure ||ex.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    return false;
                }
                else throw;
            }
        }
    }
}
