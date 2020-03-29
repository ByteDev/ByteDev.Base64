using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ByteDev.Base64
{
    /// <summary>
    /// Represents a set of base64 related encoding and decoding operations.
    /// </summary>
    public static class Base64Encoder
    {
        /// <summary>
        /// The possible valid characters in a base64 encoded string.
        /// </summary>
        public static readonly HashSet<char> ValidChars = new HashSet<char>
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
            'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
            'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
            'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/',
            '='
        };

        /// <summary>
        /// Checks if <paramref name="value" /> is potentially base64 encoded.
        /// </summary>
        /// <param name="value">The string value to check.</param>
        /// <returns>True if <paramref name="value" /> is base64 encoded; otherwise returns false.</returns>
        public static bool IsBase64Encoded(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            // Check length is multiple of 4
            if (value.Length % 4 != 0)
                return false;

            // Check every char is [A-Za-z0-9+/] except for end padding which can be 0-2 '=' characters
            return Regex.IsMatch(value, "^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)?$");
        }

        /// <summary>
        /// Calculates the potential base64 size of content. 
        /// </summary>
        /// <param name="originalSizeInBytes">The original size of the content.</param>
        /// <returns>The size of the content if it was base64 encoded.</returns>
        public static long CalcBase64EncodedSize(long originalSizeInBytes)
        {
            return 4 * (int)Math.Ceiling(originalSizeInBytes / 3.0);
        }

        /// <summary>
        /// Converts a UTF8 encoded string to base64.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The converted base64 string.</returns>
        public static string ConvertToBase64(string text)
        {
            return ConvertToBase64(text, new UTF8Encoding());
        }

        /// <summary>
        /// Converts a string to base64.
        /// </summary>
        /// <param name="text">The string to convert./</param>
        /// <param name="encoding">The encoding of <paramref name="text" />.</param>
        /// <returns>The converted base64 string.</returns>
        public static string ConvertToBase64(string text, Encoding encoding)
        {
            byte[] buffer = encoding.GetBytes(text);

            return Convert.ToBase64String(buffer);
        }

        /// <summary>
        /// Converts a string from base64 encoded to UTF8.
        /// </summary>
        /// <param name="base64EncodedText">The base64 string to convert.</param>
        /// <returns>The converted UTF8 string.</returns>
        public static string ConvertFromBase64(string base64EncodedText)
        {
            return ConvertFromBase64(base64EncodedText, new UTF8Encoding());
        }

        /// <summary>
        /// Converts a string from base64 encoded to <paramref name="encoding" />.
        /// </summary>
        /// <param name="base64EncodedText">The base64 string to convert.</param>
        /// <param name="encoding">The target encoding.</param>
        /// <returns>The converted string.</returns>
        public static string ConvertFromBase64(string base64EncodedText, Encoding encoding)
        {
            byte[] buffer = Convert.FromBase64String(base64EncodedText);

            return encoding.GetString(buffer);
        }
    }
}
