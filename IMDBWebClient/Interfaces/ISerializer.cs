namespace IMDBWebClient {
    public interface ISerializer {
        T Deserialize<T>(string content);
    }
}
