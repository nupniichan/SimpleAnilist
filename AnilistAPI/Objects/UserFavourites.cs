namespace AnilistAPI.Objects
{
    public class UserFavourites
    {
        public UserAnimeFavourites? anime { get; set; }
        public UserMangaFavourites? manga { get; set; }
        public UserCharacterFavourites? characters { get; set; }
        public UserStaffFavourites? staff { get; set; }
        public UserStudioFavourites? studios { get; set; }
    }
}
