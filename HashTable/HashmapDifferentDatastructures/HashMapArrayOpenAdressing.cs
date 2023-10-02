using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HashTable.HashmapDifferentDatastructures
{
    public class HashMapArrayOpenAdressing
    {
        //capacity är hur stor hashtabellen ska vara
        private int _capacity = 5;

        private student[] hashtable;

        //Använder en load factor vilket är 70%, om arrayen är fylld till 70% så måste vi rezisa den
        private const float LoadFactorThreshold = 0.7f;

        //count räknar hur många bilar som ligger i våran hashtabell
        private int _count = 0;


        public HashMapArrayOpenAdressing()
        {
            try
            {
                hashtable = new student[_capacity];
            }
            catch (Exception)
            {
                throw new Exception("Failed to create hashtables.");
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

        public void AddOpenAddressing(string username, object value, string option)
        {

          

            int index = HashFunctions.HashFunctionOne(username, _capacity);

            switch (option)
            {

                //The normal Open adressing
                //Start-------------------------------------------------------------------------------------------------------------------------------------------------------
                case "1":
                    //writes hashtable2.length + 1 to check if there are a collison and it is the last index, and it is taken, therefore we must loop thorugh the hashmap again from the beginning
                    for (int i = index; i < hashtable.Length + 1; i++)
                    {
                        if (i >= hashtable.Length)
                        {
                            for (int a = 0; a < hashtable.Length; a++)
                            {
                                if (hashtable[a] != null && hashtable[a].UserName == username)
                                {
                                    throw new Exception($"Key '{username}' already exists in the hashtable");
                                }

                                if (hashtable[a] == null)
                                {
                                    hashtable[a] = (student)value;
                                    _count++;
                                    if ((float)_count / _capacity >= LoadFactorThreshold)
                                    {
                                        ResizeTable();
                                    }
                                    return;
                                }

                            }
                        }

                        if (hashtable[i] != null && hashtable[i].UserName == username)
                        {
                            throw new Exception($"Key '{username}' already exists in the hashtable");
                        }

                        if (hashtable[i] == null)
                        {
                            hashtable[i] = (student)value;
                            _count++;
                            if ((float)_count / _capacity >= LoadFactorThreshold)
                            {
                                ResizeTable();
                            }
                            return;

                        }
                    }
                    break;
                //End-------------------------------------------------------------------------------------------------------------------------------------------------------


                //The quadratic open adressing
                //Start-------------------------------------------------------------------------------------------------------------------------------------------------------
                case "2":
                    int j = 0;
                    while (true)
                    {
                        if (hashtable[index] != null)
                        {
                            j++;
                            index = (int)Math.Pow(j, 2);
                            if (index > _capacity)
                            {
                                for (int i = 0; i < _capacity; i++)
                                {
                                    if (hashtable[i] != null && hashtable[i].UserName == username)
                                    {
                                        throw new Exception($"Key '{username}' already exists in the hashtable");
                                    }

                                    if (hashtable[i] == null)
                                    {
                                        hashtable[i] = (student)value;
                                        _count++;
                                        if ((float)_count / _capacity >= LoadFactorThreshold)
                                        {
                                            ResizeTable();
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }

                        if (hashtable[index] != null && hashtable[index].UserName == username)
                        {
                            throw new Exception($"Key '{username}' already exists in the hashtable");
                        }

                        if (hashtable[index] == null)
                        {
                            hashtable[index] = (student)value;
                            _count++;
                            if ((float)_count / _capacity >= LoadFactorThreshold)
                            {
                                ResizeTable();
                            }
                            break;
                        }
                    }
                    break;
                    //End-------------------------------------------------------------------------------------------------------------------------------------------------------
            }
        }


        public Object GetOpenAddressing(string username, string option)
        {
            student student = null;
            int index = HashFunctions.HashFunctionOne(username, _capacity);
            switch (option)
            {
                //case 1 is the ordinary open adressing
                case "1":
                    for (int i = index; i < _capacity + 1; i++)
                    {

                        //Denna kod körs bara om det blir två på sista indexet
                        if (i >= _capacity)
                        {
                            for (int a = 0; a < hashtable.Length; a++)
                            {
                                if (hashtable[a].UserName == username)
                                {
                                    student = (student)hashtable[a];
                                    break;
                                }
                            }
                            break;
                        }

                        if (hashtable[i] == null)
                        {
                            Console.WriteLine("null");
                        }
                        else if (hashtable[i].UserName == username)
                        {
                            student = (student)hashtable[i];
                            break;
                        }
                    }
                    break;


                //case 2 is the quadratic open addressing
                case "2":
                    int j = 0;
                    while (true)
                    {
                        if (hashtable[index].UserName != username)
                        {
                            j++;
                            index = (int)Math.Pow(j, 2);
                            if (index > _capacity)
                            {
                                for (int i = 0; i < _capacity; i++)
                                {
                                    if (hashtable[i].UserName == username)
                                    {
                                        student = (student)hashtable[i];
                                        
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (hashtable[index].UserName == username)
                        {
                            student = (student)hashtable[index];
                           
                            break;
                        }
                    }
                    break;

                default:
                    throw new NotImplementedException("String option must be 1 or 2");


            }
            return student;
        }

        public void RemoveOpenAddressing(string username, string option)
        {
            int index = HashFunctions.HashFunctionOne(username, _capacity);
            switch (option)
            {
                //normal open addressing
                case "1":

                    for (int i = index; i < _capacity + 1; i++)
                    {

                        //Denna kod körs bara om det blir två på sista indexet
                        if (i >= _capacity)
                        {
                            for (int a = 0; a < hashtable.Length; a++)
                            {
                                if (hashtable[a].UserName == username)
                                {

                                    hashtable[a] = null;
                                    Console.WriteLine($"Removed user: {username}");
                                    _count--;
                                    break;
                                }
                            }
                            break;
                        }

                        if (hashtable[i] == null)
                        {
                            Console.WriteLine("null");
                        }
                        else if (hashtable[i].UserName == username)
                        {
                            hashtable[i] = null;
                            Console.WriteLine($"Removed user: {username}");
                            _count--;
                            break;
                        }
                    }
                    break;


                //quadratic open addressing
                case "2":
                    int j = 0;
                    while (true)
                    {
                        if (hashtable[index].UserName != username)
                        {
                            j++;
                            index = (int)Math.Pow(j, 2);
                            if (index > _capacity)
                            {
                                for (int i = 0; i < _capacity; i++)
                                {
                                    if (hashtable[i].UserName == username)
                                    {
                                        hashtable[i] = null;
                                        Console.WriteLine($"Removed user: {username}");
                                        _count--;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        if (hashtable[index].UserName == username)
                        {
                            hashtable[index] = null;
                            Console.WriteLine($"Removed user: {username}");
                            _count--;
                            break;
                        }
                    }
                    break;


            }
        }


        private void ResizeTable()
        {
            int newCapacity2 = hashtable.Length * 2;

            student[] newHashTable2 = new student[newCapacity2];

            _capacity = newCapacity2;

            foreach (student stud in hashtable)
            {
                if (stud != null)
                {
                    int htable2index = HashFunctions.HashFunctionOne(stud.UserName, _capacity);

                    while (newHashTable2[htable2index] != null)
                    {
                        htable2index = (htable2index + 1) % newCapacity2;
                    }

                    newHashTable2[htable2index] = stud;

                }
            }
            hashtable = newHashTable2;
        }

        public void DisplayTable()
        {
            
            for (int i = 0; i < _capacity; i++)
            {
                if (hashtable[i] != null)
                {
                    Console.WriteLine($"Index {i}:" + hashtable[i]);
                }
            }
        }

    }
}
