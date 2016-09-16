using IMDBWebClient;

namespace IMDBApp {
    class Program {
        static void Main(string[] args) {
            IMDBWebClient.IMDBWebClient imdbWebClient = new IMDBWebClient.IMDBWebClient(new HTTPClient(), new JsonSerializer());

            IWebResponse response = imdbWebClient.Get();
            
        }
    }
}
