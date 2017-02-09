using Backend2.ViewModels;
using MediatR;

namespace Backend2.Features
{

    public class QueueMessagesHandler : IRequestHandler<QueueMessage>
    {
        IQueue<MessageData> _queue;
        public QueueMessagesHandler(IQueue<MessageData> queue){
            this._queue = queue;
        }
        public void Handle(QueueMessage message)
        {
            if(_queue == null || message == null || message.data == null)
                return;
            _queue.Enqueue(message.data);
        }
    }
}