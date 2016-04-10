using System;
using System.Collections.Generic;
using GitHubApi.SearchRepository.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace GitHubApi.SearchRepository.Implementation
{
    internal class SearchRepositoryService : ISearchRepositoryService
    {
        public async Task<IReadOnlyCollection<Repository>> SearchAsync(string keywords)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                client.DefaultRequestHeaders.TryAddWithoutValidation("X-RateLimit-Limit", "20");
                client.DefaultRequestHeaders.TryAddWithoutValidation("X-RateLimit-Remaining", "19");

                HttpResponseMessage response = await client.GetAsync("/search/repositories?q=" + keywords).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    return new List<Repository>();
                }

                var resultString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<SearchResponse>(resultString).Items;
            }            
        }
    }
}
