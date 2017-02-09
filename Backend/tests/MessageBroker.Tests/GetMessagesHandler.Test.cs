
using Xunit;
using Backend2.Features;
using Backend2.ViewModels;
using System.Linq;
using System.Collections.Generic;

public class GetMessagesHandleTests
{
    class SpyQueue : IQueue<MessageData>
    {
        public int Key { get; private set; }
        public IDictionary<int, MessageData> Data { get; set; }
        public void Enqueue(MessageData val)
        {

        }
        public IDictionary<int, MessageData> GetEveryMessageAfter(int key)
        {
            Key = key;
            return Data;
        }
    }
    [Fact]
    public void NullQueueNullMessageReturnsEmptyList()
    {
        var sut = new GetMessagesHandler(null);
        var result = sut.Handle(null);
        Assert.Equal(0, result.Count());
    }
    [Fact]
    public void RetreivesMessagesAfterIdFoundInGetMessages()
    {
        var queue = new SpyQueue();
        var data = new Dictionary<int, MessageData>();
        queue.Data = data;
        
        var sut = new GetMessagesHandler(queue);
        var result = sut.Handle(new GetMessages(1));
        
        Assert.Equal(1, queue.Key);
    }

    [Fact]
    public void ReturnsTheListReadFromTheQueue()
    {
        var queue = new SpyQueue();
        var data = new Dictionary<int, MessageData>();
        queue.Data = data;

        var sut = new GetMessagesHandler(queue);
        var result = sut.Handle(new GetMessages());
        
        Assert.True(data.Select(x => x.Value).SequenceEqual(result));
    }

    [Fact]
    public void ReturnsEmptyListIfQueueIsNull()
    {
        var queue = new SpyQueue();
        var data = new Dictionary<int, MessageData>();
        
        var sut = new GetMessagesHandler(queue);
        var result = sut.Handle(new GetMessages(1));
        
        Assert.Equal(1, queue.Key);
    }

}