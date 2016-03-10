using System;
using System.IO;
using System.Web;
using WhatchNext.Biz;

namespace WhatchNext.DataAccess.Mock
{
    public class ShowsDal : Csla.Server.ObjectFactory
    {

        private const string LOCATION_IMAGES = @"~/App_Data/";

        public PopularShowsList Fetch()
        {
            PopularShowsList result = new PopularShowsList();
            SetIsReadOnly(result, false);
            var rlce = result.RaiseListChangedEvents;
            result.RaiseListChangedEvents = false;

            /// Data Acquisition
            result.Add(CreatePopularShowInfoItem(1, "Breaking Bad", @"Walter White, a struggling high school chemistry teacher...", MapPath("breakingbad.jpg"), 98.7f));

            result.Add(CreatePopularShowInfoItem(2, "Game of Thrones", @"Seven noble families fight for control of the mythical land of Westeros", MapPath("got.jpg"), 97.3f));

            result.Add(CreatePopularShowInfoItem(3, "Firefly", @"In the far-distant future, Captain Malcolm 'Mal' Reynolds is a renegade", MapPath("firefly.jpg"), 96.5f));

            result.Add(CreatePopularShowInfoItem(4, "Sherlock", @"Sherlock is a British television crime drama that presents a contemporar", MapPath("sherlock.jpg"), 96.3f));
            /// End Data Acquisition

            result.RaiseListChangedEvents = rlce;
            SetIsReadOnly(result, true);

            return result;
        }

        private static string MapPath(string image)
        {
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://stackoverflow/", ""), new HttpResponse(new StringWriter()));
            return HttpContext.Current.Request.MapPath(LOCATION_IMAGES + image);
        }

        private PopularShowInfo CreatePopularShowInfoItem(int id, string title,  string overview, string posterLocation, float score)
        {
            var child = new PopularShowInfo();

            MarkAsChild(child);
            MarkOld(child);

            LoadProperty(child, PopularShowInfo.IdProperty, new TraktApiId(id, id.ToString(), null, (id+10).ToString()));
            LoadProperty(child, PopularShowInfo.TitleProperty, title);
            LoadProperty(child, PopularShowInfo.OverviewProperty, overview);
            LoadProperty(child, PopularShowInfo.PosterProperty, posterLocation);
            LoadProperty(child, PopularShowInfo.RatingProperty, CreateShowRating(9.6, 87.0, 8.6));
            
            return child;
        }

        private ShowRatingInfo CreateShowRating(double imdb, double tomato, double trakt)
        {
            ShowRatingInfo result = new ShowRatingInfo();
            SetIsReadOnly(result, false);

            //Data Acquisition

            double tomatoMeter = 0;
            double imdbRating = 0;

            LoadProperty(result, ShowRatingInfo.ImdbRatingProperty, imdb);
            LoadProperty(result, ShowRatingInfo.RottenTomatoRatingProperty, tomato);
            LoadProperty(result, ShowRatingInfo.TraktRatingProperty, trakt);

            LoadProperty(result, ShowRatingInfo.CombinedRatingProperty, CalculateCombinedRating(result));

            SetIsReadOnly(result, true);

            return result;
        }

        private double CalculateCombinedRating(ShowRatingInfo result)
        {
            int divideBy = 0;
            double total = 0;

            if (result.ImdbRating != 0)
            {
                divideBy++;
                total = total + result.ImdbRating * 10;
            }

            if (result.RottenTomatoRating != 0)
            {
                divideBy++;
                total = total + result.RottenTomatoRating;
            }

            if (result.TraktRating != 0)
            {
                divideBy++;
                total = total + result.TraktRating * 10;
            }

            double combined = (total / divideBy);

            return Math.Round(combined, 3);
        }
    }
}
