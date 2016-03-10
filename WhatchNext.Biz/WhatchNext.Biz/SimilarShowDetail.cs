using Csla;
using System;

namespace WhatchNext.Biz
{
    [Serializable]
    public class SimilarShowDetail : ReadOnlyBase<SimilarShowDetail>
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

        public static readonly PropertyInfo<string> OverviewProperty = RegisterProperty<string>(c => c.Overview);
        public string Overview
        {
            get { return GetProperty(OverviewProperty); }
            private set { LoadProperty(OverviewProperty, value); }
        }

        public static readonly PropertyInfo<string> PosterProperty = RegisterProperty<string>(c => c.Poster);
        public string Poster
        {
            get { return GetProperty(PosterProperty); }
            private set { LoadProperty(PosterProperty, value); }
        }

        public static readonly PropertyInfo<ShowDetails> ShowDetailsProperty = RegisterProperty<ShowDetails>(c => c.ShowDetails);
        public ShowDetails ShowDetails
        {
            get { return GetProperty(ShowDetailsProperty); }
            private set { LoadProperty(ShowDetailsProperty, value); }
        }


    }
}