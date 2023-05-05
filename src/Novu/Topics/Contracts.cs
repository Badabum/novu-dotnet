using System.Collections.Immutable;
using Newtonsoft.Json;

namespace Novu.Topics;
public record CreateTopicRequest(string Key, string Name);
public record RenameTopicRequest(string Name);
public record TopicCreateResponse(TopicData Data);
public record TopicData([JsonProperty("_id")]string Id, string Key);
public record TopicResponse(Topic Data);
public record TopicSubscriberAdditionResponse(TopicSubscriberAdditionResponseData Data);
public record TopicSubscriberAdditionResponseData(string[] Succeeded);
public record TopicSubscriber(TopicSubscriberData Data);
public record TopicSubscriberUpdate(ImmutableArray<string> Subscribers);
public record TopicSubscriberData
{
    [JsonProperty("_id")]
    public string Id { get; set; }

    [JsonProperty("_environmentId")]
    public string EnvironmentId { get; set; }

    [JsonProperty("_organizationId")]
    public string OrganizationId { get; set; }

    [JsonProperty("_subscriberId")]
    public string SubscriberId { get; set; }

    [JsonProperty("_topicId")]
    public string TopicId { get; set; }

    [JsonProperty("externalSubscriberId")]
    public string ExternalSubscriberId { get; set; }

    [JsonProperty("topicKey")]
    public string TopicKey { get; set; }

    [JsonProperty("__v")]
    public long V { get; set; }

    [JsonProperty("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonProperty("id")]
    public string DataId { get; set; }
}
public record Topic(
    [property: JsonProperty("_id")]string Id,
    [property: JsonProperty("_environment")]string EnvironmentId,
    [property: JsonProperty("_organizationId")]string OrganizationId,
    string Key,
    string Name,
    string[] Subscribers);