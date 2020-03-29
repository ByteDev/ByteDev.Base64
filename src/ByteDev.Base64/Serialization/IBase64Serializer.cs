namespace ByteDev.Base64.Serialization
{
    /// <summary>
    /// Provides a way to serialize and deserialize objects.
    /// </summary>
    public interface IBase64Serializer
    {
        /// <summary>
        /// Serializes an object to a base64 string.
        /// </summary>
        /// <param name="obj">Object to serialize to base64.</param>
        /// <returns>Serialized representation of <paramref name="obj" />.</returns>
        string Serialize(object obj);

        /// <summary>
        /// Deserialize a base64 serialized representation to type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">Type to deserialize to.</typeparam>
        /// <param name="base64">Serialized base64 string representation.</param>
        /// <returns>Deserialized type.</returns>
        T Deserialize<T>(string base64);
    }
}