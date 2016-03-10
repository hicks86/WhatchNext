using System;
using System.Threading.Tasks;
using Csla;
using System.Collections.Generic;

namespace WhatchNext.Biz
{
    [Serializable]
    [Csla.Server.ObjectFactory("WhatchNext.DataAccess.Api.ShowsDal, WhatchNext.DataAccess.Api")]
    public class ShowDetails : ReadOnlyBase<ShowDetails>
    {
        public static readonly PropertyInfo<TraktApiId> IdProperty = RegisterProperty<TraktApiId>(c => c.Id);
        public TraktApiId Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> TitleProperty = RegisterProperty<string>(c => c.Title);
        public string Title
        {
            get { return GetProperty(TitleProperty); }
            private set { LoadProperty(TitleProperty, value); }
        }

        public static readonly PropertyInfo<int> YearProperty = RegisterProperty<int>(c => c.Year);
        public int Year
        {
            get { return GetProperty(YearProperty); }
            private set { LoadProperty(YearProperty, value); }
        }

        public static readonly PropertyInfo<string> OverviewProperty = RegisterProperty<string>(c => c.Overview);
        public string Overview
        {
            get { return GetProperty(OverviewProperty); }
            private set { LoadProperty(OverviewProperty, value); }
        }

        public static readonly PropertyInfo<string> BackdropProperty = RegisterProperty<string>(c => c.Backdrop);
        public string Backdrop
        {
            get { return GetProperty(BackdropProperty); }
            private set { LoadProperty(BackdropProperty, value); }
        }

        public static readonly PropertyInfo<List<KeyValuePair<string, string>>> ImagesProperty = RegisterProperty<List<KeyValuePair<string, string>>>(c => c.Images);
        public List<KeyValuePair<string, string>> Images
        {
            get { return GetProperty(ImagesProperty); }
            private set { LoadProperty(ImagesProperty, value); }
        }

        public static readonly PropertyInfo<string> TrailerProperty = RegisterProperty<string>(c => c.Trailer);
        public string Trailer
        {
            get { return GetProperty(TrailerProperty); }
            private set { LoadProperty(TrailerProperty, value); }
        }
        
        #region Factory Methods

        public static async Task<ShowDetails> GetShowDetailsAsync(int id)
        {
            return await DataPortal.FetchAsync<ShowDetails>(id);
        } 

        #endregion
    }
}