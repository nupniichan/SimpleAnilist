namespace AnilistAPI.Objects.Object
{
    public class AniStaff
    {
        public StaffName name { get; set; }
        public string languageV2 { get; set; }
        public StaffImage image { get; set; }
        public string description { get; set; }
        public string siteUrl { get; set; }
        public List<string> primaryOccupations { get; set; }
        public string gender { get; set; }
        public string homeTown { get; set; }
    }
}
