using Newtonsoft.Json;
using System.Collections.Generic;

namespace AssemblyProfiles.Core.Helpers
{
    public static class JsonConverterHelper
    {

        public static string ToJson(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return json;
        }

        public static T GetObjectFromJson<T>(string json)
        {
            var obj = JsonConvert.DeserializeObject(json, typeof(T));
            return (T)obj;
        }

        public static List<T> GetObjectsFromJson<T>(string json)
        {
            var obj = JsonConvert.DeserializeObject<List<T>>(json);
            return obj;
        }

    }
}
