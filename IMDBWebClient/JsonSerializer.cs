using Newtonsoft.Json;

namespace IMDBWebClient {
    public class JsonSerializer : ISerializer {
        public T Deserialize<T>(string content) {
            JsonSerializerSettings serialiserSettings = new JsonSerializerSettings() {
                MissingMemberHandling = MissingMemberHandling.Error
            };
                        
            return JsonConvert.DeserializeObject<T>(content, serialiserSettings);
        }

        public string Serialize(object targetObject) {
            return JsonConvert.SerializeObject(targetObject);
        }
    }
}
