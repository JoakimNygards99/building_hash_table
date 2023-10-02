using HashTable.HashmapDifferentDatastructures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {



            student a = new student("h21jonyg", "Joakim", 0725291385, "j.nygards99@gmail.com", "IT");
            student b = new student("h21ponag", "Pontus", 0725291385, "p.agren12546@outlook.com", "IT");
            student c = new student("h21anlus", "AnnaMaria", 0725291385, "a.m2499@gmail.com", "IT");
            student d = new student("h21fredr", "Fredrik", 0725291385, "fredde1239@gmail.com", "Kung");


            //linked list
            HashMapLinkedList hmaplinkedlist = new HashMapLinkedList();

            hmaplinkedlist.Add(a.UserName, a);
            hmaplinkedlist.Add(b.UserName, b);
            hmaplinkedlist.Add(c.UserName, c);

            hmaplinkedlist.DisplayTable();

            Console.WriteLine();

            Console.WriteLine(hmaplinkedlist.Get(b.UserName));

            Console.WriteLine("Current capacity: " + hmaplinkedlist.ReturnCapacity());
            hmaplinkedlist.Add(d.UserName, d);
            Console.WriteLine("Current capacity: " + hmaplinkedlist.ReturnCapacity());

            hmaplinkedlist.Remove(b.UserName);

            Console.WriteLine();

            hmaplinkedlist.DisplayTable();

            Console.ReadLine();


            Console.Clear();
            //hashmap list
            HashMapList hmaplist = new HashMapList();

            hmaplist.Add(a.UserName, a);
            hmaplist.Add(b.UserName, b);
            hmaplist.Add(c.UserName, c);

            hmaplist.DisplayTable();

            Console.WriteLine();

            Console.WriteLine(hmaplist.Get(b.UserName));

            Console.WriteLine("Current capacity: " + hmaplist.ReturnCapacity());
            Console.WriteLine($"Added one item {d.UserName}");
            hmaplist.Add(d.UserName, d);
            Console.WriteLine("Current capacity: " + hmaplist.ReturnCapacity());

            hmaplist.Remove(b.UserName);

            Console.WriteLine();

            hmaplist.DisplayTable();

            Console.ReadLine();



            Console.Clear();

            //hashmap array
          
            HashMapArray hmaparray = new HashMapArray();

            hmaparray.Add(a.UserName, a);
            hmaparray.Add(b.UserName, b);
            hmaparray.Add(c.UserName, c);

            hmaparray.DisplayTable();

            Console.WriteLine();

            Console.WriteLine(hmaparray.Get(b.UserName));

            Console.WriteLine();

            Console.WriteLine("Current capacity: " + hmaparray.ReturnCapacity());
            hmaparray.Add(d.UserName, d);
            Console.WriteLine("Current capacity: " + hmaparray.ReturnCapacity());

            hmaparray.Remove(b.UserName);

            hmaparray.DisplayTable();

            Console.ReadKey();


            Console.Clear();

            //Hashmap open addressing normal
            Console.WriteLine("Linear probing");
            HashMapArrayOpenAdressing hmapopenaddr = new HashMapArrayOpenAdressing();

            hmapopenaddr.AddOpenAddressing(a.UserName, a, "1");
            hmapopenaddr.AddOpenAddressing(b.UserName, b, "1");
            hmapopenaddr.AddOpenAddressing(c.UserName, c, "1");

            Console.WriteLine();

            hmapopenaddr.DisplayTable();

            Console.WriteLine();

            Console.WriteLine(hmapopenaddr.GetOpenAddressing(b.UserName, "1"));

            Console.WriteLine();

            hmapopenaddr.RemoveOpenAddressing(b.UserName, "1");

            hmapopenaddr.DisplayTable();

            Console.ReadKey();

            Console.Clear();

            //Hashmap open addressing quadratic
            Console.WriteLine("quadratic probing");
            HashMapArrayOpenAdressing hmapopenaddrquad = new HashMapArrayOpenAdressing();

            hmapopenaddrquad.AddOpenAddressing(a.UserName, a, "2");
            hmapopenaddrquad.AddOpenAddressing(b.UserName, b, "2");
            hmapopenaddrquad.AddOpenAddressing(c.UserName, c, "2");

            Console.WriteLine();

            hmapopenaddrquad.DisplayTable();

            Console.WriteLine();

            Console.WriteLine(hmapopenaddrquad.GetOpenAddressing(b.UserName, "2"));

            Console.WriteLine();

            hmapopenaddrquad.RemoveOpenAddressing(b.UserName, "2");

            hmapopenaddrquad.DisplayTable();

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"Testar att lägga till {a.Name} som redan finns i våran hashmaplinkedlist");
            hmaplinkedlist.Add(a.UserName, a);

        }
    }
}