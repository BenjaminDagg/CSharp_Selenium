using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

/*
 * ========== Array List ============
 * - ordered colection of objects that can be indexed 
 * - an array you can add or reove items from the list at specific index and resizes itself automatically
 * - allows dynamic memory allocation, searching, sorting
 * - capacity - sets number of elements the array can contain
 * - count - gets # of elements in array
 * - Item - gets/sets elementat the specified index
 * 
 * ============ Hash table ==========
 * - hashtable is a collection of key-value pairs
 * - each item in the hash table has a key-value pair
 * - the key is used to access items in the collection
 * - Item: gets value associated with given key
 * - Keys - gets ICollection containing the keys in the hashtable
 * - Values: gets ICollection containing the values in the hashable
 * - ContainsKey(object key): determines if hashtable has key
 * - ContainsValue(object value): determines if hashtable has the value
 * - Add(object key, object value)
 * - Remove(object key)
 * 
 * ========== SortedList ==========
 * - combination of array and hash table
 * - list of items that can be accessed by key or index
 * - if access by index its an ArrayList, if access by key its a hashtable
 * - collection os always sorted by key value
 * 
 * ======== stack =========
 * - last in, first out collection
 * - push = add item to list
 * - pop = remove item from list
 * - peek() gets value at top of stack without removing it
 * - pop() returns and removed item at top of stack
 * - push() adds item to top of stack
 * 
 * ======== queue ==========
 * - first in first out collection
 * - enqueue = add item
 * - deque = remove item
 * 
 * ======== Bit Array ========
 * - manages array of bit values represented as booleans where true indicated 1 and falsse indicates 0
 */
namespace CSharp_tutorial
{
    class CollectionsExamples
    {
        public static Stack reverseStack(Stack s)
        {
            Stack temp = new Stack();
            int top;
            int size = s.Count;
            for(int i = 0; i < size;i++)
            {
                top = (int)s.Peek();
                temp.Push(top);
                s.Pop();
            }
            return temp;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Collections: ");
            Random rand = new Random();
            ArrayList al = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                int r = rand.Next(10);
                al.Add(r);
            }
            Console.WriteLine("Al capacity: {0}, Al count: {1}", al.Capacity, al.Count);
            int alIndex = 0;
            foreach(int i in al)
            {
                Console.WriteLine("al[{0}] = {1}", alIndex, i);
                alIndex++;
            }
            al.Add(100);
            al.Sort();
            for(int i = 0; i < al.Count; i++)
            {
                Console.WriteLine("sorted al[{0}] = {1}",i,al[i]);
            }
            al.RemoveAt(3);
            al.Add("hello");
            for (int i = 0; i < al.Count; i++)
            {
                Console.WriteLine("sorted al[{0}] = {1}", i, al[i]);
            }

            Console.WriteLine("======== Hashtable ===========");
            Hashtable ht = new Hashtable();
            ht.Add("Ben", 26);
            ht.Add("kathy", 55);
            ht.Add("joe", 13);
            ht.Add("Bill", 60);
            ht.Add("Tim", 64);

            if (ht.ContainsKey("joe"))
            {
                Console.WriteLine("joe is already in the hashtable");
            }
            else
            {
                ht.Add("joe", 13);
            }
            ICollection keys = ht.Keys;
            foreach(string k in keys)
            {
                Console.WriteLine(k + " is {0} years old", ht[k]);
            }
            ht.Remove("joe");
            foreach(string key in ht.Keys)
            {
                Console.WriteLine("ht[{0}] = {1}",key,ht[key]);
            }

            Console.WriteLine("========= SortedList ===========");
            SortedList sl = new SortedList();
            sl.Add("Ben", 26);
            sl.Add("kathy", 55);
            sl.Add("joe", 13);
            sl.Add("Bill", 60);
            sl.Add("Tim", 64);

            int counter = 0;
            foreach(string key in sl.Keys)
            {
                Console.WriteLine(sl.GetKey(counter) + " is {0} years old", sl.GetByIndex(counter));
                counter++;
            }

            Console.WriteLine("======== stack =========");
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine("Current stack: ");
            foreach(int i in stack)
            {
                Console.WriteLine(i);
            }
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine("Current stack: ");
            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("removing " + stack.Peek());
            stack.Pop();
            Console.WriteLine("removing " + stack.Peek());
            stack.Pop();
            Console.WriteLine("removing " + stack.Peek());
            stack.Pop();
            Console.WriteLine("Current stack: ");
            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine("Current stack: ");
            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }
            Stack revStack = reverseStack(stack);
            Console.WriteLine("reverse stack: ");
            foreach (int i in revStack)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("========= bit array =========");
            BitArray b1 = new BitArray(8);
            BitArray b2 = new BitArray(8);

            byte[] a = { 60 };
            byte[] b = { 13 };

            b1 = new BitArray(a);
            b2 = new BitArray(b);

            Console.WriteLine("Bit array b1: 60");
            for(int i = 0; i < b1.Count; i++)
            {
                Console.Write("{0, -6} ", b1[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Bit array b2: 13");
            for (int i = 0; i < b2.Count; i++)
            {
                Console.Write("{0, -6} ", b2[i]);
            }
            Console.WriteLine();
            BitArray b3 = b1.And(b2);
            Console.WriteLine("b1 AND b2");
            for (int i = 0; i < b3.Count; i++)
            {
                Console.Write("{0, -6} ", b3[i]);
            }
            b3 = b1.Or(b2);
            Console.WriteLine();
            
            Console.WriteLine("b1 OR b2");
            for (int i = 0; i < b3.Count; i++)
            {
                Console.Write("{0, -6} ", b3[i]);
            }
        }
    }
}
