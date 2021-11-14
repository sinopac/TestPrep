using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    public class LRUCache
    {
        private List<Tuple<int, int, DateTime>> cacheData;
        private int capacity;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.cacheData = new List<Tuple<int, int, DateTime>>();
        }

        public int Get(int key)
        {
            var data = cacheData.FirstOrDefault(x => x.Item1 == key);

            if (data != null)
            {
                this.cacheData.Remove(data);
                this.cacheData.Add(new Tuple<int, int, DateTime>(key, data.Item2, DateTime.Now));
                return data.Item2;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            var data = cacheData.FirstOrDefault(x => x.Item1 == key);

            if (data != null)
            {
                this.cacheData.Remove(data);
                this.cacheData.Add(new Tuple<int, int, DateTime>(key, value, DateTime.Now));
            }
            else if (cacheData.Count < this.capacity)
            {
                cacheData.Add(new Tuple<int, int, DateTime>(key, value, DateTime.Now));
            }
            else
            {
                var dataToRemove = cacheData.OrderBy(x => x.Item3).First();
                cacheData.Remove(dataToRemove);

                cacheData.Add(new Tuple<int, int, DateTime>(key, value, DateTime.Now));
            }
        }
    }
}