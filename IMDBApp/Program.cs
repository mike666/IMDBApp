using IMDBWebClient;
using System;

namespace IMDBApp {
    class Program {
        static void Main(string[] args) {
            JsonSerializer serializer = new JsonSerializer();

            IMDBWebClient.IMDBWebClient imdbWebClient = new IMDBWebClient.IMDBWebClient(new HTTPClient(), serializer);

            IMDBquery query = new IMDBquery("http://www.omdbapi.com") {
                Title = "Heatoo",
                Year = 1995,
                Plot = "full",
                ResponseContentType = "json"
            };

            IWebResponse response = imdbWebClient.Get(query);

            Console.Write(serializer.Serialize(response.ResponseData));
            Console.ReadLine();
        }
    }
}
