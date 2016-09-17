using System.Net;

namespace IMDBWebClient {
    public interface IHTTPClient {
        HttpWebResponse Get(string url, string contentType);
    }
}
