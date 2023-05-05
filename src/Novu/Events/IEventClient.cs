using Refit;

namespace Novu.Events;

public interface IEventClient
{
    [Post("/events/trigger")]
    Task<TriggerResponse> Trigger([Body]EventTriggerDataDto dto);

    [Post("/events/trigger/bulk")]
    Task<TriggerBulkResponse> TriggerBulkAsync([Body] List<EventTriggerDataDto> payload);

    [Post("/events/trigger/broadcast")]
    Task<TriggerResponse> TriggerBroadcastAsync([Body]EventTriggerDataDto dto);

    [Delete("/events/trigger/{transactionId}")]
    Task TriggerCancelAsync(Guid transactionId);

    [Post("/events/trigger")]
    Task<TriggerResponse> TriggerTopicAsync(EventTopicTriggerDto dto);
}