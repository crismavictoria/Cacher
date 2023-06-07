using System;
using System.Collections.Generic;

namespace Diana.Code.Challenge
{
    /// <question>
    /// Implement this class as required.
    /// </question>
    public class SuperFastCache<T> : ICacheStuff<T> where T : Employee
    {
        public string CacheName => "Super Fast Cache x1000 faster!\r\n\r";

         public Dictionary<Guid, T> Items { get; private set; }

        public SuperFastCache()
        {
            Items = new Dictionary<Guid, T>();
        }

        public void AddItem(T newItem)
        {
           Items.Add(newItem.Id, newItem);
        }

        public string GetName(Guid id)
        {
            if (Items.TryGetValue(id, out var item))
            {
                return item.name;
            }
            return null;
        }

        T ICacheStuff<T>.FindItem(Guid id)
        {
              if (Items.TryGetValue(id, out var item))
            {
                return item;
            }
            return null;
        }
    }
}
