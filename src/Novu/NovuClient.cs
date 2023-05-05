using Novu.Events;
using Novu.Subscribers;
using Novu.Topics;
using Refit;

namespace Novu;

public class NovuClient : INovuClient
{
    public NovuClient(NovuClientConfiguration configuration): this(configuration, default) {}

    public NovuClient(NovuClientConfiguration configuration,HttpClient? client = default)
    {
        var httpClient = client ?? new HttpClient();
        httpClient.BaseAddress = new Uri(configuration.Url);
        httpClient.DefaultRequestHeaders.Add("Authorization", $"ApiKey {configuration.ApiKey}");
        Subscribers = RestService.For<ISubscriberClient>(httpClient);
        Event = RestService.For<IEventClient>(httpClient);
        Topic = RestService.For<ITopicClient>(httpClient);
    }

    public ISubscriberClient Subscribers { get; }
    
    public IEventClient Event { get; }
    
    public ITopicClient Topic { get; }
}