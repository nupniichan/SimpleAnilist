namespace AnilistAPI
{
    public class CharacterSearch
    {
        public static async Task SearchCharacter(string name)
        {
            string query = Query.CharacterSearchQuery;
            var variables = new
            {
                search = name,
                asHtml = true
            };

            try
            {
                var apiClient = new GraphQLAnilist();
                var character = await apiClient.GetCharacterAsync(query, variables);

                Console.WriteLine(character.name.first);
                await Console.Out.WriteLineAsync(character.dateOfBirth.month.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                Console.WriteLine(e.ToString());
            }
        }
    }
}
