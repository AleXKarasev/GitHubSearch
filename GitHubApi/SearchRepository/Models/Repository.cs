using Newtonsoft.Json;

namespace GitHubApi.SearchRepository.Models
{
    public sealed class Repository
    {
        [JsonProperty("id")]
        public int Id { get;set; }
        [JsonProperty("name")]
        public string Name { get;set; }
        [JsonProperty("full_name")]
        public string FullName { get;set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
