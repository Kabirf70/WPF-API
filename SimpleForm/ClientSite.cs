using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleForm
{
    public enum httpverbs
    {
        GET,
        PUT,
        POST,
        DELETE

    }
    public class ClientSite
    {
        public string Url { get; set; }
        public httpverbs httpMethod { get; set; }

        public ClientSite()
        {
            Url = string.Empty;
            httpMethod = httpverbs.GET;
        }
        public string makeRequest()
        {
            string ResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = httpMethod.ToString();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code:" + response.StatusCode);
                }
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            ResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            return ResponseValue;
        }
    }
}

    

