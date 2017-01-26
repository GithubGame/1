
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

namespace MaxBackend.Controllers
{
    public class SimpleQueue
    {
        private static SimpleQueue instance;
        private Queue<string> Queue;
        private SimpleQueue()
        {
            Queue = new Queue<string>();
        }
        public static SimpleQueue Instance()
        {

            if (instance == null)
                instance = new SimpleQueue();

            return instance;
        }

        public void Enqueue(string value)
        {
            Queue.Enqueue(value);
        }
        public string Dequeue()
        {
            return Queue.Dequeue();
        }
        public bool IsEmpty
        {
            get { return Queue.Count == 0; }
        }
    }
    [Route("api/[controller]")]
    public class MessageController : Controller
    {

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> queued = new List<string>();
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
        public class Person  
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
        // POST api/values
        [HttpPost]
        public string Post([FromBody]dynamic message)
        {
            SimpleQueue.Instance().Enqueue(message);
            return message;
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
