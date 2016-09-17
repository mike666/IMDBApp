using System;
using System.Collections.Generic;

namespace IMDBWebClient {
    public class IMDBquery : IWebQuery {
        public string Url { get; private set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Plot { get; set; }
        public string ResponseContentType { get; set; }
               
        public IMDBquery(string apiUrl = "http://www.omdbapi.com") {
            Url = apiUrl;
        }

        public Dictionary<string, string> QueryStringParameters() {
            Dictionary<string, string> returnVal = new Dictionary<string, string>();
            
            if (!String.IsNullOrEmpty(Title)) {
                returnVal.Add("t", Title);
            }

            if (!Year.HasValue) {
                returnVal.Add("y", Year.Value.ToString());
            }

            if (!String.IsNullOrEmpty(Plot)) {
                returnVal.Add("plot", Plot);
            }

            if (!String.IsNullOrEmpty(ResponseContentType)) {
                returnVal.Add("r", ResponseContentType);
            }

            return returnVal;
        }
    }
}
