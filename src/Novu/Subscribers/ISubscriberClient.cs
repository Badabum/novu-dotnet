using Novu.Exceptions;
using Refit;

namespace Novu.Subscribers;

public interface ISubscriberClient
{
    /// <summary>
    /// Get a paginated response of current Subscribers
    /// </summary>
    /// <returns></returns>
    /// <exception cref="HttpRequestException">
    ///  Thrown when the status code does not equal 200.
    /// </exception>
    /// <exception cref="NovuClientException"></exception>
    [Get("/subscribers")]
    Task<PaginatedResponse<Subscriber>> GetSubscribers([Query] int page = 0);

    /// <summary>
    /// Get a single Subscriber
    /// </summary>
    /// <param name="id"><see cref="String"/> Subscriber ID</param>
    /// <returns></returns>
    [Get("/subscribers/{id}")]
    Task<Subscriber> GetSubscriber(string id);
    /// <summary>
    /// Create a new Subscriber
    /// </summary>
    /// <param name="dto">
    /// <see cref="CreateSubscriberDto"/> Model to create a new Subscriber
    /// </param>
    /// <returns>
    /// <see cref="Subscriber"/> The newly created Subscriber
    /// </returns>
    [Post("/subscribers")]
    Task<Subscriber> CreateSubscriber([Body]CreateSubscriberDto dto);

    /// <summary>
    /// Update a Subscriber
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Put("/subscribers/{id}")]
    Task<Subscriber> UpdateSubscriber(string id, [Body]Subscriber request);

    /// <summary>
    /// Delete a Subscriber
    /// </summary>
    /// <param name="id">
    /// <see cref="string"/> Subscriber ID to delete
    /// </param>
    /// <returns>
    /// <see cref="DeleteResponse"/>
    /// </returns>
    [Delete("/subscribers/{id}")]
    Task<DeleteResponse> DeleteSubscriber(string id);
    /// <summary>
    /// Update Subscribers online status
    /// </summary>
    /// <param name="subscriberId"><see cref="Subscriber.SubscriberId"/> Subscribers ID</param>
    /// <param name="model"><see cref="SubscriberOnlineDto"/></param>
    /// <returns></returns>
    [Patch("/subscribers/{subscriberId}/online-status")]
    Task<Subscriber> UpdateOnlineStatus(string subscriberId, [Body]SubscriberOnlineDto model);
}