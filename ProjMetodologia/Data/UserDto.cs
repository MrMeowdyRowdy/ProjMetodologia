using System.Text.Json.Serialization;

namespace ProjMetodologia.Data
{
    public class UserDto
    {
        [JsonPropertyName("usuario")]
        public string? Username { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }
    }
}
