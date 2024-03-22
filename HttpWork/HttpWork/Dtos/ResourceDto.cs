using System;
using System.Text.Json.Serialization;

namespace HttpWork.Dtos
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        [JsonPropertyName("page")]
        public string PantoneValue { get; set; }
    }
}

