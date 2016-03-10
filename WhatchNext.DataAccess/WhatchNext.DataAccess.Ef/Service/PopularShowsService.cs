namespace WhatchNext.DataAccess.Ef.Service
{
    public class PopularShowsService
    {
        private UnitOfWork _uow;
        
        public PopularShowsService(UnitOfWork uow)
        {
            _uow = uow;
        }
    }
}