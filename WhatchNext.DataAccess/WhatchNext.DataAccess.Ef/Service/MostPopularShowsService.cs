using System;
using System.Collections.Generic;
using System.Linq;
using WhatchNext.DataAccess.Ef.CoreModel;
using WhatchNext.DataAccess.Ef.DTO;

namespace WhatchNext.DataAccess.Ef.Service
{
    public class MostPopularShowsService
    {
        private UnitOfWork _uow;
        private bool _disposed;

        public MostPopularShowsService(UnitOfWork uow)
        {
            _uow = uow;
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _uow.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }

        internal IEnumerable<MostPopularShows> GetPopularShows()
        {
            var popular = _uow.Session.MostPopularShows.Include("Show")
                                                            .Include("Show.ShowImages")
                                                            .Include("Show.ShowVideos")
                                                        .Where(x => DateTime.Today >= x.StartDate 
                                                        && DateTime.Today <= x.EndDate);

            return popular;
        }

        #endregion

        public void AddMostPopularShows(List<PopularShowDto> popularShows)
        {
            var showsService = new ShowsService(_uow);
            
            var rankedList = popularShows.OrderByDescending(x => x.Rating);
                
            int rankingCounter = 1;

            try
            {
                foreach (var item in rankedList)
                {
                    var show = showsService.GetShowFromIds(item.Ids.trakt, item.Ids.tmdb);

                    AddMostPopularShow(show, rankingCounter);

                    rankingCounter++;
                }
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException("Show does not exist in DB. Please make sure it is added before trying to add it to the Most Popular List!", ioe);
            }

        }

        private void AddMostPopularShow(Shows showJustAdded, int ranking)
        {            
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today.AddDays(7);

            MostPopularShows mostPopularShow = _uow.Session.MostPopularShows.Where(x => x.StartDate == startDate && x.EndDate == endDate && x.ShowsId == showJustAdded.Id).FirstOrDefault();

            if (mostPopularShow == null)
            {
                mostPopularShow = new MostPopularShows
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    ShowsId = showJustAdded.Id,
                    Rating = showJustAdded.Rating,
                    Ranking = ranking
                };

                Add(mostPopularShow);
            }
            else
            {
                mostPopularShow.Rating = showJustAdded.Rating;
                mostPopularShow.Ranking = ranking;
            }
        }

        private void Add(MostPopularShows mostPopularShow)
        {
            _uow.Session.MostPopularShows.Add(mostPopularShow);
        }
    }
}
