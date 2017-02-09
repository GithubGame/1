
// Learn more about F# at http://fsharp.org
using Xunit;
using Backend2.Features;
using Backend2.ViewModels;

public class SimpleQueueTests
{
    [Fact]
    public void CanAddMessageData()
    {
        var queue = new SimpleQueue();
        queue.Enqueue(new MessageData());
        Assert.False(queue.IsEmpty);
    }

    [Fact]
    public void EnqueuedDataIsCorrect()
    {
        var queue = new SimpleQueue();
        var data = new MessageData
        {
            Message = "message",
            User = "user"
        };
        queue.Enqueue(data);

        var messages = queue.GetEveryMessageAfter(0);

        Assert.Equal(messages.Count, 1);
        var message = messages[0];
        Assert.Equal(message.User, "user");
        Assert.Equal(message.Message, "message");
    }
    [Fact]
    public void EnqueuedTwoMessagesUpdatesIdOnMessage()
    {
        var queue = new SimpleQueue();
        var data1 = new MessageData
        {
            Message = "message1",
            User = "user1"
        };
        queue.Enqueue(data1);

        var data2 = new MessageData
        {
            Message = "message2",
            User = "user2"
        };
        queue.Enqueue(data2);

        var messages = queue.GetEveryMessageAfter(0);

        Assert.Equal(messages.Count, 2);
        var message = messages[1];
        Assert.Equal(message.Id, 1);
        Assert.Equal(message.User, "user2");
        Assert.Equal(message.Message, "message2");
    }
    [Fact]
    public void GetAllMessagesAfterSomeId()
    {
        var queue = new SimpleQueue();
        var data1 = new MessageData
        {
            Message = "message1",
            User = "user1"
        };
        queue.Enqueue(data1);

        var data2 = new MessageData
        {
            Message = "message2",
            User = "user2"
        };
        queue.Enqueue(data2);

        var data3 = new MessageData
        {
            Message = "message3",
            User = "user3"
        };
        queue.Enqueue(data3);

        var messages = queue.GetEveryMessageAfter(1);

        Assert.Equal(messages.Count, 2);
        var message = messages[1];
        Assert.Equal(message.Id, 1);
        Assert.Equal(message.User, "user2");
        Assert.Equal(message.Message, "message2");

        message = messages[2];
        Assert.Equal(message.Id, 2);
        Assert.Equal(message.User, "user3");
        Assert.Equal(message.Message, "message3");
    }
}
