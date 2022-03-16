using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * ========= Classes ===========
 * - define blueprint of a data type
 * - defines what an object of the class consists of and what actions can be perfomed
 * - object = an instance of a class
 * - members = variables and methods of a class
 * - access specifier determine rules for accessing memebers and class itself (default class specifier is internal and defaul member specifier is private)
 * - use dot (.) operator on a object to access its members (dot links an name of object with its members)
 * ======== Encapsulation ========
 * - member function is a method that has its prototype defines withing class definition
 * - member function operates on an object of the class which it is a member of
 * - member funbction has access to all members of a class object
 * - member variables are kept private to implement encapsulation
 * - member variables can  only be accessed through member methods
 * ======== Constructors ==========
 * - constructor = special member method that is called when a new object of the class is created
 * - used to assign initial values to members at time of creation
 * - constructor method has same name as class and does not return a value
 * - default constructor doesnt have any parameters
 * - parameterized contrstructor has parameters
 * ======== Destructors ==========
 * - special member function that is executed when object of its class goes out of scope
 * - destructor methos has same name as class name with ~ in front
 * - cant return a value or take parameters
 * - used to release memory 
 * ======== Static Members ==========
 * - belongs to the class and not an object of the class
 * - static members can be used by invoking the class without having an instance of the class
 * - no matter how many objects of the class are created there is only 1 copy of its static member
 * - static methods can only acess static variables
 * -static methods exist before an object of the class is created
 * 
 * ======================== MICROSOFT DOCS =================================
 * - class is reference type
 * - variable contains value null until create an instance of the class with new operator or assign it to an existing object created elsewhere
 */
namespace CSharp_tutorial
{
    class Box
    {
        //member variables
        private double length;
        private double width;
        private double height;
        public static int numSides = 6;

        //default constructor
        public Box()
        {
            Console.WriteLine("Box is being created");
            this.length = 0;
            this.width = 0;
            this.height = 0;
        }

        //parameterized constructor
        public Box(double l, double w, double h)
        {
            Console.WriteLine("Box is being created with parameters");
            this.length = l;
            this.width = w;
            this.height = h;
        }

        //destructor
        ~Box()
        {
            Console.WriteLine("Object is being deleted");
        }

        //member methods
        public void setLength(double l)
        {
            this.length = l;
        }

        public void setWidth(double w)
        {
            this.width = w;
        }

        public void setHeight(double h)
        {
            this.height = h;
        }

        public double getVolume()
        {
            return length * width * height;
        }

        //static method
        public static double getSides()
        {
            return numSides;
        }
    }

    class ClassesExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======== Classes Example ============");

            //create object of class Box
            Box box1 = new Box();
            double volume;

            box1.setLength(10.0);
            box1.setWidth(10.0);
            box1.setHeight(10.0);

            volume = box1.getVolume();
            Console.WriteLine("Volume of box1 = " + volume);

            //creating box object with parameterized constructor
            Box box2 = new Box(11.0,11.0,11.0);
            double volume2 = box2.getVolume();
            Console.WriteLine("Volume of box2 = " + volume2);

            //calling static member without creating an instance of Box
            var sides = Box.numSides;
            Console.WriteLine("A box has {0} sides", sides);
            //invoking static method
            Console.WriteLine("A box has {0} sides", Box.getSides());
        }
    }
}
