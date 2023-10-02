using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable.HashmapDifferentDatastructures
{
    public class HashMapLinkedList : AddGetRemove

    {
        //capacity är hur stor hashtabellen ska vara
        private int _capacity = 5;

        //skapar hashtabellen som kommer innehålla cars
        private LinkedList<KeyValuePair<string, object>>[] hashtable;

        //Använder en load factor vilket är 70%, om arrayen är fylld till 70% så måste vi rezisa den
        private const float LoadFactorThreshold = 0.7f;

        //count räknar hur många studenter som ligger i våran hashtabell
        private int _count = 0;

        public HashMapLinkedList()
        {
            hashtable = new LinkedList<KeyValuePair<string, object>>[_capacity];
        }

        public int ReturnCount()
        {
            return _count;
        }

        public int ReturnCapacity()
        {
            return _capacity;
        }

        public void Add(string Username, object value)
        {
            //Om vi har en capacity över eller lika med 0.7
            //då kör vi en rezise
            if ((float)_count / _capacity >= LoadFactorThreshold)
            {
                ResizeTable();
            }

            //Får en index position genom hashfunction
            int index = HashFunctions.HashFunctionTwo(Username, _capacity);
            //start inex blir det index som vi får
            int startIndex = index;

            //Om platsen är tagen, alltså isOccupied
            //while (hashtable[index] != null)
            //{

            if (hashtable[index] == null)
            {
                hashtable[index] = new LinkedList<KeyValuePair<string, object>>();
            }

            foreach (KeyValuePair<string, object> item in hashtable[index])
            {
                if (item.Key == Username)
                {
                    throw new Exception($"Key '{Username}' already exists in the hashtable");
                }
            }
            
            hashtable[index].AddLast(new KeyValuePair<string, object>(Username, value));
            _count++;
            if ((float)_count / _capacity >= LoadFactorThreshold)
            {
                ResizeTable();
            }

        }
        public object Get(string Username)
        {
            int index = HashFunctions.HashFunctionTwo(Username, _capacity);//calculate the index for the reg number
            int startIndex = index;//store the starting index for linear probing

            
            foreach (KeyValuePair<string, object> item in hashtable[index])
            {
                if (item.Key == Username)
                {
                    return item.Value;
                }
            }
            throw new KeyNotFoundException("No such key in hashtable.");
        }



        public void Remove(string key)
        {
            int index = HashFunctions.HashFunctionTwo(key, _capacity);//calculate the index for the reg number
            int startIndex = index;//store the starting index for linear probing

            if (hashtable[index] != null)
            {
                LinkedListNode<KeyValuePair<string, object>> node = hashtable[index].First;

                while (node != null)
                {
                    if (node.Value.Key == key)
                    {
                        hashtable[index].Remove(node);
                        Console.WriteLine(key + " removed");
                        _count--;
                        return;
                    }
                    node = node.Next;
                }
                throw new KeyNotFoundException("No such key in hashtable.");
            }
        }


        private void ResizeTable()
        {
            int newCapacity = hashtable.Length * 2;

            LinkedList<KeyValuePair<string, object>>[] newHashTable = new LinkedList<KeyValuePair<string, object>>[newCapacity];

            _capacity = newCapacity;

            foreach (LinkedList<KeyValuePair<string, object>> stud in hashtable)
            {
                if (stud != null)
                {
                    int index = HashFunctions.HashFunctionTwo(stud.First.Value.Key, _capacity);

                    while (newHashTable[index] != null)
                    {
                        index = (index + 1) % newCapacity;
                    }

                    newHashTable[index] = stud;

                }
            }
            hashtable = newHashTable;
        }


        public void DisplayTable()
        {
            Console.WriteLine("[+] Hashmap LinkedList entries.");
            foreach (LinkedList<KeyValuePair<string,object>> stud in hashtable)
            {
                if(stud != null)
                {
                    foreach (var item in stud)
                    {
                        if (item.Key != null)
                        {
                            Console.WriteLine(item.Value.ToString());
                        }

                    }
                }
               
            }

        }
    }
}
