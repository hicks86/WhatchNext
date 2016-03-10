using Csla;
using System;
using System.Collections.Generic;

namespace WhatchNext.Biz
{
    [Serializable] 
    public class PopularShowInfo : ReadOnlyBase<PopularShowInfo>
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

        public static readonly PropertyInfo<ShowRatingInfo> RatingProperty = RegisterProperty<ShowRatingInfo>(c => c.Rating);
        public ShowRatingInfo Rating
        {
            get { return GetProperty(RatingProperty); }
            private set { LoadProperty(RatingProperty, value); }
        }

        public static readonly PropertyInfo<string> PosterProperty = RegisterProperty<string>(c => c.Poster);
        public string Poster
        {
            get { return GetProperty(PosterProperty); }
            private set { LoadProperty(PosterProperty, value); }
        }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        public string Name
        {
            get { return GetProperty(NameProperty); }
            private set { LoadProperty(NameProperty, value); }
        }

        public static readonly PropertyInfo<IEnumerable<ImageBackdrops>> QuickGalleryProperty = RegisterProperty<IEnumerable<ImageBackdrops>>(c => c.QuickGallery);
        public IEnumerable<ImageBackdrops> QuickGallery
        {
            get { return GetProperty(QuickGalleryProperty); }
            private set { LoadProperty(QuickGalleryProperty, value); }
        }

        public static readonly PropertyInfo<string> TrailerProperty = RegisterProperty<string>(c => c.Trailer);
        public string Trailer
        {
            get { return GetProperty(TrailerProperty); }
            private set { LoadProperty(TrailerProperty, value); }
        }

        public static readonly PropertyInfo<ShowSeasonList> SeasonsProperty = RegisterProperty<ShowSeasonList>(c => c.Seasons);
        public ShowSeasonList Seasons
        {
            get { return GetProperty(SeasonsProperty); }
            private set { LoadProperty(SeasonsProperty, value); }
        }
    }
}