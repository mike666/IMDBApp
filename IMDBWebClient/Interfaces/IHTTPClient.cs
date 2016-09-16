using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace IMDBWebClient {
    public interface IHTTPClient {
        HttpWebResponse Get(string url, Dictionary<string, string> parameters, string contentType);
    }
}
