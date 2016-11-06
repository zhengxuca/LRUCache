using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRUCache {
    public class LRUCache {

        LinkedListDict queueDict;

        int capacity;

        public LRUCache(int capacity) {
            this.capacity = (capacity > 0) ? capacity : 0;
            queueDict = new LinkedListDict(this.capacity);
        }

        public void IncreaseCapacity() {
            capacity *= 2;
            queueDict.SetCapacity(this.capacity);
        }

        private int GetSize() {
            return queueDict.GetSize();
        }

        private bool IsFull() {
            return queueDict.GetSize() == this.capacity;
        }
        public void Put(int id, string value) {

            Node data = null;
            bool found = queueDict.GetNode(id, out data);

            if (found) {
                //data already exist in the cache
                //update value;
                data.Value = value;
                queueDict.RemoveNode(data);
                queueDict.AddLast(data);
            } else {
                data = new Node(id, value);
                if (IsFull()) {
                    queueDict.RemoveFirst();
                    queueDict.AddLast(data);
                } else {
                    queueDict.AddLast(data);
                }
            }

        }

        public bool Get(int id, out string value) {
            Node data = null;
            bool found = queueDict.GetNode(id, out data);
            if (found) {
                value = data.Value;
                // update cache
                queueDict.RemoveNode(data);
                queueDict.AddLast(data);
                return true;
            } else {
                value = null;
                return false;
            }
        }
    }
}
