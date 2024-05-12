using CaptainWatch.Api.Domain.Bo.Searchs.Detail;
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

        public async Task InitSearchEngine()
        {
            //Movie
            await _meilisearchClient.CreateIndexAsync(SearchCollection.Movies.ToString());
            await _meilisearchClient.Index(SearchCollection.Movies.ToString()).UpdateFilterableAttributesAsync(new List<string> { nameof(SearchMovie.Id).ToLower() });
        }

        public async Task AddMoviesDocuments(IEnumerable<SearchMovieAddOrUpdateBo> movies)
        {
            var searchMovies = movies.ToEntity();
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

        public async Task<IEnumerable<SearchMovieBo>> SearchMovies(SearchMovieQueryBo query)
        {
            var searchQuery = new SearchQuery
            {
                ShowRankingScore = true,
                Limit = query.MaxResults,
                Filter = nameof(SearchMovie.Id).ToLower() + " NOT IN [" + string.Join(",", query.ExcludedIds) + "]"
            };
            var movies = await _meilisearchClient.Index(SearchCollection.Movies.ToString()).SearchAsync<SearchMovieResult>(query.Query, searchQuery);
            return movies.Hits.ToBo();
        }
    }
}
