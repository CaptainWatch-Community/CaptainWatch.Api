using CaptainWatch.Api.Domain.Interface.Buisiness;
using CaptainWatch.Api.Domain.Interface.Repository;

namespace CaptainWatch.Api.Services.Series
{
    public class SerieWriteService : ISerieWriteService
    {
        #region Declarations

        private readonly ISerieRepo _serieRepo;
        private readonly ISearchWriteService _searchWriteService;

        public SerieWriteService(ISerieRepo serieRepo, ISearchWriteService searchWriteService)
        {
            _serieRepo = serieRepo;
            _searchWriteService = searchWriteService;
        }

        #endregion
        public async Task Delete(int serieId)
        {
            await _serieRepo.DeleteSerie(serieId);
            await _searchWriteService.DeleteSerie(serieId);
        }
    }
}
