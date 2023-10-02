using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public static class HashFunctions
    {

        
        public static int HashFunctionOne(string username, int capacity)
        {
            int hash = 5381;
            foreach (char c in username)
            {
                hash = (hash * 31 + c) % capacity;
            }

            return hash;//our index position
        }

        

        public static int HashFunctionTwo(string s, int capacity)
        {
            long total = 0;
            char[] c;
            c = s.ToCharArray();

            
            for (int k = 0; k <= c.GetUpperBound(0); k++)

                total += 11 * total + (int)c[k];

            total = total % capacity;

            if (total < 0)
                total += capacity;

            return (int)total;
        }


        public static int HashFunctionThree(string s, int capacity)
        {
            int total = 0;
            char[] c;
            c = s.ToCharArray();

            
            for (int k = 0; k <= c.GetUpperBound(0); k++)
                total += (int)c[k];

            return total % capacity;
        }



    }
}
