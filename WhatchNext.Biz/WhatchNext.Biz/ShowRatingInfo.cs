using Csla;
using System;
using System.Threading.Tasks;

namespace WhatchNext.Biz
{
    [Serializable]
    [Csla.Server.ObjectFactory("WhatchNext.DataAccess.Api.OtherShowAttributesDal, WhatchNext.DataAccess.Api")]
    public class ShowRatingInfo : BusinessBase<ShowRatingInfo>
    {
        #region Business Properties

        public static readonly PropertyInfo<double> CombinedRatingProperty = RegisterProperty<double>(c => c.CombinedRating);
        public double CombinedRating
        {
            get { return GetProperty(CombinedRatingProperty); }
            private set { LoadProperty(CombinedRatingProperty, value); }
        }

        public static readonly PropertyInfo<double> TraktRatingProperty = RegisterProperty<double>(c => c.TraktRating);
        public double TraktRating
        {
            get { return GetProperty(TraktRatingProperty); }
            private set { LoadProperty(TraktRatingProperty, value); }
        }

        public static readonly PropertyInfo<double> ImdbRatingProperty = RegisterProperty<double>(c => c.ImdbRating);
        public double ImdbRating
        {
            get { return GetProperty(ImdbRatingProperty); }
            private set { LoadProperty(ImdbRatingProperty, value); }
        }

        public static readonly PropertyInfo<double> TmdbRatingProperty = RegisterProperty<double>(c => c.TmdbRating);
        public double TmdbRating
        {
            get { return GetProperty(TmdbRatingProperty); }
            private set { LoadProperty(TmdbRatingProperty, value); }
        }

        public static readonly PropertyInfo<double> RottenTomatoRatingProperty = RegisterProperty<double>(c => c.RottenTomatoRating);
        public double RottenTomatoRating
        {
            get { return GetProperty(RottenTomatoRatingProperty); }
            private set { LoadProperty(RottenTomatoRatingProperty, value); }
        }

        #endregion

        #region Helper Properties

        public bool HasRottenTomatoValue
        {
            get
            {
                return (RottenTomatoRating > 0 ? true : false);
            }
        }

        #endregion

        #region Helper Methods

        public string ConvertToPercentage(double value)
        {
            string convertedValue;

            if (value * 10 < 100)
            {
                convertedValue = (value * 10).ToString("0.0");
            }
            else
            {
                convertedValue = value.ToString("0.00");
            }

            return convertedValue;
        }

        #endregion

        #region Factory Methods

        public static async Task<ShowRatingInfo> GetShowRatingAsync(TraktApiId id)
        {
            return await DataPortal.FetchAsync<ShowRatingInfo>(id);
        }

        #endregion
    }
}