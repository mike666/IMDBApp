using System;
using System.Collections.Generic;

namespace IMDBWebClient {
    public class IMDBmoviequery : IWebQuery {
        public string Url { get; private set; }
        public string Title { get; set; }
        public string Id { get; set; }
        public int? Year { get; set; }
        public string Plot { get; set; }
        public bool Search { get; set; }
        public string ResponseContentType { get; set; }
               

        public IMDBmoviequery(string apiUrl = "http://www.omdbapi.com") {
            Url = apiUrl;
            Search = false;
        }

        public Dictionary<string, string> QueryStringParameters() {
            Dictionary<string, string> returnVal = new Dictionary<string, string>();
            
            if (!String.IsNullOrEmpty(Title)) {
                if (Search) {
                    returnVal.Add("s", Title);
                } else {
                    returnVal.Add("t", Title);
                }
            }

            if (!String.IsNullOrEmpty(Id)) {
                returnVal.Add("i", Id);
            }
                        
            if (Year.HasValue) {
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
