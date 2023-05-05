namespace Novu.Events;
public record TriggerResponsePayload(bool Acknowledged, string Status, Guid TransactionId);
public record TriggerResponse(TriggerResponsePayload Data);
public record TriggerBulkResponse(List<TriggerResponsePayload> Data);
public record TriggerBulkDto(List<EventTriggerDataDto> Events);
public record EventTriggerDataDto(string Name, EventToDto To, object Payload, List<object>? Override = default, string? TransactionId = default);
public record EventToDto(string SubscriberId);

public record EventTopicTriggerDto(string Name, EventTopicDto To, object Payload, object? Overrides = default);

/// <summary>
/// 
/// </summary>
/// <param name="TopicKey"><example>post:123:comments</example></param>
/// <param name="Type">Type of Subscriber payload. Defaults to Topic which shouldn't change unless there is a change on the Novu API.</param>
public record EventTopicDto(string TopicKey, string Type = "Topic");
