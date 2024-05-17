using CaptainWatch.Api.Domain.Bo.Searchs.Request;
using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Movies
{
    public class SearchWriteService : ISearchWriteService
    {
        #region Declarations

        private readonly IMovieRepo _movieRepo;
        private readonly ISearchRepo _searchRepo;
        private readonly ISerieRepo _serieRepo;
        private readonly IUserRepo _userRepo;
        private readonly IPersonRepo _personRepo;
        private readonly IListRepo _listRepo;

        public SearchWriteService(IMovieRepo movieRepo, ISearchRepo searchRepo, ISerieRepo serieRepo, IUserRepo userRepo, IPersonRepo personRepo, IListRepo listRepo)
        {
            _movieRepo = movieRepo;
            _searchRepo = searchRepo;
            _serieRepo = serieRepo;
            _userRepo = userRepo;
            _personRepo = personRepo;
            _listRepo = listRepo;
        }
        #endregion

        public async Task InitSearchEngine()
        {
            await _searchRepo.InitSearchEngine();
        }

        #region Movies
        public async Task DeleteAllMovies()
        {
            await _searchRepo.DeleteAllMoviesDocuments();
        }

        public async Task DeleteMovie(int movieId)
        {
            await _searchRepo.DeleteMovieDocument(movieId);
        }

        public async Task ImportAllMovies()
        {
            var movies = await _movieRepo.GetAllMoviesForSearch();
            await _searchRepo.AddMoviesDocuments(movies);
        }

        public async Task AddOrUpdateMovie( SearchMovieAddOrUpdateBo movie)
        {
            await _searchRepo.AddOrUpdateMovieDocument(movie);
        }
        #endregion

        #region Series
        public async Task DeleteAllSeries()
        {
            await _searchRepo.DeleteAllSeriesDocuments();
        }

        public async Task DeleteSerie(int serieId)
        {
            await _searchRepo.DeleteSerieDocument(serieId);
        }

        public async Task ImportAllSeries()
        {
            var series = await _serieRepo.GetAllSeriesForSearch();
            await _searchRepo.AddSeriesDocuments(series);
        }

        public async Task AddOrUpdateSerie(SearchSerieAddOrUpdateBo serie)
        {
            await _searchRepo.AddOrUpdateSerieDocument(serie);
        }

        #endregion

        #region Users

        public async Task DeleteAllUsers()
        {
            await _searchRepo.DeleteAllUsersDocuments();
        }

        public async Task DeleteUser(int userId)
        {
            await _searchRepo.DeleteUserDocument(userId);
        }

        public async Task ImportAllUsers()
        {
            var users = await _userRepo.GetAllUsersForSearch();
            await _searchRepo.AddUsersDocuments(users);
        }

        public async Task AddOrUpdateUser(SearchUserAddOrUpdateBo user)
        {
            await _searchRepo.AddOrUpdateUserDocument(user);
        }

        #endregion

        #region Persons

        public async Task DeleteAllPersons()
        {
            await _searchRepo.DeleteAllPersonsDocuments();
        }

        public async Task DeletePerson(int personId)
        {
            await _searchRepo.DeletePersonDocument(personId);
        }

        public async Task ImportAllPersons()
        {
            var persons = await _personRepo.GetAllPersonsForSearch();
            await _searchRepo.AddPersonsDocuments(persons);
        }

        public async Task AddOrUpdatePerson(SearchPersonAddOrUpdateBo person)
        {
            await _searchRepo.AddOrUpdatePersonDocument(person);
        }

        #endregion

        #region Lists

        public async Task DeleteAllLists()
        {
            await _searchRepo.DeleteAllListsDocuments();
        }

        public async Task DeleteList(int listId)
        {
            await _searchRepo.DeleteListDocument(listId);
        }

        public async Task ImportAllLists()
        {
            var lists = await _listRepo.GetAllListsForSearch();
            await _searchRepo.AddListsDocuments(lists);
        }

        public async Task AddOrUpdateList(SearchListAddOrUpdateBo list)
        {
            await _searchRepo.AddOrUpdateListDocument(list);
        }

        #endregion
    }
}
