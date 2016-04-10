using GitHubApi.SearchRepository;
using GitHubApi.SearchRepository.Implementation;
using SimpleInjector;

namespace GitHubApi
{    
    public sealed class GitHubApiLibrary
    {
        /// <summary>
        ///     Registrated inner GitHubApi classes
        /// </summary>
        /// <param name="container"></param>
        public static void Register(Container container)
        {
            container.Register<ISearchRepositoryService, SearchRepositoryService>(Lifestyle.Singleton);
        }
    }
}
