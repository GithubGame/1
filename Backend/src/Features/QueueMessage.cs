using System.Collections.Generic;
using Backend2.ViewModels;
using MediatR;

namespace Backend2.Features
{
    public class QueueMessage : IRequest
    {
        public MessageData data { get; private set; }
        public QueueMessage(MessageData data)
        {
            this.data = data;
        }
    }

}