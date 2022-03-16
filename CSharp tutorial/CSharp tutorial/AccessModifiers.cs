using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Access modifers set access level/visibility of classes,fields and methods
 * - Public: visible to all classes
 * - Private: only visible within the same class
 * - protected: accessible within same class or an inherited class
 * - internal: Visible within the same assembly but not in another assembly
 */
namespace CSharp_tutorial
{
    /*
     * Private only accessible withing same class
     */
    class Car
    {
        private string name = "Ford";
        public int year = 2022;
    }

    class AccessModifiers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======= Access Modifiers ==========");

            //trying to access private field gives error
            Car Ford = new Car();
            //Console.WriteLine("Name = " Ford.name); error
            //public modifer can  be accessed from any class
            Console.WriteLine("Ford year = " + Ford.year);
        }
    }
}
