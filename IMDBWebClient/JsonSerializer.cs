using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace IMDBWebClient {
    public class JsonSerializer : ISerializer {
        public T Deserialize<T>(string content) {
            JsonSerializerSettings serialiserSettings = new JsonSerializerSettings() {
                MissingMemberHandling = MissingMemberHandling.Error
            };
                        
            return JsonConvert.DeserializeObject<T>(content, serialiserSettings);
        }
    }
}
