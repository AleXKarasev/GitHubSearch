using System.Collections.Generic;

namespace GitHubSearchRepository.Models
{
    public class IndexModel
    {
        public IndexFilter Filter { get; set; }

        public IReadOnlyCollection<RepositoryModel> Items { get; set; }

        public IndexModel()
        {
            this.Filter = new IndexFilter();
            this.Items = new List<RepositoryModel>();
        }
    }
}