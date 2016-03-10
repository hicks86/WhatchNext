using Csla;
using System;
using System.Threading.Tasks;

namespace WhatchNext.Biz
{
    [Serializable]
    [Csla.Server.ObjectFactory("WhatchNext.DataAccess.Api.OtherShowAttributesDal, WhatchNext.DataAccess.Api")]
    public class ShowCastList : ReadOnlyListBase<ShowCastList, ShowCastInfo>
    {
        public static async Task<ShowCastList> GetShowCastAsync(string slug)
        {
            return await DataPortal.FetchAsync<ShowCastList>(slug);
        }
    }
}
