using System.Text.RegularExpressions;

namespace BaseCureAPI.Helpers
{
    public static class StringHelper
    {
        public static string RemoveTags(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}
