using CommandLine;
using CommandLine.Text;
using IMDBWebClient;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace IMDBApp {
    class Program {

         static void Main(string[] args) {
            JsonSerializer serializer = new JsonSerializer();
            
            var options = new Options();
            if (!CommandLine.Parser.Default.ParseArguments(args, options)) {
               throw new Exception("Failed to parse command");
            }

            IMDBWebClient.IMDBWebClient imdbWebClient = new IMDBWebClient.IMDBWebClient(new HTTPClient(), serializer);

            IMDBmoviequery query = new IMDBmoviequery() {
                Title = options.Title,
                Search = options.Search,
                Id = options.Id,
                ResponseContentType = "json" };

            IWebResponse response = imdbWebClient.Get(query);

            if (query.Search) {
                WriteSearchResults(response.ResponseData as MovieSearch);
            } else {
                WriteStandardResult(response.ResponseData);
            }

            Environment.Exit(0);
        }

        private static void WriteStandardResult(IResponseData movie) {
            var properties = movie.GetType().GetProperties();

            foreach (var p in properties) {
                string name = p.Name;

                Console.WriteLine(String.Format("{0}: {1}", name, p.GetValue(movie)));
            }
        }

        private static void WriteSearchResults(MovieSearch movieSearch) {
            foreach(MovieBasic movie in movieSearch.Search) {
                var properties = movie.GetType().GetProperties();

                foreach (var p in properties) {
                    string name = p.Name;

                    Console.WriteLine(String.Format("{0}: {1}", name, p.GetValue(movie)));
                }
                
                Console.WriteLine("\n");
            }
        }
    }

    class Options {
        [Option('t', "title", Required = false, HelpText = "Lookup movie by title.")]
        public string Title { get; set; }

        [Option('i', "id", Required = false, HelpText = "Lookup movie by id.")]
        public string Id { get; set; }

        [Option('s', "search", Required = false, HelpText = "Search movie, returns a list matching results.")]
        public bool Search { get; set; }
               
        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage() {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current)); }
    }
}
