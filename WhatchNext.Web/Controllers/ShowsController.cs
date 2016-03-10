using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using WhatchNext.Biz;

namespace WatchNext.Web.Controllers
{
    public class ShowsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to WhatchNext";

            return View();
        }

        //public async Task<ActionResult> Popular()
        //{
        //    //ViewData.Model = await PopularShowsList.GetPopularShows();
        //    return View();
        //}

        public ActionResult Popular()
        {
            return View();
        }

        public async Task<ActionResult> GetPopular()
        {
            ViewData.Model = await PopularShowsList.GetPopularShows();
            return PartialView("ShowsListControl", ViewData.Model);
        }

        [HttpPost]
        public ActionResult Popular(string id)
        {
            Thread.Sleep(5000);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}