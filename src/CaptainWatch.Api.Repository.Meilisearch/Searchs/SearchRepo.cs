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
            await _meilisearchClient.Index(SearchCollection.Movies.ToString()).UpdateFilterableAttributesAsync(new List<string>
            {
                nameof(SearchMovie.Id).ToLowerFirst()
            });
            await _meilisearchClient.Index(SearchCollection.Movies.ToString()).UpdateSearchableAttributesAsync(new List<string>
			{
                nameof(SearchMovie.Title).ToLowerFirst(),
                nameof(SearchMovie.OriginalTitle).ToLowerFirst(),
                nameof(SearchMovie.MinReleaseDate).ToLowerFirst(),
            });
			await _meilisearchClient.Index(SearchCollection.Movies.ToString()).UpdateRankingRulesAsync(new List<string>
            {
                //Default ranking rules
				nameof(SearchRankingRules.Words).ToLowerFirst(),
				nameof(SearchRankingRules.Typo).ToLowerFirst(),
				nameof(SearchRankingRules.Proximity).ToLowerFirst(),
				nameof(SearchRankingRules.Attribute).ToLowerFirst(),
				nameof(SearchRankingRules.Sort).ToLowerFirst(),
				nameof(SearchRankingRules.Exactness).ToLowerFirst(),
                //Custom ranking rules
				nameof(SearchMovie.SiteScore).ToLowerFirst() + ":desc"
			});

			//Serie
			await _meilisearchClient.CreateIndexAsync(SearchCollection.Series.ToString());
            await _meilisearchClient.Index(SearchCollection.Series.ToString()).UpdateFilterableAttributesAsync(new List<string>
            {
                nameof(SearchSerie.Id).ToLowerFirst()
            });
            await _meilisearchClient.Index(SearchCollection.Series.ToString()).UpdateSearchableAttributesAsync(new List<string>
			{
                nameof(SearchSerie.Title).ToLowerFirst(),
                nameof(SearchSerie.OriginalTitle).ToLowerFirst(),
                nameof(SearchSerie.FirstAirDate).ToLowerFirst(),
            });
			await _meilisearchClient.Index(SearchCollection.Series.ToString()).UpdateRankingRulesAsync(new List<string>
			{
                //Default ranking rules
				nameof(SearchRankingRules.Words).ToLowerFirst(),
				nameof(SearchRankingRules.Typo).ToLowerFirst(),
				nameof(SearchRankingRules.Proximity).ToLowerFirst(),
				nameof(SearchRankingRules.Attribute).ToLowerFirst(),
				nameof(SearchRankingRules.Sort).ToLowerFirst(),
				nameof(SearchRankingRules.Exactness).ToLowerFirst(),
                //Custom ranking rules
				nameof(SearchMovie.SiteScore).ToLowerFirst() + ":desc"
			});

			//User
			await _meilisearchClient.CreateIndexAsync(SearchCollection.Users.ToString());
            await _meilisearchClient.Index(SearchCollection.Users.ToString()).UpdateFilterableAttributesAsync(new List<string> { nameof(SearchUser.Id).ToLowerFirst() });
            await _meilisearchClient.Index(SearchCollection.Users.ToString()).UpdateSearchableAttributesAsync(new List<string>
			{
                nameof(SearchUser.Pseudo).ToLowerFirst(),
                nameof(SearchUser.FullName).ToLowerFirst(),
            });

            //Person
            await _meilisearchClient.CreateIndexAsync(SearchCollection.Persons.ToString());
            await _meilisearchClient.Index(SearchCollection.Persons.ToString()).UpdateFilterableAttributesAsync(new List<string> { nameof(SearchPerson.Id).ToLowerFirst() });
            await _meilisearchClient.Index(SearchCollection.Persons.ToString()).UpdateSearchableAttributesAsync(new List<string>
			{
                nameof(SearchPerson.Name).ToLowerFirst(),
            });

            //List
            await _meilisearchClient.CreateIndexAsync(SearchCollection.Lists.ToString());
            await _meilisearchClient.Index(SearchCollection.Lists.ToString()).UpdateFilterableAttributesAsync(new List<string> { nameof(SearchList.Id).ToLower() });
            await _meilisearchClient.Index(SearchCollection.Lists.ToString()).UpdateSearchableAttributesAsync(new List<string>
{
                nameof(SearchList.Name).ToLowerFirst(),
            });
        }

        #region Movies

        public async Task AddMoviesDocuments(IEnumerable<SearchMovieAddOrUpdateBo> movies)
        {
			const int batchSize = 10000;
			var searchMovies = movies.ToEntity();

			foreach (var batchMovies in searchMovies.Chunk(batchSize))
			{
				await _meilisearchClient.Index(SearchCollection.Movies.ToString()).AddDocumentsAsync(batchMovies);
			}
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

        #endregion

        #region Series

        public async Task AddSeriesDocuments(IEnumerable<SearchSerieAddOrUpdateBo> series)
        {
            var searchSeries = series.ToEntity();
            await _meilisearchClient.Index(SearchCollection.Series.ToString()).AddDocumentsAsync(searchSeries);
        }

        public async Task DeleteAllSeriesDocuments()
        {
            await _meilisearchClient.Index(SearchCollection.Series.ToString()).DeleteAllDocumentsAsync();
        }

        public async Task DeleteSerieDocument(int serieId)
        {
            await _meilisearchClient.Index(SearchCollection.Series.ToString()).DeleteOneDocumentAsync(serieId);
        }

        public async Task AddOrUpdateSerieDocument(SearchSerieAddOrUpdateBo serie)
        {
            var searchSerie = serie.ToEntity();
            await _meilisearchClient.Index(SearchCollection.Series.ToString()).UpdateDocumentsAsync(new List<SearchSerie> { searchSerie });
        }

        public async Task<IEnumerable<SearchSerieBo>> SearchSeries(SearchSerieQueryBo query)
        {
            var searchQuery = new SearchQuery
            {
                ShowRankingScore = true,
                Limit = query.MaxResults,
                Filter = nameof(SearchSerie.Id).ToLower() + " NOT IN [" + string.Join(",", query.ExcludedIds) + "]"
            };
            var series = await _meilisearchClient.Index(SearchCollection.Series.ToString()).SearchAsync<SearchSerieResult>(query.Query, searchQuery);
            return series.Hits.ToBo();
        }

        #endregion

        #region Users

        public async Task AddUsersDocuments(IEnumerable<SearchUserAddOrUpdateBo> users)
        {
            var searchUsers = users.ToEntity();
            await _meilisearchClient.Index(SearchCollection.Users.ToString()).AddDocumentsAsync(searchUsers);
        }

        public async Task DeleteAllUsersDocuments()
        {
            await _meilisearchClient.Index(SearchCollection.Users.ToString()).DeleteAllDocumentsAsync();
        }

        public async Task DeleteUserDocument(int userId)
        {
            await _meilisearchClient.Index(SearchCollection.Users.ToString()).DeleteOneDocumentAsync(userId);
        }

        public async Task AddOrUpdateUserDocument(SearchUserAddOrUpdateBo user)
        {
            var searchUser = user.ToEntity();
            await _meilisearchClient.Index(SearchCollection.Users.ToString()).UpdateDocumentsAsync(new List<SearchUser> { searchUser });
        }

        public async Task<IEnumerable<SearchUserBo>> SearchUsers(SearchUserQueryBo query)
        {
            var searchQuery = new SearchQuery
            {
                ShowRankingScore = true,
                Limit = query.MaxResults,
                Filter = nameof(SearchUser.Id).ToLower() + " NOT IN [" + string.Join(",", query.ExcludedIds) + "]"
            };
            var users = await _meilisearchClient.Index(SearchCollection.Users.ToString()).SearchAsync<SearchUserResult>(query.Query, searchQuery);
            return users.Hits.ToBo();
        }

        #endregion

        #region Persons

        public async Task AddPersonsDocuments(IEnumerable<SearchPersonAddOrUpdateBo> persons)
        {
            var searchPersons = persons.ToEntity();
            await _meilisearchClient.Index(SearchCollection.Persons.ToString()).AddDocumentsAsync(searchPersons);
        }

        public async Task DeleteAllPersonsDocuments()
        {
            await _meilisearchClient.Index(SearchCollection.Persons.ToString()).DeleteAllDocumentsAsync();
        }

        public async Task DeletePersonDocument(int personId)
        {
            await _meilisearchClient.Index(SearchCollection.Persons.ToString()).DeleteOneDocumentAsync(personId);
        }

        public async Task AddOrUpdatePersonDocument(SearchPersonAddOrUpdateBo person)
        {
            var searchPerson = person.ToEntity();
            await _meilisearchClient.Index(SearchCollection.Persons.ToString()).UpdateDocumentsAsync(new List<SearchPerson> { searchPerson });
        }

        public async Task<IEnumerable<SearchPersonBo>> SearchPersons(SearchPersonQueryBo query)
        {
            var searchQuery = new SearchQuery
            {
                ShowRankingScore = true,
                Limit = query.MaxResults,
                Filter = nameof(SearchPerson.Id).ToLower() + " NOT IN [" + string.Join(",", query.ExcludedIds) + "]"
            };
            var persons = await _meilisearchClient.Index(SearchCollection.Persons.ToString()).SearchAsync<SearchPersonResult>(query.Query, searchQuery);
            return persons.Hits.ToBo();
        }

        #endregion

        #region Lists

        public async Task AddListsDocuments(IEnumerable<SearchListAddOrUpdateBo> lists)
        {
            var searchLists = lists.ToEntity();
            await _meilisearchClient.Index(SearchCollection.Lists.ToString()).AddDocumentsAsync(searchLists);
        }

        public async Task DeleteAllListsDocuments()
        {
            await _meilisearchClient.Index(SearchCollection.Lists.ToString()).DeleteAllDocumentsAsync();
        }

        public async Task DeleteListDocument(int listId)
        {
            await _meilisearchClient.Index(SearchCollection.Lists.ToString()).DeleteOneDocumentAsync(listId);
        }

        public async Task AddOrUpdateListDocument(SearchListAddOrUpdateBo list)
        {
            var searchList = list.ToEntity();
            await _meilisearchClient.Index(SearchCollection.Lists.ToString()).UpdateDocumentsAsync(new List<SearchList> { searchList });
        }

        public async Task<IEnumerable<SearchListBo>> SearchLists(SearchListQueryBo query)
        {
            var searchQuery = new SearchQuery
            {
                ShowRankingScore = true,
                Limit = query.MaxResults,
                Filter = nameof(SearchList.Id).ToLower() + " NOT IN [" + string.Join(",", query.ExcludedIds) + "]"
            };
            var lists = await _meilisearchClient.Index(SearchCollection.Lists.ToString()).SearchAsync<SearchListResult>(query.Query, searchQuery);
            return lists.Hits.ToBo();
        }

        #endregion
    }
}
