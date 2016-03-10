using System.Threading.Tasks;
using System.Web.Mvc;
using WhatchNext.Biz;
using System.Net.Mime;

namespace WhatchNext.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Popular()
        {
            return View();
        }

        public async Task<ActionResult> GetPopularAsync()
        {
            ViewData.Model = await PopularShowsList.GetPopularShowsAsync();

            return PartialView("ShowsCardListControl", ViewData.Model);
        }


        public ActionResult Similar()
        {
            return View();
        }


        public async Task<ActionResult> GetSimilarAsync(string slug)
        {
            ViewData.Model = await SimilarShowDetailsList.GetSimilarShowDetailsAsync("dexter");

            return PartialView("SimilarShowsCardListControl", ViewData.Model);
        }
    }
}