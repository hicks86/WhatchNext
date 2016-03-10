using Csla;
using System;
using System.Threading.Tasks;

namespace WhatchNext.Biz
{
    [Serializable]
    [Csla.Server.ObjectFactory("WhatchNext.DataAccess.Mock.ShowsDal, WhatchNext.DataAccess.Mock")]
    public class PopularShowsList : ReadOnlyListBase<PopularShowsList, PopularShowInfo>
    {
        public static async Task<PopularShowsList> GetPopularShowsAsync()
        {
            return await DataPortal.FetchAsync<PopularShowsList>();
        }

        public static PopularShowsList GetPopularShows()
        {
            return DataPortal.Fetch<PopularShowsList>();
        }
    }
}
