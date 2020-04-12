using System.Text.RegularExpressions;

namespace AssemblyProfiles.Core.Helpers.InnerText
{
    public static class InnerTextHelper
    {
        public static string RemovePadding(this string innerText)
        {
            var textWithoutPadding = innerText.Replace( "\r\n", "" );
            return textWithoutPadding;
        }

        public static string RemoveExtraSpaces(this string innerText)
        {
            var textWithoutExtraSpaces = Regex.Replace(innerText, @"\s+", " ");
            return textWithoutExtraSpaces;
        }
    }
}
