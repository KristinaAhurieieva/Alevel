using System;
using System.Text.Json.Serialization;

namespace HttpWork.Dtos
{
    public class PageDto
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("data")]
        public List<ResourceDto> Data { get; set; }
    }
}

