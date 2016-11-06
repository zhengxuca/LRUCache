using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRUCache {
    public class LinkedListDict {
        Node head, tail;
        int size;
        int capacity;
        Dictionary<int, Node> dict;
        public LinkedListDict(int capacity) {
            head = null;
            tail = null;
            size = 0;
            this.capacity = capacity;
            dict = new Dictionary<int, Node>();
        }

        public void SetCapacity(int capacity) {
            this.capacity = capacity;
        }

        public int GetSize() {
            return size;
        }

        public bool GetNode(int id, out Node data) {
            bool found = dict.TryGetValue(id,  out data);
            return found;
        }

        public bool GetFirst(out Node result) {
            if (head != null) {
                result = head;
                return true;
            } else {
                result = null;
                return false;
            }
        }

        public void AddLast(Node n) {
            if(this.size==this.capacity) {
                throw new Exception("full cache");
            }
            if (tail == null) {
                tail = n;
                head = n;
            } else {
                tail.Next = n;
                n.Prev = tail;
                tail = tail.Next;
            }
            dict.Add(n.id, n);
            size++;
        }

        public void RemoveFirst() {
            RemoveNode(head);
        }

        public void RemoveNode(Node n) {
            // A -> n ->B
            Node prev = n.Prev;
            Node next = n.Next;

            if (prev == null) {
                head = head.Next;
            } else {
                prev.Next = next;
            }

            if (next == null) {
                tail = tail.Prev;
            } else {
                next.Prev = prev;
            }
            dict.Remove(n.id);
            size--;
        }

    }
}
