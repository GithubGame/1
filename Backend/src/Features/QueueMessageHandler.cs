using MediatR;

namespace Backend2.Features
{

    public class QueueMessagesHandler : IRequestHandler<QueueMessage>
    {
        public void Handle(QueueMessage message)
        {
            var queue = SimpleQueue.Instance();            
            queue.Enqueue(message.data);
        }
    }
}