using System.Collections.Generic;

namespace IMDBWebClient {
    public interface IWebQuery {
        string Url { get; }
        Dictionary<string, string> QueryStringParameters();
   }
}
