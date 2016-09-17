using System;
using System.Collections.Generic;

namespace IMDBWebClient {
    public class IMDBSearchquery : IWebQuery {
        public string Url { get; private set; }
        public string Title { get; set; }
        public string ResponseContentType { get; set; }
               
        public IMDBSearchquery(string apiUrl = "http://www.omdbapi.com") {
            Url = apiUrl;
        }

        public Dictionary<string, string> QueryStringParameters() {
            Dictionary<string, string> returnVal = new Dictionary<string, string>();
            
            if (!String.IsNullOrEmpty(Title)) {
                returnVal.Add("s", Title);
            }
                    
            if (!String.IsNullOrEmpty(ResponseContentType)) {
                returnVal.Add("r", ResponseContentType);
            }

            return returnVal;
        }
    }
}
