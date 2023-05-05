using Refit;

namespace Novu.Notifications;

public interface INotificationsClient
{
    [Get("/notifications")]
    public Task GetNotificationsAsync();
    public Task GetNotificationStatisticsAsync();

    public Task GetNotificationGraphStatisticsAsync();
    
    public Task GetNotificationAsync(string notificationId);
}