namespace WhatchNext.Biz
{
    public class EpisodeInfo
    {
        public int Number { get; private set; }
        public string Title { get; private set; }
        public TraktApiId Ids { get; private set; }

        public EpisodeInfo(int episodeNumber, string title, TraktApiId ids)
        {
            Number = episodeNumber;
            Title = title;
            Ids = ids;
        }
    }
}