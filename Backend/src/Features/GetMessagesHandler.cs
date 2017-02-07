using System.Collections.Generic;
using System.Linq;
using Backend2.ViewModels;
using MediatR;

namespace Backend2.Features
{

public class GetMessagesHandler : IRequestHandler<GetMessages, IEnumerable<MessageData>>
    {
        public IEnumerable<MessageData> Handle(GetMessages message)
        {
            var queue = SimpleQueue.Instance();
            return queue.GetEveryMessageAfter(message.Id).Select(x => x.Value);
        }
    }
}