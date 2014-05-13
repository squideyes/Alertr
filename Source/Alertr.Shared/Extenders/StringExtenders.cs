using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Alertr.Shared
{
    public static class StringExtenders
    {
        private static Dictionary<int, Regex> regexes =
            new Dictionary<int, Regex>();

        [DebuggerHidden]
        public static bool IsRegexMatch(this string value, string pattern)
        {
            return value.IsRegexMatch(pattern, RegexOptions.None);
        }

        [DebuggerHidden]
        public static bool IsRegexMatch(
            this string value, string pattern, RegexOptions options)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            if (string.IsNullOrWhiteSpace(pattern))
                return false;

            int hashCode = pattern.GetHashCode();

            Regex regex;

            if (!regexes.TryGetValue(hashCode, out regex))
            {
                options |= RegexOptions.Compiled;

                regex = new Regex(pattern, options);

                regexes.Add(hashCode, regex);
            }

            return regex.IsMatch(value);
        }

        public static bool IsEmailAddress(this string value)
        {
            const string PATTERN =
                @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$";

            if (string.IsNullOrWhiteSpace(value))
                return false;

            if (value.Length < EmailAddress.Lengths.MinLength)
                return false;

            if (value.Length > EmailAddress.Lengths.MaxLength)
                return false;

            return value.IsRegexMatch(PATTERN);
        }
    }
}
