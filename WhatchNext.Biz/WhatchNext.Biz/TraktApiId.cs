using System;
using System.Collections.Generic;

namespace WhatchNext.Biz
{
    public class TraktApiId 
    {
        public TraktApiId(int key, string value, int? tmdbIdValue, string imdbId)
        {
            Key = key;
            Slug = value;
            TmdbId = tmdbIdValue;
            ImdbId = imdbId;
        }

        /// <summary>
        /// Key ID (also known as the Trakt Api ID)
        /// </summary>
        public int Key {
            get;
            private set;
        }

        public string Slug
        {
            get;
            private set;
        }

        public int? TmdbId
        {
            get;
            private set;
        }

        public string ImdbId
        {
            get;
            private set;
        }

    }
}