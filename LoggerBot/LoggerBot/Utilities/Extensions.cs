using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerBot.Utilities
{
    public static class Extensions
    {
        public static string CreateGenericRegexPattern(this string text)
        {
            // Issue? - "help," - with a comma or other punctuation will not be recognized
            // Example of what is created: "(?:(?:^helps$)|(?:^help\s)|(?:\shelp$)|(?:\shelp\s))";
            var onlyTextNonCaptureGroup = $"(?:^{text}$)";
            var textAtStartNonCaptureGroup = $@"(?:^{text}\s)";
            var textAtEndNonCaptureGroup = $@"(?:\s{text}$)";
            var textSurroundedByWhitespaceNonCaptureGroup = $@"(?:\s{text}\s)";
            return $"(?:{onlyTextNonCaptureGroup}|{textAtStartNonCaptureGroup}|{textAtEndNonCaptureGroup}|{textSurroundedByWhitespaceNonCaptureGroup})";
        }
    }
}
