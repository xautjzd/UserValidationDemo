using System.Web.Mvc;
namespace System.Web.Mvc
{
    public class TextHelper
    {
        public static string Truncate(string input, int length)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";

            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }
    }
}