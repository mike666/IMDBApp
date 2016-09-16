using System;

namespace IMDBWebClient {
    public class IMDBWebResponse : IWebResponse {
        public WebResponseStatus ResponseStatus { get; private set; }
        public IResponseData ResponseData { get; private set; }

        public IMDBWebResponse(IResponseData responseData, WebResponseStatus responseStatus) {
            ResponseData = responseData;
            ResponseStatus = responseStatus;
        }
    }
}
