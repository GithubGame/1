namespace SimpleQueue.Test
// Learn more about F# at http://fsharp.org
open Xunit
open Backend2.Features
open Backend2.ViewModels

module BasicOpperation = 
    [<Fact>]
    let CanAddMessageData() =
        let queue = SimpleQueue()
        queue.Enqueue(MessageData())
        Assert.False(queue.IsEmpty)

    [<Fact>]
    let EnqueuedDataIsCorrect() =
        let queue = SimpleQueue()
        let data = MessageData()
        data.Message <- "message"
        data.User <- "user"
        queue.Enqueue(data)
        
        let messages = queue.GetEveryMessageAfter(0)
        
        Assert.Equal(messages.Count, 1)
        let message = messages.[0]
        Assert.Equal(message.User, "user")
        Assert.Equal(message.Message, "message")

    [<Fact>]
    let EnqueuedTwoMessagesUpdatesIdOnMessage() =
        let queue = SimpleQueue()
        let data1 = MessageData()
        data1.Message <- "message1"
        data1.User <- "user1"
        queue.Enqueue(data1)
        
        let data2 = MessageData()
        data2.Message <- "message2"
        data2.User <- "user2"
        queue.Enqueue(data2)

        let messages = queue.GetEveryMessageAfter(0)
        
        Assert.Equal(messages.Count, 2)
        let message = messages.[1]
        Assert.Equal(message.Id, 1)
        Assert.Equal(message.User, "user2")
        Assert.Equal(message.Message, "message2")
