using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WhatchNext.Biz;

namespace WhatchNext.WebApp.Controllers
{
    public class WNController : ApiController
    {

        // GET api/Trivia
        [ResponseType(typeof(ShowDetails))]
        public async Task<IHttpActionResult> Get()
        {
            var show = await ShowDetails.GetShowDetailsAsync(434);

            return Ok(show);
        }
    }
}
