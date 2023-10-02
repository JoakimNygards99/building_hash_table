using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable.HashmapDifferentDatastructures
{
    public class HashMapList : AddGetRemove
    {
        //capacity är hur stor hashtabellen ska vara
        private int _capacity = 5;

        //skapar hashtabellen som kommer innehålla cars
        private List<KeyValuePair<string, object>>[] hashtable;

        //Använder en load factor vilket är 70%, om arrayen är fylld till 70% så måste vi rezisa den
        private const float LoadFactorThreshold = 0.7f;

        //count räknar hur många studenter som ligger i våran hashtabell
        private int _count = 0;

        public HashMapList()
        {
            hashtable = new List<KeyValuePair<string, object>>[_capacity];
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
            int index = HashFunctions.HashFunctionThree(Username, _capacity);
            //start inex blir det index som vi får
            int startIndex = index;

            //Om platsen är tagen, alltså isOccupied
            //while (hashtable[index] != null)
            //{

            if (hashtable[index] == null)
            {
                hashtable[index] = new List<KeyValuePair<string, object>>();
            }

            foreach (KeyValuePair<string, object> item in hashtable[index])
            {
                if (item.Key == Username)
                {
                    throw new Exception($"Key '{Username}' already exists in the hashtable");
                }
            }
            /*
            //check if key.Username all ready exists, not allow with duplicate keys
            if (hashtable[index] != null && Username.Equals(hashtable[index].UserName))
            {
                throw new Exception($"Key '{Username}' already exists in the hashtable");
            }

            //går till nästa index positione
            index = (index + 1) % _capacity;

            //Kollar om hashtable är full
            if (index == startIndex)
            {
                throw new Exception("Hashtable is full. cannot add car");
            }
            */

            //}
            //lägger till bilen
            //hashtable[index] = (student)Convert.ChangeType(value, typeof(student));
            //bockar att indexet är upptagen
            //ökar count eftersom vi har fått en till student
            //_count++;

            hashtable[index].Add(new KeyValuePair<string, object>(Username, value));
            _count++;

        }
        public object Get(string Username)
        {
            int index = HashFunctions.HashFunctionThree(Username, _capacity);//calculate the index for the reg number
            int startIndex = index;//store the starting index for linear probing

            //linear probing to find the car object
            //loppar igenom hela hashtabellen för att hitta rätt regnr, börjar på det hashade indexet
            //om vi inte hittar det på första försöket då gåt vi till nästa slot
            /* while (hashtable[index] != null)
             {
                 if (hashtable[index] != null && Username.Equals(hashtable[index].UserName))
                 {
                     return hashtable[index];//found the car object
                 }

                 index = (index + 1) % _capacity;//move to next slot

                 //Denna körs om vi har loopat igenom hela listan
                 if (index == startIndex)
                 {
                     //if we have looped through the entire table and did not find the car
                     //then the car is not in the hashtable
                     return null;
                 }

             }
             return null; //car not found
            */
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
            int index = HashFunctions.HashFunctionThree(key, _capacity);//calculate the index for the reg number
            int startIndex = index;//store the starting index for linear probing

            //linear probing to find the car object
            //loppar igenom hela hashtabellen för att hitta rätt regnr, börjar på det hashade indexet
            //om vi inte hittar det på första försöket då gåt vi till nästa slot
            /*while (hashtable[index] != null)
            {
                if (hashtable[index] != null && key.Equals(hashtable[index].UserName))
                {
                    hashtable[index] = null;//found the car object
                }

                index = (index + 1) % _capacity;//move to next slot

                //Denna körs om vi har loopat igenom hela listan
                if (index == startIndex)
                {
                    //if we have looped through the entire table and did not find the car
                    //then the car is not in the hashtable
                    break;
                }

            }*/
            foreach (KeyValuePair<string, object> item in hashtable[index])
            {
                if (item.Key == key)
                {
                    hashtable[index].Remove(item);
                }
            }
        }
        private void ResizeTable()
        {
            int newCapacity = hashtable.Length * 2;

            List<KeyValuePair<string, object>>[] newHashTable = new List<KeyValuePair<string, object>>[newCapacity];

            int _oldcapacity = _capacity;

            _capacity = newCapacity;

            for(int i = 0; i < _oldcapacity; i++)
            {
                if (hashtable[i] != null)
                {
                    int index = HashFunctions.HashFunctionThree(hashtable[i][0].Key, _capacity);

                    while (newHashTable[index] != null)
                    {
                        index = (index + 1) % newCapacity;
                    }

                    newHashTable[index] = hashtable[i];

                }
            }

            /*foreach (List<KeyValuePair<string, object>> stud in hashtable)
            {
                if (stud != null)
                {
                    int index = HashFunctions.HashFunctionThree(stud.Find().Key, _capacity);

                    while (newHashTable[index] != null)
                    {
                        index = (index + 1) % newCapacity;
                    }

                    newHashTable[index] = stud;

                }
            }*/
            hashtable = newHashTable;
        }
    }
}

