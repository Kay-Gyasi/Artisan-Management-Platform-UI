namespace AMP.Web.Exceptions;

[Serializable]
public class HttpRequestFailedException : Exception
{
    public HttpRequestFailedException()
    {
    }

    public HttpRequestFailedException(string message) : 
        base($"Http Request failed: {message}")
    {

    }
}