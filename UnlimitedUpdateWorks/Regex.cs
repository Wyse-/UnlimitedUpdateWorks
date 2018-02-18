namespace UnlimitedUpdateWorks
{
    class Regex
    {
        /// <summary>
        /// Determines if whether the provided regular expression matches a given string.
        /// </summary>
        /// <param name="rgxString">Regular expression.</param>
        /// <param name="str">String to check against the regular expression.</param>
        /// <returns>
        /// True if the string matches the regex.
        /// False if the string doesn't match the regex.
        /// </returns>
        public static bool DoesRegexMatch(string rgxString, string str)
        {
            System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(rgxString);
            return rgx.IsMatch(str);
        }
    }
}
