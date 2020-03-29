namespace ByteDev.Base64
{
    /// <summary>
    /// Extension methods for <see cref="T:System.String" />.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if the string is potentially base64 encoded.
        /// </summary>
        /// <param name="source">The string to perform this operation on.</param>
        /// <returns>True if string is base64 encoded; otherwise returns false.</returns>
        public static bool IsBase64(this string source)
        {
            return Base64Encoder.IsBase64Encoded(source);
        }
    }
}