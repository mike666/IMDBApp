using IMDBWebClient;
using System;

namespace IMDBApp {
    class Program {
        static void Main(string[] args) {
            JsonSerializer serializer = new JsonSerializer();

            IMDBWebClient.IMDBWebClient imdbWebClient = new IMDBWebClient.IMDBWebClient(new HTTPClient(), serializer);

            IMDBmoviequery query = new IMDBmoviequery("http://www.omdbapi.com") {
                Title = "Heat",
                Year = 1995,
                Plot = "full",
                ResponseContentType = "json"
            };

            IMDBSearchquery searchQuery = new IMDBSearchquery("http://www.omdbapi.com") {
                Title = "Batman",
                ResponseContentType = "json"
            };

            IWebResponse response = imdbWebClient.SearchMovie(searchQuery);

            Console.Write(serializer.Serialize(response.ResponseData));
            Console.ReadLine();
        }
    }
}
