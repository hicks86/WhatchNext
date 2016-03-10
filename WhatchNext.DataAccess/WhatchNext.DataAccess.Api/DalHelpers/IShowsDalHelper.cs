using System.Collections.Generic;
using System.Threading.Tasks;
using WhatchNext.Biz;

namespace WhatchNext.DataAccess.Api.DalHelpers
{
    internal interface IShowsDalHelper
    {
        Task<List<KeyValuePair<string, string>>> GetShowImages(TraktApiId id);
        Task<string> GetShowVideos(TraktApiId id);
    }
}