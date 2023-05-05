using Newtonsoft.Json;

namespace Novu.Subscribers;

public record SubscriberOnlineDto(bool IsOnline);
public record Subscriber
{
    [JsonProperty("_organizationId")]
    public string OrganizationId { get; set; }

    [JsonProperty("_environmentId")]
    public string EnvironmentId { get; set; }
    public string? SubscriberId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public object[] Channels { get; set; }
    public bool? Deleted { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public bool? IsOnline { get; set; }
    public DateTimeOffset? LastOnlineAt { get; set; }
}
public class CreateSubscriberDto
{
    [JsonProperty("subscriberId")]
    public string SubscriberId { get; set; }
    [JsonProperty("email")]
    public string? Email { get; set; }
    
    [JsonProperty("firstName")]
    public string? FirstName { get; set; }

    [JsonProperty("lastName")]
    public string? LastName { get; set; }
    
    [JsonProperty("phone")]
    public string? Phone { get; set; }
    
    [JsonProperty("avatar")]
    public string? Avatar { get; set; }
    
    [JsonProperty("locale")]
    public string? Locale { get; set; }
    
    [JsonProperty("data")]
    public List<AdditionalData>? Data { get; set; }
}