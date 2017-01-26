using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Backend2.ViewModels;

namespace Backend2.Controllers
{

    // queue to be substituted with an actual queue like azure storage queue
    public class SimpleQueue
    {
        private static SimpleQueue instance;
        private Queue<MessageData> _queue;
        private SimpleQueue()
        {
            _queue = new Queue<MessageData>();
        }
        public static SimpleQueue Instance()
        {

            if (instance == null)
                instance = new SimpleQueue();

            return instance;
        }

        public void Enqueue(MessageData value)
        {
            _queue.Enqueue(value);
        }
        public MessageData Dequeue()
        {
            return _queue.Dequeue();
        }
        public bool IsEmpty
        {
            get { return _queue.Count == 0; }
        }
    }
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<MessageData> Get()
        {
            var queued = new List<MessageData>();
            var queue = SimpleQueue.Instance();
            while (!queue.IsEmpty)
            {
                queued.Add(queue.Dequeue());
            }
            return queued;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
        // POST api/values
        [HttpPost]
        public void Post([FromBody]MessageData data)
        {
            SimpleQueue.Instance().Enqueue(data);
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
