using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Domain.Interface.Repository;
using CaptainWatch.Api.Repository.Meilisearch.Objects;
using CaptainWatch.Api.Repository.Melisearch.Extensions;
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

        public async Task AddMoviesDocuments(IEnumerable<SearchMovieAddOrUpdateBo> movies)
        {
            var searchMovies = movies.Select(_ => _.ToEntity());
            await _meilisearchClient.Index(SearchCollection.Movies.ToString()).AddDocumentsAsync(searchMovies);
        }

        public async Task DeleteAllMoviesDocuments()
        {
            await _meilisearchClient.Index(SearchCollection.Movies.ToString()).DeleteAllDocumentsAsync();
        }

        public async Task DeleteMovieDocument(int movieId)
        {
            await _meilisearchClient.Index(SearchCollection.Movies.ToString()).DeleteOneDocumentAsync(movieId);
        }

        public async Task AddOrUpdateMovieDocument(SearchMovieAddOrUpdateBo movie)
        {
            var searchMovie = movie.ToEntity();
            await _meilisearchClient.Index(SearchCollection.Movies.ToString()).UpdateDocumentsAsync(new List<SearchMovie> { searchMovie });
        }
    }
}
