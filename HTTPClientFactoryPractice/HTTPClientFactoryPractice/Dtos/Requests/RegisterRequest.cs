using Newtonsoft.Json;

namespace HTTPClientFactoryPractice.Dtos.Requests
{
    public class RegisterRequest
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
