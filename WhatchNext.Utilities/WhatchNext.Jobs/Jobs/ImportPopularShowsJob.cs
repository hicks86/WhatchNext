using ManyConsole;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatchNext.Biz;
using WhatchNext.DataAccess.Ef;
using WhatchNext.DataAccess.Ef.Service;

namespace WhatchNext.Jobs.Jobs
{
    public class ImportPopularShowsJob : ConsoleCommand
    {
        public ImportPopularShowsJob()
        {
            IsCommand("ImportPopularShows", "Imports popular shows into the SQL DB ");
            
        }

        public override int Run(string[] remainingArguments)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
            {
                var popularShows = PopularShowsList.GetPopularShows();

                using (var uow = new UnitOfWork())
                {
                    var service = new ShowsService(uow);

                    foreach (var showItem in popularShows)
                    {
                        string jsonifiedShowItem = JsonConvert.SerializeObject(showItem);

                        service.AddShow(showItem.Id.Key, jsonifiedShowItem);
                    }

                    uow.Commit();
                }

                using (var uow = new UnitOfWork())
                {
                    var rankedList = popularShows.OrderByDescending(x => x.Rating);

                    var service = new PopularShowsService(uow);

                    foreach (var showItem in rankedList)
                    {

                    }
                }
                

                //add shows 
                //  if they exist
                //      update
                //  else
                //      add

                //sort by ranking

                //foreach item in popularshowsRanked
                //add to ranked 
                //  
                //
            }

            return 0;
        }
    }
}
