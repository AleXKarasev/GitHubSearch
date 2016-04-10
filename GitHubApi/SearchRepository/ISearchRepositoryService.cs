using GitHubApi.SearchRepository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubApi.SearchRepository
{
    public interface ISearchRepositoryService
    {
        /// <summary>
        ///     Search repositories by keywords
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<Repository>> SearchAsync(string keywords);
    }
}
