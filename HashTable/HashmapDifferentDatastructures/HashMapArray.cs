using HashTable.HashmapDifferentDatastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace HashTable.HashmapDifferentDatastructures
{
    public class HashMapArray : AddGetRemove
    {

        //capacity är hur stor hashtabellen ska vara
        private int _capacity = 5;

        
        private student[][] hashtable;

        //Använder en load factor vilket är 70%, om arrayen är fylld till 70% så måste vi rezisa den
        private const float LoadFactorThreshold = 0.7f;

        //count räknar hur många bilar som ligger i våran hashtabell
        private int _count = 0;

        public HashMapArray()
        {
            try
            {
                hashtable = new student[_capacity][];
            }
            catch (Exception)
            {
                throw new Exception("Failed to create hashtables.");
            }
        }

        public void Add(string username, object value)
        {
            
            int index = HashFunctions.HashFunctionOne(username, _capacity);

            
            int startIndex = index;

            if (hashtable[startIndex] != null)
            {
                for (int i = 0; i < hashtable[startIndex].Length; i++)
                {
                    if (hashtable[startIndex][i] != null && username.Equals(hashtable[startIndex][i].UserName))
                    {
                        throw new Exception($"Key '{username}' already exists in the hashtable");
                    }
                    else if (hashtable[startIndex][i] == null)
                    {
                        hashtable[startIndex][i] = (student)value;
                        _count++;
                        if ((float)_count / _capacity >= LoadFactorThreshold)
                        {
                            ResizeTable();
                        }
                        break;
                    }
                }
            }
            else
            {
                hashtable[index] = new student[_capacity];
                hashtable[index][0] = (student)value;
                _count++;
                if ((float)_count / _capacity >= LoadFactorThreshold)
                {
                    ResizeTable();
                }
            }
        }
        public object Get(string Username)
        {
            int index = HashFunctions.HashFunctionOne(Username, _capacity);

            if (hashtable[index] != null)
            {
                for (int i = 0; i < hashtable[index].Length; i++)
                {
                    if (hashtable[index][i] != null && Username.Equals(hashtable[index][i].UserName))
                    {
                        return hashtable[index][i];
                    }
                }
            }
            Console.WriteLine("User not found.");
            return null;
        }

        public void Remove(string key)
        {
            int index = HashFunctions.HashFunctionOne(key, _capacity);

            if (hashtable[index] != null)
            {
                for (int i = 0; i < hashtable[index].Length; i++)
                {
                    if (hashtable[index][i] != null && key.Equals(hashtable[index][i].UserName))
                    {
                        hashtable[index][i] = null;
                        Console.WriteLine("Removed user: " + key);
                        _count--;
                    }
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
        private void ResizeTable()
        {
            int newCapacity = hashtable.Length * 2;

            student[][] newHashTable = new student[newCapacity][];

            _capacity = newCapacity;

            int htableindex = 0;

            foreach (student[] stud in hashtable)
            {
                if (stud != null)
                {
                    int index = HashFunctions.HashFunctionOne(stud[0].UserName, _capacity);

                    while (newHashTable[htableindex] != null)
                    {
                        htableindex = index;
                    }

                    newHashTable[htableindex] = stud;

                }
            }
            hashtable = newHashTable;
        }
        public void DisplayTable()
        {
            Console.WriteLine("[+] Hashmap array entries.");
            for (int i = 0; i < _capacity; i++)
            {
                if (hashtable[i] != null)
                {
                    for (int j = 0; j < hashtable[i].Length; j++)
                    {
                        if (hashtable[i][j] != null)
                        {
                            Console.WriteLine($"Index {i},{j}:" + hashtable[i][j]);
                        }
                    }
                }
            }
        }
        public int ReturnCount()
        {
            return _count;
        }
        public int ReturnCapacity()
        {
            return _capacity;
        }
    }
}