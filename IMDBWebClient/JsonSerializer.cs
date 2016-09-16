using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace IMDBWebClient {
    public class JsonSerializer : ISerializer {
        public T Deserialize<T>(string content) {
            JsonSerializerSettings serialiserSettings = new JsonSerializerSettings();

            serialiserSettings.MissingMemberHandling = MissingMemberHandling.Error;

            try {
                return JsonConvert.DeserializeObject<T>(content, serialiserSettings);
            } catch {
                return default(T);
            }
        }
    }
}
