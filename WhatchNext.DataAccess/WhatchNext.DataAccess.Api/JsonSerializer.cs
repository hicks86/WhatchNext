using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatchNext.DataAccess.Api
{
    public class JsonSerializer
    {
        public static T DeserializeSingle<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static List<T> DeserializeList<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
