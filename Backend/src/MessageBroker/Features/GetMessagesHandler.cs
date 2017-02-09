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
            this._queue = queue;
        }
        public IEnumerable<MessageData> Handle(GetMessages message)
        {
            if(_queue == null){
                return new List<MessageData>();
            }
            var result = _queue.GetEveryMessageAfter(message.Id);
            if(result == null){
                return new List<MessageData>();
            }
            return result.Select(x => x.Value);
        }
    }
}