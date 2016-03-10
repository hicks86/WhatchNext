using Csla;
using System;
using System.Threading.Tasks;

namespace WhatchNext.Biz
{
    [Serializable]
    [Csla.Server.ObjectFactory("WhatchNext.DataAccess.Api.ShowsDal, WhatchNext.DataAccess.Api")]
    public class SimilarShowDetailsList : ReadOnlyListBase<SimilarShowDetailsList, SimilarShowDetail>
    {
        public static async Task<SimilarShowDetailsList> GetSimilarShowDetailsAsync(string slug)
        {
            return await DataPortal.FetchAsync<SimilarShowDetailsList>(slug);
        }
    }
}