using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Backend2.ViewModels;
using System.Linq;

namespace Backend2.Controllers
{

    // queue to be substituted with an actual queue like azure storage queue
    public class SimpleQueue
    {
        private static SimpleQueue instance;
        private Dictionary<int, MessageData> _queue;
        private SimpleQueue()
        {
            _queue = new Dictionary<int, MessageData>();
        }
        public static SimpleQueue Instance()
        {

            if (instance == null)
                instance = new SimpleQueue();

            return instance;
        }

        public void Enqueue(MessageData val)
        {
            var id = _queue.Count;
            val.Id = id;
            _queue.Add(id, val);
        }
        public IDictionary<int, MessageData> GetEveryMessageAfter(int key)
        {
            if (!_queue.ContainsKey(key))
                return new Dictionary<int, MessageData>();
            return _queue.Where(x => x.Key > key).ToDictionary(p => p.Key, p => p.Value);
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
            var queue = SimpleQueue.Instance();
            return queue.GetEveryMessageAfter(0).Select(x => x.Value);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<MessageData> Get(int id)
        {
            var queue = SimpleQueue.Instance();
            return queue.GetEveryMessageAfter(id).Select(x => x.Value);
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
