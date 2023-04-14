using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Beadando1.Model
{
    public class User
    {
        public User(int id, string? name, string? password)
        {
            Id = id;
            Name = name;
            Password = password;
        }

        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string ?Name { get; set; }
        [JsonPropertyName("Password")]
        public string ?Password { get; set; }
    }
}
