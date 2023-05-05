using Newtonsoft.Json;
using Novu.Events;
using Novu.Tests.Fixtures;
using Novu.Topics;

namespace Novu.Tests.Events;

public class EventUnitTest : IClassFixture<SubscriberFixture>
{
    private readonly SubscriberFixture _fixture;

    public EventUnitTest(SubscriberFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async void Should_Trigger_Event()
    {
        // Create a subscriber to test against.
        var subscriber = await _fixture.GenerateTestSubscriber();

        var client = _fixture.NovuClient;
        
        var testRecord = new TestRecord
        {
            Message = "This is a test message"
        };

        if (subscriber.SubscriberId == null) throw new Exception("Subscriber Id is null");

        var dto = new EventTriggerDataDto("test", new EventToDto(subscriber.SubscriberId), testRecord);

        var trigger = await client.Event.Trigger(dto);

        if (!trigger.Data.Acknowledged)
        {
            throw new Exception("Trigger response returned an acknowledge of false");
        }
    }

    [Fact]
    public async void Should_Trigger_Bulk_Event()
    {
        var subscriber = await _fixture.GenerateTestSubscriber();

        var client = _fixture.NovuClient;

        var payload = new List<EventTriggerDataDto>()
        {
            new("test", new EventToDto(subscriber.SubscriberId), new TestRecord { Message = "Hello"}),
            new("test", new EventToDto(subscriber.SubscriberId), new TestRecord { Message = "World"})
        };

        var trigger = await client.Event.TriggerBulkAsync(payload);

        if (trigger.Data.Count != 2)
        {
            throw new Exception("Trigger response returned an acknowledge of false");
        }

        if (trigger.Data.Any(triggerPayload => !triggerPayload.Acknowledged))
        {
            throw new Exception("Trigger response returned an acknowledge of false");
        }
    }

    [Fact]
    public async void Should_Trigger_Broadcast_Event()
    {
        // Create a subscriber to test against.
        var subscriber = await _fixture.GenerateTestSubscriber();

        var client = _fixture.NovuClient;
        
        var testRecord = new TestRecord
        {
            Message = "This is a test message"
        };

        if (subscriber.SubscriberId == null) throw new Exception("Subscriber Id is null");

        var dto = new EventTriggerDataDto("test", new EventToDto(subscriber.SubscriberId), testRecord);

        var trigger = await client.Event.TriggerBroadcastAsync(dto);

        if (!trigger.Data.Acknowledged)
        {
            throw new Exception("Trigger response returned an acknowledge of false");
        }
    }

    [Fact]
    public async void Should_Trigger_Cancel_Event()
    {
        var subscriber = await _fixture.GenerateTestSubscriber();

        var client = _fixture.NovuClient;
        
        var testRecord = new TestRecord
        {
            Message = "This is a test message"
        };

        if (subscriber.SubscriberId == null) throw new Exception("Subscriber Id is null");

        var dto = new EventTriggerDataDto("test", new EventToDto(subscriber.SubscriberId), testRecord);

        var trigger = await client.Event.TriggerBroadcastAsync(dto);

        if (!trigger.Data.Acknowledged)
        {
            throw new Exception("Trigger response returned an acknowledge of false");
        }

        await client.Event.TriggerCancelAsync(trigger.Data.TransactionId);
    }

    [Fact]
    public async void Should_Trigger_Topic()
    {
        var client = _fixture.NovuClient;
        
        var testRecord = new TestRecord
        {
            Message = "This is a test message"
        };

        var topic = await client.Topic.CreateTopicAsync(new CreateTopicRequest($"topic:test:{Guid.NewGuid().ToString()}", "Test Topic"));

        var dto = new EventTopicTriggerDto("test", new EventTopicDto(topic.Data.Key), testRecord);

        var topicTrigger = await client.Event.TriggerTopicAsync(dto);

        Assert.True(topicTrigger.Data.Acknowledged);
    }
}

public record TestRecord
{
    [JsonProperty("message")]
    public string Message { get; set; }
}