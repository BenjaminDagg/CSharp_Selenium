using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * ======================== MICROSOFT DOCS =================================
 * - class is reference type
 * - variable contains value null until create an instance of the class with new operator or assign it to an existing object created elsewhere
 * - when object is created the variable holds only a reference to the location of the object in memory
 * - fields, properties, methods, events of a class are called members
 * ========== Creating objects ==============
 * - object and class are different things
 * - class defines type of object but is not an object itseld
 * - and object is an entity based on a class (sometimes called an instance of a class)
 * - object is created with new operator followed by name of class
 * - when instance of a class is created the variable contains a reference to the object that is based on the class it was created from
 * - creating a variable creates reference object that doesnt refer to an object until the new operator is used or its assigned to an existing object
 * -(Example: Customer c1; this doesn't refer to an object yet)
 */
namespace CSharp_tutorial
{
    public class Customer
    {
        public string name;
    }

    class MCSFTClassExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ Class Example ==============");
            //declaring object of type Customer - 
            Customer myCustomer = new Customer();
            //declaring new object and assigning it the value of the first object
            Customer myCustomer2 = myCustomer;

            //create object reference (doesnt refer to an actual object yet)
            Customer myCustomer3;
            //now assign it to an object reference
            myCustomer3 = new Customer();

            //if 2 object references refer to the same object changes made to 1 reference are reflected in the other
            Customer myCustomer4 = new Customer();
            myCustomer4.name = "Ben";
            Customer myCustomer5 = myCustomer4;
            myCustomer5.name = "Joe";
            Console.WriteLine("Customer 4 name = " + myCustomer4.name); // outputs "joe"
        }
    }
}
