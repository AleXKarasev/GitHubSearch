using System.Web.Mvc;
using System.Linq;
using GitHubApi.SearchRepository;
using System.Threading.Tasks;
using GitHubSearchRepository.Models;

namespace GitHubSearchRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchRepositoryService searchRepositoryService;

        public HomeController(ISearchRepositoryService searchRepositoryService)
        {
            this.searchRepositoryService = searchRepositoryService;
        }

        public async Task<ActionResult> Index(IndexModel model)
        {
            model = model ?? new IndexModel();

            if (!string.IsNullOrWhiteSpace(model.Filter.Keywords))
            {
                model.Items = (await this.searchRepositoryService.SearchAsync(model.Filter.Keywords).ConfigureAwait(false))
                    .Select(x => new RepositoryModel
                    {
                        Name = x.Name,
                        Url = x.Url
                    }).ToList();
            }

            return View(model);
        }
    }
}