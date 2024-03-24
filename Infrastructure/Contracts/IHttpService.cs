namespace Infrastructure.Contracts;

internal interface IHttpService
{
    /// <summary>
    /// Sends a GET request to the specified URL and deserializes the response body into an instance of the specified type T.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize the response body into. This must be a class.</typeparam>
    /// <param name="url">The URL to send the GET request to.</param>
    /// <returns>Returns the deserialized object of type T from the response body, or null if the request failed.</returns>
    Task<T?> Get<T>(string url) where T : class;
}