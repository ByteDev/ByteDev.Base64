namespace ByteDev.Base64.Serialization
{
    /// <summary>
    /// Provides a way to serialize and deserialize objects.
    /// </summary>
    public interface IBase64Serializer
    {
        /// <summary>
        /// Serializes a object to a string.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <returns>Serialized representation of <paramref name="obj" />.</returns>
        string Serialize(object obj);

        /// <summary>
        /// Deserialize a serialized representation to type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">Type to deserialize to.</typeparam>
        /// <param name="input">Serialized string representation.</param>
        /// <returns>Deserialized type.</returns>
        T Deserialize<T>(string input);
    }
}