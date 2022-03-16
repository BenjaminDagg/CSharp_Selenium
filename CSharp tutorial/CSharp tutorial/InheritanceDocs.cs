using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * ====== Inheritance ========
 * -allows you to define a child class that inherits, reuses, extends or modifies bhavior of parent class
 * - base class = class whos members are inherited
 * - derived class = class that inheritcs members of base class
 * - C# supports only single inheritance
 * - constructors are not inherited. Each class must define its own constructors
 * - destructors are not inherited
 * - static constructors are not inherited
 * ======== inherited access modifiers ==============
 * - private members are only visible in derived class if derived class is nested in the base class
 * - protected - visible only to derived classes
 * - internal - visible to derived classes in the same assembly as the base class
 * - public - visible to derived classes and can be called just as if they were defined in derived class
 * ========= Override members ==========
 * - derived class can override the member of a base class by providing alternate implementation
 * - member in base class must be marked as virtual keyword
 * - member in derived class must have override keyword
 * ======== Abstract members ==========
 * - base class member marked with abstract keyword must be overriden by derived class
 * - use override keyword in derived class implementation of abstract member
 * ========== Implicit inheritance ===========
 * - all types in C# implicitly inherit from Object
 * - common functionality of object is available to any type
 * - 8 member methods are automatically inherited from Object
 * 1) ToString converts class object to string representation
 * 2) equality methods: Equals(Object) public, Equals(object, object) static and ReferenceEquals(Object, pbject) the 2 object variables must refer to sam eobject
 * 3) GetHashCode - generates hash value so object can be used in hash collections
 * 4) GetType returns type object 
 * 5) Finalize releases unmanaged resources before object is destroyed by garbage collector
 * =========== IS A Relationship ===========
 * - inheritance describes "IS A" relatinship between bae and derived classes
 * - derived class is a specialized version of the base class or the derived class is a type of the base class
 * - "IS A" can also represent the individual instances (objects) created for a base class (Example Car class with Ford, Chevy objects
 * - its best to use "IS A" inheritance for derived classes that add additional members of add additional functinality
 */
namespace CSharp_tutorial
{
    /*
     * Private modifiers are only visible for nested dervied classes
     */
    public class A
    {
        private int value = 10;
        public int valuePublic = 5;

        public class B : A
        {
            public int getValue()
            {
                return value + 1;
            }
        }

        //overriding method
        public virtual void display()
        {
            Console.WriteLine("Display in base class");
        }

        public int Value
        {
            get { return value; }
            set { value = value; }
        }

       
    }
    //private not visible for derived classes
    class C : A
    {

        //override method
        public override void display()
        {
            Console.WriteLine("Display in derived class");
        }

        /*
        public int getValue()
        {
            return value;              //error
        }
        */
    }
    //public members are visible to derived classes
    class D : A
    {
        public int getValue()
        {
            return valuePublic + 1;
        }
    }

    public abstract class E
    {
        public int num;
        public abstract void display();
    }
    public class F : E
    {
        public override void display()
        {
            Console.WriteLine("Displaying abstract method");
        }
    }

    class InheritanceDocs
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======== InheritanceDocs ==============");

            //overriding method
            A a = new A();
            a.display();
            C c = new C();
            c.display();

            D d = new D();
            d.Value = 1;
        }
    }
}
