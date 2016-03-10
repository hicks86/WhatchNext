using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WhatchNext.Biz;

namespace WhatchNext.DataAccess.Api.DalHelpers
{
    internal class ShowsDalHelper
    {
        private IEnumerable<IShowsDalHelper> _helperInstances;

        public ShowsDalHelper()
        {
            var dalHelperType = typeof(IShowsDalHelper);

            _helperInstances = from t in Assembly.GetExecutingAssembly().GetTypes()
                                  where t.GetInterfaces().Contains(dalHelperType)
                                        && t.GetConstructor(Type.EmptyTypes) != null
                                  select Activator.CreateInstance(t) as IShowsDalHelper;            

        }

        public List<KeyValuePair<string, string>> GetShowImages(TraktApiId id)
        {
            List<KeyValuePair<string, string>> images = null;

            foreach (var helper in _helperInstances)
            {
                images = helper.GetShowImages(id).Result;

                if (images.Count != 0)
                {
                    break;
                }
            }
            
            return (images.Count != 0 ? images : new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("No Thumbnail", "No Poster") });
        }

        public string GetShowVideos(TraktApiId id)
        {
            string videos = "";

            foreach (var helper in _helperInstances)
            {
                videos = helper.GetShowVideos(id).Result;

                if (videos != null)
                {
                    break;
                }
            }
            
            return videos;
        }
    }
}
