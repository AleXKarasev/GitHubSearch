using Newtonsoft.Json;
using System.Collections.Generic;

namespace GitHubApi.SearchRepository.Models
{
    public sealed class SearchResponse
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
        [JsonProperty("items")]
        public IReadOnlyList<Repository> Items { get; set; }
    }
}
