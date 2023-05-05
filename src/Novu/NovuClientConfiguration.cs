namespace Novu;

public class NovuClientConfiguration
{
    /// <summary>
    /// Full URL to where the Novu API is housed. Defaults to
    /// https://api.novu.co/v1
    /// </summary>
    public string Url { get; set; } = "https://api.novu.co/v1";
    
    /// <summary>
    /// Api Key used for authentication. Found on the Settings
    /// page > API Keys > API Key.
    /// </summary>
    public string ApiKey { get; set; }
}