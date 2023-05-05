using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Novu.Events;
using Novu.Subscribers;
using Novu.Topics;
using Refit;

namespace Novu;

public class NovuClient : INovuClient
{
    private static readonly JsonSerializerSettings SerializerSettings = new()
    {
        MissingMemberHandling = MissingMemberHandling.Ignore,
        NullValueHandling = NullValueHandling.Ignore,
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        }
    };
    public NovuClient(NovuClientConfiguration configuration): this(configuration, default) {}

    public NovuClient(NovuClientConfiguration configuration,HttpClient? client = default)
    {
        var httpClient = client ?? new HttpClient();
        httpClient.BaseAddress = new Uri(configuration.Url);
        httpClient.DefaultRequestHeaders.Add("Authorization", $"ApiKey {configuration.ApiKey}");
        Subscribers = RestService.For<ISubscriberClient>(httpClient);
        Event = RestService.For<IEventClient>(httpClient, new RefitSettings()
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(SerializerSettings)
        });
        Topic = RestService.For<ITopicClient>(httpClient);
    }

    public ISubscriberClient Subscribers { get; }
    
    public IEventClient Event { get; }
    
    public ITopicClient Topic { get; }
}