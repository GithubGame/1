using System.Collections.Generic;
using Backend2.ViewModels;
using MediatR;

namespace Backend2.Features
{

    public class GetMessages : IRequest<IEnumerable<MessageData>>
    {
        public int Id { get; private set; }
        public GetMessages(int id)
        {
            Id = id;
        }
        public GetMessages()
        {
            Id = 0;
        }
    }
}