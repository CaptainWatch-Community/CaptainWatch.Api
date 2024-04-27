using CaptainWatch.Api.Domain.Bo.Movies.Detail;
using CaptainWatch.Api.Domain.Interface.Repository;
using Meilisearch;

namespace CaptainWatch.Api.Repository.Meilisearch.Searchs
{
    public class SearchRepo : ISearchRepo
    {
        private readonly MeilisearchClient _meilisearchClient;
        public SearchRepo(MeilisearchClient meilisearchClient)
        {
            _meilisearchClient = meilisearchClient;
        }

        public async Task AddMoviesDocuments(IEnumerable<MovieBo> movies)
        {
            await _meilisearchClient.Index("movies").AddDocumentsAsync(movies);
        }
    }
}
