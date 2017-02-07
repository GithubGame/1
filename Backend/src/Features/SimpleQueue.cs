using System.Collections.Generic;
using System.Linq;
using Backend2.ViewModels;

namespace Backend2.Features{
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

}