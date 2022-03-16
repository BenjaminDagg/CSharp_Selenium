using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * ======== Indexers ==========
 * - allows an object to be indexed like an array-you can access instance of class using array indexer operator []
 * - behavior is similar to a property in that you use get and set accessors for defining indexer
 * - properties set/get a specific data member wheras indexers return a particular value from an object instance
 * - indexers are defined using "this" keyword which refers to objects instance
 * - indexers can be overloaded with different types
 */
namespace CSharp_tutorial
{
    class IndexedNames
    {
        private string[] nameList = new string[size];
        static public int size = 10;

        public IndexedNames()
        {
            for(int i = 0; i < size; i++)
            {
                nameList[i] = "unknown";
            }
        }

        //indexer
        public string this[int index]
        {
            get
            {
                string temp;

                if (index < 0 || index > (size - 1))
                {
                    temp = "out of range";
                }
                else
                {
                    temp = nameList[index];
                }

                return temp;
            }
            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    nameList[index] = value;
                }
            }
        }

        //overload indexer with string type to get index of string
        public int this[string name]
        {
            get
            {
                int index = -1;

                for (int i = 0; i < size; i++)
                {
                    if(nameList[i] == name)
                    {
                        index = i;
                        break;
                    }
                }

                return index;
            }
        }

        public int this[string name, int index]
        {
            set
            {
                int i = -1;
                if (index >= 0 && index <= size - 1)
                {
                    nameList[index] = name;
                    i = index;
                }

                
            }
        }
    }

    class IndexerExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indexers: ");
            IndexedNames indexedNames = new IndexedNames();

            //set indexednames
            indexedNames[0] = "ben";
            indexedNames[1] = "jake";
            indexedNames[2] = "kathy";
            indexedNames[3] = "bill";
            indexedNames[4] = "bill";
            indexedNames[5] = "mary";
            indexedNames[6] = "scott";
            indexedNames[7] = "alex";
            indexedNames[8] = "john";
            indexedNames[9] = "becky";

           

            for (int i= 0; i < IndexedNames.size + 10; i++)
            {
                Console.WriteLine(indexedNames[i]);
            }

            //overloaded indexer gets index of string
            Console.WriteLine("index of scott = " + indexedNames["scott"]);
        }
    }
}
