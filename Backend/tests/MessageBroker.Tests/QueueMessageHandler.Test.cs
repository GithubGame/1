
using Xunit;
using Backend2.Features;
using Backend2.ViewModels;
using System.Linq;
using System.Collections.Generic;

public class QueueMessageHandlerTest
{
    class SpyQueue : IQueue<MessageData>
    {
        public bool Called{get; private set;}
        public MessageData Data { get; set; }
        public void Enqueue(MessageData val)
        {
            Data = val;
            Called = true;
        }
        public IDictionary<int, MessageData> GetEveryMessageAfter(int key)
        {
            return null;
        }
    }
    [Fact]
    public void NullQueueNullMessageDoesNothing()
    {
        var sut = new QueueMessagesHandler(null);
        sut.Handle(null);
        Assert.True(true);
    }
    [Fact]
    public void NullMessageDoesNothing()
    {
        var queue = new SpyQueue();
        var sut = new QueueMessagesHandler(queue);
        
        sut.Handle(null);
        Assert.True(true);
    }
    [Fact]
    public void NullDataDoesNothing()
    {
        var queue = new SpyQueue();
        var data = new MessageData();
        var message = new QueueMessage(null);

        var sut = new QueueMessagesHandler(queue);
        sut.Handle(message);
        
        Assert.Equal(false, queue.Called);
        Assert.Equal(null, queue.Data);
    }

    [Fact]
    public void QueueReseivesMessageFromHandler()
    {
        var queue = new SpyQueue();
        var data = new MessageData();
        var message = new QueueMessage(data);

        var sut = new QueueMessagesHandler(queue);
        sut.Handle(message);
        
        Assert.Equal(true, queue.Called);
        Assert.Equal(data, queue.Data);
    }

}