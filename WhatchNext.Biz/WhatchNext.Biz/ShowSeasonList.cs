using Csla;
using System;
using System.Threading.Tasks;

namespace WhatchNext.Biz
{
    [Serializable]
    [Csla.Server.ObjectFactory("WhatchNext.DataAccess.Api.SeasonsDal, WhatchNext.DataAccess.Api")]
    public class ShowSeasonList : ReadOnlyListBase<ShowSeasonList, ShowSeasonInfo>
    {
        public static async Task<ShowSeasonList> GetShowSeasonsAsync(string slug)
        {
            return await DataPortal.FetchAsync<ShowSeasonList>(slug);
        }

    }
}
