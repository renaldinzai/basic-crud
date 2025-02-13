using BasicCrud.Common.Constants;
using Newtonsoft.Json;

namespace BasicCrud.Common.Models
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Status = "success";
            Code = StatusCode.Ok;
            Message = "Ok";
            Results = null;
        }

        /// <summary>
        /// Default value is success.
        /// </summary>
        /// <value></value>
        public string Status { get; set; }

        /// <summary>
        /// Default value is 200.
        /// </summary>
        /// <value></value>
        public int Code { get; set; }

        /// <summary>
        /// Default value is "Ok".
        /// </summary>
        /// <value></value>
        public string Message { get; set; }

        /// <summary>
        /// Default value is null.
        /// </summary>
        /// <value></value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object? Results { get; set; }
    }
}
