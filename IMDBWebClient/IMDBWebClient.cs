using System.Collections.Generic;
using System.Net;
using System.Linq;
using System;

namespace IMDBWebClient {
    public class IMDBWebClient {
        protected readonly IHTTPClient _HTTPClient;
        protected readonly ISerializer _Serializer;

        public IMDBWebClient(IHTTPClient httpclient, ISerializer serializer) {
            _HTTPClient = httpclient;
            _Serializer = serializer;
        }

        public virtual IWebResponse GetMovie(IWebQuery webQuery) {
            string urlAndQuery = webQuery.Url + "?" + String.Join("&", webQuery.QueryStringParameters().Select(kvp => String.Format("{0}={1}", kvp.Key, kvp.Value)).ToArray());

            using (HttpWebResponse response = _HTTPClient.Get(urlAndQuery, "application/json")) {
                using (var sr = new System.IO.StreamReader(response.GetResponseStream())) {
                    string responseContent = sr.ReadToEnd().Trim();

                    try {
                        return new IMDBWebResponse(_Serializer.Deserialize<Movie>(responseContent), WebResponseStatus.Found);
                    } catch {
                        return new IMDBWebResponse(_Serializer.Deserialize<NullMovie>(responseContent), WebResponseStatus.NotFound);
                    }
                }
            }
        }

        public virtual IWebResponse SearchMovie(IWebQuery webQuery) {
            string urlAndQuery = webQuery.Url + "?" + String.Join("&", webQuery.QueryStringParameters().Select(kvp => String.Format("{0}={1}", kvp.Key, kvp.Value)).ToArray());

            using (HttpWebResponse response = _HTTPClient.Get(urlAndQuery, "application/json")) {
                using (var sr = new System.IO.StreamReader(response.GetResponseStream())) {
                    string responseContent = sr.ReadToEnd().Trim();

                    try {
                        return new IMDBWebResponse(_Serializer.Deserialize<MovieSearch>(responseContent), WebResponseStatus.Found);
                    } catch (Exception ex) {
                        return new IMDBWebResponse(_Serializer.Deserialize<NullMovie>(responseContent), WebResponseStatus.NotFound);
                    }
                }
            }
        }
    }
}
