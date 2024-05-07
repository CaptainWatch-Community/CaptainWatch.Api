using CaptainWatch.Api.Domain.Bo.Movies.Detail;
using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Domain.Interface.Repository;
using CaptainWatch.Api.Repository.Meilisearch.Objects;
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

        public async Task DeleteAllMoviesDocuments()
        {
            await _meilisearchClient.Index("movies").DeleteAllDocumentsAsync();
        }

        public async Task DeleteMovieDocument(int movieId)
        {
            await _meilisearchClient.Index("movies").DeleteOneDocumentAsync(movieId);
        }

        public async Task AddOrUpdateMovieDocument(int movieId, SearchMovieAddOrUpdateBo movie)
        {
            var searchMovie = new SearchMovie
            {
                Id = movieId,
                Title = movie.Title,
                OriginalTitle = movie.OriginalTitle
            };
            await _meilisearchClient.Index("movies").UpdateDocumentsAsync(new List<SearchMovie> { searchMovie });
        }
    }
}
