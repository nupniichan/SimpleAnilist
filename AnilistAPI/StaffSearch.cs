namespace AnilistAPI
{
    public class StaffSearch
    {
        public static async Task SearchStaff(string name)
        {
            string query = AniQuery.StaffSearchQuery;
            var variables = new
            {
                search = name,
                asHtml = true
            };

            try
            {
                var apiClient = new AnilistGraphQL();
                var staff = await apiClient.GetStaffAsync(query, variables);

                await Console.Out.WriteLineAsync(staff.name.first + staff.languageV2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}
