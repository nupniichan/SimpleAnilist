namespace AnilistAPI.Objects.Object
{
    public class AniUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public UserAvatar? avatar { get; set; }
        public string? bannerImage { get; set; }
        public string? about { get; set; }
        public UserFavourites? favourites { get; set; }
        public UserStatistics? statistics { get; set; }
        public string siteUrl { get; set; }
    }
}
