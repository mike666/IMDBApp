namespace IMDBWebClient {
    public interface IWebResponse  {
        WebResponseStatus ResponseStatus { get; }
        IResponseData ResponseData { get; }
    }
}
