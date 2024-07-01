using System.Text.RegularExpressions;

namespace ProConsulta.Extentions
{
    public static class StringExtensions
    {
        public static string OnlyCharacters(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            
            String pattern = @"[-\.\(\)\s]";

            string result = Regex.Replace(input, pattern, String.Empty);

            return result;
        }
    }
}
