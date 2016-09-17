using System.Collections.Generic;
using System.Net;

namespace IMDBWebClient {
    public class IMDBWebClient {
        protected readonly IHTTPClient _HTTPClient;
        protected readonly ISerializer _Serializer;

        public IMDBWebClient(IHTTPClient httpclient, ISerializer serializer) {
            _HTTPClient = httpclient;
            _Serializer = serializer;
        }

        public virtual IWebResponse Get() {
            using (HttpWebResponse response = _HTTPClient.Get("http://www.omdbapi.com/?t=heat&y=1995&plot=full&r=json", new Dictionary<string, string>(), "application/json")) {
                using (var sr = new System.IO.StreamReader(response.GetResponseStream())) {
                    return GetResponseData(sr.ReadToEnd().Trim());
                }
            }
        }

        protected virtual IWebResponse GetResponseData(string responseContent) {
            try {
                return new IMDBWebResponse(_Serializer.Deserialize<Movie>(responseContent), WebResponseStatus.Found); ; 
            } catch {
                return new IMDBWebResponse(_Serializer.Deserialize<NullMovie>(responseContent), WebResponseStatus.NotFound); ;
            }
        }
    }
}
