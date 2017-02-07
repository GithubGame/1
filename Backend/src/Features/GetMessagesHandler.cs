using System.Collections.Generic;
using System.Linq;
using Backend2.ViewModels;
using MediatR;

namespace Backend2.Features
{

    public class GetMessagesHandler : IRequestHandler<GetMessages, IEnumerable<MessageData>>
    {
        IQueue<MessageData> _queue;
        public GetMessagesHandler(IQueue<MessageData> queue){
            System.Console.WriteLine("new GetMEssages");
            
            this._queue = queue;
        }
        public IEnumerable<MessageData> Handle(GetMessages message)
        {
            System.Console.WriteLine("call to handlers");
            
            if(_queue == null){
                System.Console.WriteLine("Queue null");
                return new List<MessageData>();
            }
            return _queue.GetEveryMessageAfter(message.Id).Select(x => x.Value);
        }
    }
}