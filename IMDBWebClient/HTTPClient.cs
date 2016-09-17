using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace IMDBWebClient {
    public class HTTPClient : IHTTPClient{

        /// <summary>
        /// Performs a simple http get request with paramaters and returns the immediate response.
        /// </summary>
        /// <param name="url">The url for http get request</param>
        /// <param name="parameters">The paramaters to send</param>
        /// <returns>An http response</returns>
        public virtual HttpWebResponse Get(string url, string contentType) {
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;

            req.Method = "GET";
            req.ContentType = contentType;
            req.UserAgent = string.Format("IMDBWebClient.HTTPClient .Net: {0} OS: {1} DLL: {2}", Environment.Version, Environment.OSVersion, Assembly.GetExecutingAssembly().FullName);

            try {
                return (HttpWebResponse)req.GetResponse();
            } catch {
                throw;
            }
        }
    }
}
