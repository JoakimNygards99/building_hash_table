using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public interface AddGetRemove
    {
        void Add(string key, object value);
        object Get(string key);
        void Remove(string key);
    }
}
