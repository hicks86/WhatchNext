using Csla;
using System;
using System.Collections.Generic;

namespace WhatchNext.Biz
{
    [Serializable]
    public class ShowSeasonInfo : ReadOnlyBase<ShowSeasonInfo>
    {
        public static readonly PropertyInfo<TraktApiId> IdProperty = RegisterProperty<TraktApiId>(c => c.Id);
        public TraktApiId Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<int> SeasonNumberProperty = RegisterProperty<int>(c => c.SeasonNumber);
        public int SeasonNumber
        {
            get { return GetProperty(SeasonNumberProperty); }
            private set { LoadProperty(SeasonNumberProperty, value); }
        }

        public static readonly PropertyInfo<IEnumerable<EpisodeInfo>> EpisodeListProperty = RegisterProperty<IEnumerable<EpisodeInfo>>(c => c.EpisodeList);
        public IEnumerable<EpisodeInfo> EpisodeList
        {
            get { return GetProperty(EpisodeListProperty); }
            private set { LoadProperty(EpisodeListProperty, value); }
        }

        public static readonly PropertyInfo<string> SeasonPosterProperty = RegisterProperty<string>(c => c.SeasonPoster);
        public string SeasonPoster
        {
            get { return GetProperty(SeasonPosterProperty); }
            private set { LoadProperty(SeasonPosterProperty, value); }
        }

        public static readonly PropertyInfo<string> SeasonTitleProperty = RegisterProperty<string>(c => c.SeasonTitle);
        public string SeasonTitle
        {
            get { return GetProperty(SeasonTitleProperty); }
            private set { LoadProperty(SeasonTitleProperty, value); }
        }
    }
}