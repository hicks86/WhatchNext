using ManyConsole;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WhatchNext.DataAccess.Ef.DTO;
using WhatchNext.DataAccess.Ef.Service;
using System.Data.Entity.Validation;
using System.Diagnostics;
using WhatchNext.DataAccess.Ef;
using System;

namespace WhatchNext.Jobs.Jobs
{
    //public class ImportMostPopularShowsJob : ConsoleCommand
    //{
    //    //public ImportMostPopularShowsJob()
    //    //{
    //    //    IsCommand("ImportMostPopularShows", "Imports most popular shows into the SQL DB ");
    //    //}

    //    //public override int Run(string[] remainingArguments)
    //    //{
    //    //    if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
    //    //    {
    //    //        List<PopularShowDto> popularShows = new List<PopularShowDto>();

    //    //        using (var service = new TraktShowsService())
    //    //        {
    //    //            var stream = service.GetPopularShows().Result;

    //    //            var deserializedData = JsonSerializer.DeserializeList<TraktPopularShowInformationDto>(stream);

    //    //            foreach (var item in deserializedData)
    //    //            {
    //    //                popularShows.Add(CreatePopularShowDtoItem(item, service));
    //    //                Console.WriteLine("Added " + item.title);
    //    //            }
    //    //        }

    //    //        try
    //    //        {
    //    //            //Add Shows
    //    //            using (var uow = new UnitOfWork())
    //    //            {
    //    //                var showsService = new ShowsService(uow);

    //    //                foreach (var item in popularShows)
    //    //                {
    //    //                    showsService.AddShow(item);
    //    //                }

    //    //                uow.Commit();
    //    //            }

    //    //            using (var uow = new UnitOfWork())
    //    //            {
    //    //                var efService = new MostPopularShowsService(uow);

    //    //                efService.AddMostPopularShows(popularShows);

    //    //                uow.Commit();
    //    //            }
    //    //        }

    //    //        catch (DbEntityValidationException dbEx)
    //    //        {
    //    //            foreach (var validationErrors in dbEx.EntityValidationErrors)
    //    //            {
    //    //                foreach (var validationError in validationErrors.ValidationErrors)
    //    //                {
    //    //                    Debug.WriteLine("Property: {0} Error: {1}",
    //    //                                            validationError.PropertyName,
    //    //                                            validationError.ErrorMessage);
    //    //                }
    //    //            }
    //    //        }
    //    //        catch (Exception ex)
    //    //        {
    //    //            Debug.WriteLine(ex.Message);
    //    //        }


    //    //    }
    //    //    return 0;
    //    //}

    //    //private PopularShowDto CreatePopularShowDtoItem(TraktPopularShowInformationDto item, TraktShowsService service)
    //    //{
    //    //    PopularShowDto show = new PopularShowDto();
            
    //    //    var traktShowStream = service.GetTraktTvShowDetails(item.ids.trakt).Result;

    //    //    var deserializedData = JsonSerializer.DeserializeList<TraktShowInformationDto>(traktShowStream).Single();

    //    //    Mapper.CreateMap<TraktApiIds, ApiIds>();
    //    //    var convertedDto = Mapper.Map<ApiIds>(item.ids);

    //    //    ////Setup Properties
    //    //    show.Ids = convertedDto;
    //    //    show.Title = deserializedData.show.title;
    //    //    show.Overview = deserializedData.show.overview;
    //    //    show.Images = GetShowImages(item.ids);
    //    //    show.Videos = GetShowVideos(item.ids);
    //    //    show.Rating = GetShowRatings(item.ids, service);
    //    //    show.Poster = deserializedData.show.images.fanart.thumb;
            
    //    //    return show;
    //    //}
        
    //    //private float GetShowRatings(TraktApiIds ids, TraktShowsService service)
    //    //{
    //    //    var traktRatingData = service.GetShowRating(ids.slug);

    //    //    var traktRating = JsonSerializer.DeserializeSingle<TraktShowRating>(traktRatingData.Result);

    //    //    return traktRating.rating * 10;
    //    //}

    //    //private List<ShowVideoDto> GetShowVideos(TraktApiIds ids)
    //    //{
    //    //    List<ShowVideoDto> videos = new List<ShowVideoDto>();

    //    //    using (var service = new TmdbShowsService())
    //    //    {
    //    //        var tmdbTrailerStream = service.GetShowTrailers(ids.tmdb.Value).Result;

    //    //        var showTrailers = JsonSerializer.DeserializeSingle<TmdbShowTrailerDto>(tmdbTrailerStream);

    //    //        var trailer = showTrailers.results.Where(x => x.type == "Trailer");


    //    //        foreach (var item in showTrailers.results)
    //    //        {
    //    //            if (item.type == "Trailer" )
    //    //            {
    //    //                videos.Add(new ShowVideoDto
    //    //                {
    //    //                    VideoApiType = "trailer",
    //    //                    Name = item.name,
    //    //                    Key = "//www.youtube.com/embed/" + item.key,
    //    //                    Site = item.site,
    //    //                    Size = item.size
    //    //                });

    //    //            }
    //    //        }

    //    //    }

    //    //    return videos;
    //    //}

    //    //private List<ShowImagesDto> GetShowImages(TraktApiIds ids)
    //    //{
    //    //    var images   = new List<ShowImagesDto>();

    //    //    using (var service = new TmdbShowsService())
    //    //    {
    //    //        if (ids.tmdb != null)
    //    //        {
    //    //            var tmdbImageStream = service.GetShowImages(ids.tmdb.Value).Result;

    //    //            var showImages = JsonSerializer.DeserializeSingle<TmdbShowImagesDto>(tmdbImageStream);
                                        
    //    //            foreach (var item in showImages.backdrops)
    //    //            {
    //    //                images.Add(new ShowImagesDto
    //    //                {
    //    //                    ImageApiType = "backdrops",
    //    //                    AspectRatio = item.aspect_ratio,
    //    //                    FilePath = item.file_path,
    //    //                    Height = item.height,
    //    //                    Width = item.width,
    //    //                    Iso6391 = item.iso_639_1,
    //    //                    AverageRating = item.vote_average,
    //    //                });
    //    //            }

    //    //            foreach (var item in showImages.posters)
    //    //            {
    //    //                images.Add(new ShowImagesDto
    //    //                {
    //    //                    ImageApiType = "posters",
    //    //                    AspectRatio = item.aspect_ratio,
    //    //                    FilePath = item.file_path,
    //    //                    Height = item.height,
    //    //                    Width = item.width,
    //    //                    Iso6391 = item.iso_639_1,
    //    //                    AverageRating = item.vote_average,
    //    //                });

    //    //            }
    //    //        }
    //    //    }

    //    //    return images;

    //    //}
    //}

    
}
