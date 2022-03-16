using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Encapsulation (information hiding) is an objects ability to hide data that is not necessary to the user
 * -restrict access to  members of a class to prevent unintented manipulation
 * - consolodates objects, methods to be considered  single group
 * - internal representation of object is hidden from outside of the object
 * 
 * Abstraction (implementation hiding) - represents essentials features of an object without specifying implementation details
 * 
 * =============================================================================================
 * - encapsulation is done usng access modifiers
 * - access modifies defines scope and visibility of a class member
 * 5 types: public, private, protected, internal, protected internal
 * - DEFAULT ACCESS MODIFIED FOR MEMBER WHICH DOESN'T SPECIFT ONE IS PRIVATE
 * 
 * ================================================================
 * - fields/variabless can achieve encapsulation through setting access modfier to private
 * - use public get and set mothods (properties) to accesss and update private fields
 * -access to a private member from an outside class can be achieved with properties
 * - properties have 2 methods: get and set
 */

namespace CSharp_tutorial
{

    /*
     * Public modifier: can be accessed from outside of the class to other functions and objects
     * - public members can be accessed using an instance of the class
     */

    class PublicRectangle
    {
        public double length;
        public double width;

        public double getArea()
        {
            return length * width;
        }
    }

    /*
     * Private modifier hides the members from other functions and objects
     * - only the same class can access its private members
     * - and instance of a class cannot access its private members
     */
    class PrivateRectangle
    {
        private double length;
        private double width;

        public double getArea()
        {
            return length * width;
        }

        public void setLength(double l)
        {
            length = l;
        }

        public void setWidth(double w)
        {
            width = w;
        }
    }

    /*
     * Protected member is accessible withing its class and by derived classes 
     */
    class Point
    {
        protected int x;
        protected int y;


    }

    class Point3D : Point
    {
        protected int z = 1;

        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;

        }
    }

    /*
     * Internal - Internal members are accessible only withing the same assembly (file)
     * Example: FileA.cs and FileB.cs
     * -if internal class is defined in FileA.cs it cant be instantiated in FileB.cs
     * - only classes and methods in the application which the internal  member is defined can access it
     */
    class InternalRectangle
    {
        internal double length;
        internal double width;
    }


    /*
     * Protected internal member is accessible from any object withing its containing assembly (file) or from
     * a dervied class in another assembly
     * - also cant access protected internal from a base class in another assembly
     */
    public class ProtectedInternalRectangle
    {
        protected internal double length;
    }


    /*
     * Properties are used by outside classes to access a private field
     * - its common to set property to name of the field it modifies but with a capital letter
     */
    class Person
    {
        private string name; //private field
        public int age { get; set; } // shorthand (auto implemented) notation
        private string gender;
       
        public string Name //property
        {
            get { return name; }
            set { name = value; }
        }

        //expression body notation
        public string Gender
        {
            get => gender;
            set => gender = value;
        }

        //properties can also implement logic
        public int DogYears
        {
            get
            {
                return age * 7;
            }

            set
            {
                age = value / 7;
            }
        }

        
        
    }


    class Encapsulation : Point
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====== Encapsulation ==========");

            //public members can be accessed from main using an instance of the class
            PublicRectangle pr = new PublicRectangle();
            //length, width and getArea() members are public
            pr.width = 4.5;
            pr.length = 2;
            Console.WriteLine("Area = {0}", pr.getArea());

            PrivateRectangle privR = new PrivateRectangle();
            //length and width are private so cant access them directly
            privR.setWidth(2);
            privR.setLength(2);
            //privR.width = 5;  error
            Console.WriteLine("Protected rectangle area = {0}", privR.getArea());

            //This class is derived from Point so it can access its protected members
            Encapsulation e = new Encapsulation();
            e.x = 100;
            Console.WriteLine("protected x = " + e.x);
            Point3D p3 = new Point3D();
            p3.setXY(50, 50);

            //this class is in same assembly as InternaalRectangle class so can access
            InternalRectangle ir = new InternalRectangle();
            ir.length = 5;
            ir.width = 5;

            ProtectedInternalRectangle pir = new ProtectedInternalRectangle();
            pir.length = 50;

            //========== Properties ===============
            Person p = new Person();
            p.Name = "Ben"; //set
            Console.WriteLine("name = " + p.Name); //get
            p.age = 26;
           

        }
    }
}
