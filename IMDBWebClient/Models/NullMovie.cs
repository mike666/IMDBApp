using System;

namespace IMDBWebClient {
    public class NullMovie : IResponseData {
        public bool Response { get; set; }
        public string Error { get; set; }
    }
}
