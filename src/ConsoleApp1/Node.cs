using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRUCache {
    public class Node {

        public Node Next { get; set; }
        public Node Prev { get; set; }

        public int id
        {
            get;
        }
        public string Value { get; set; }

        public Node(int id, string value) {
            this.id = id;
            this.Value = value;
        }
    }
}
