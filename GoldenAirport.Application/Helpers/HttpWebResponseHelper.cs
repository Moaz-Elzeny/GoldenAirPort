using System.Net;
using System.Text;

namespace GoldenAirport.Application.Helpers
{
    public static class HttpWebResponseHelper
    {
        public static HttpWebResponse Get(string url, Dictionary<string, string> pHeaders = null)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
               | SecurityProtocolType.Tls11
               | SecurityProtocolType.Tls12;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.AllowAutoRedirect = false;
            if (pHeaders != null)
                foreach (var head in pHeaders)
                {
                    webRequest.Headers.Add(head.Key, head.Value);
                }
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException we)
            {
                response = (HttpWebResponse)we.Response;
            }


            return response;
        }

        public static HttpWebResponse Post(HttpMethod pMethod, string url, string pJsonContent = "", Dictionary<string, string> pHeaders = null, string contentType = "application/json", string accept = "*/*")
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (pHeaders != null)
                foreach (var head in pHeaders)
                {
                    request.Headers.Add(head.Key, head.Value);
                }

            request.Timeout = 60000;
            request.Method = pMethod.Method;
            request.Accept = accept;
            request.ContentType = contentType;
            ServicePointManager.Expect100Continue = true;

            byte[] byteArray = Encoding.UTF8.GetBytes(pJsonContent);
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();


            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException we)
            {
                response = (HttpWebResponse)we.Response;
            }


            return response;
        }
    }
}
