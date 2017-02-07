using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Backend2.ViewModels;
using MediatR;
using System.Threading.Tasks;
using Backend2.Features;

namespace Backend2.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private IMediator mediator;
        public MessageController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<MessageData>> Get()
        {
            return await mediator.Send(new GetMessages());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<MessageData>> Get(int id)
        {
            return await mediator.Send(new GetMessages(id));
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]MessageData data)
        {
            await mediator.Send(new QueueMessage(data));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
