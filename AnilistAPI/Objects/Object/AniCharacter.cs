namespace AnilistAPI.Objects.Object
{
    public class AniCharacter
    {
        public CharacterName name { get; set; }
        public string description { get; set; }
        public CharacterImage image { get; set; }
        public CharacterDateOfBirth dateOfBirth { get; set; }
        public string gender { get; set; }
        public string siteUrl { get; set; }
    }
}
