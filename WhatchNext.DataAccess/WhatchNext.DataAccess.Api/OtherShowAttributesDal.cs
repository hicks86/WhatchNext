using OmdbApi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraktTvComponent;
using WhatchNext.Biz;
using WhatchNext.DataAccess.Api.Omdb;
using WhatchNext.DataAccess.Api.Trakt;

namespace WhatchNext.DataAccess.Api
{
    public class OtherShowAttributesDal : Csla.Server.ObjectFactory
    {
        public ShowRatingInfo Fetch(TraktApiId id)
        {
            ShowRatingInfo result = new ShowRatingInfo();
            SetIsReadOnly(result, false);

            //Data Acquisition

            double tomatoMeter = 0;
            double imdbRating = 0;

            GetImdbShowRating(id, out imdbRating, out tomatoMeter);

            LoadProperty(result, ShowRatingInfo.ImdbRatingProperty, Math.Round(imdbRating, 3));
            LoadProperty(result, ShowRatingInfo.RottenTomatoRatingProperty, Math.Round(tomatoMeter, 3));
            LoadProperty(result, ShowRatingInfo.TraktRatingProperty, Math.Round(GetTraktShowRating(id), 3));

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
                total = total + result.ImdbRating *10;
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

            return Math.Round(combined,3);
        }

        private double GetTraktShowRating(TraktApiId id)
        {
            using (var service = new TraktShowsService())
            {
                var traktRatingData = service.GetShowRating(id.Slug).Result;

                var traktRating = JsonSerializer.DeserializeSingle<TraktShowRating>(traktRatingData);

                return traktRating.rating;
            }
        }

        private void GetImdbShowRating(TraktApiId id, out double imdb, out double tomato)
        {
            using (var omdbApi = new OmdbShowsService())
            {
                var stream = omdbApi.GetImdbShowDetails(id.ImdbId).Result;

                var showDetails = JsonSerializer.DeserializeSingle<OmdbShowDetailsDto>(stream);

                imdb = float.Parse(showDetails.imdbRating, CultureInfo.InvariantCulture.NumberFormat);
                tomato = (!showDetails.tomatoMeter.Contains("N/A") ?
                    float.Parse(showDetails.tomatoMeter, CultureInfo.InvariantCulture.NumberFormat) : 0.00f);
            }
        }
    }
}
