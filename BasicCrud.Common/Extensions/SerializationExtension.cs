using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace BasicCrud.Common.Extensions
{
    public static class SerializationExtension
    {
        public static string SerializeContentObject<T>(this T content, bool isUseDefaultJsonSettings = false)
        {
            if (isUseDefaultJsonSettings) return JsonConvert.SerializeObject(content);

            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.SerializeObject(content, jsonSettings);
        }
    }
}
