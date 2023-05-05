using Novu.Events;
using Novu.Subscribers;
using Novu.Topics;

namespace Novu;

public interface INovuClient
{
    public ISubscriberClient Subscribers { get; }
    
    public IEventClient Event { get; }
    
    public ITopicClient Topic { get; }
}