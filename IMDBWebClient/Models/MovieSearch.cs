using System.Collections.Generic;

namespace IMDBWebClient {
    public class MovieSearch : IResponseData {
        public List<MovieBasic> Search { get; set; }
        public int TotalResults { get; set; }
        public bool Response { get; set; }
    }
}