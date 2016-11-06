using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LRUCache {
    public class Program {

        public static void Main(string[] args) {

            LRUCache cache = new LRUCache(2);

            cache.Put(0, "Zheng");
            cache.Put(1, "Jack");

            string value = null;
            bool found = cache.Get(0, out value);
            Console.WriteLine(value);
            cache.Put(2, "Tom");

            cache.Get(1, out value);
            Console.WriteLine(value);

        }


    }
}
