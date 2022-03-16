//#define TEST

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/*
 * Atribute = delcarative tag to convery info at runtime about behavior of class, method, struct enum etc
 * - adds declarative info using tag depicted by square brackets []
 * - used to add metadate such as comments, description, methods, classes
 * - 2 types: pre-defines and custom build
 * - format: [attribute(positionalParameter, name_parameter = value)]
 * - positional parameter = essential information
 * - name parameter specify optional information
 * =========== Predefined attributes ===========
 * - 3 types: AttributeUsage, Conditional, Obsolete
 * 1) AttributeUsage descrbes how a custom attribute class can be used and specifies type of items the attribute can be applied to
 * [AttributeUsage (validon, AllowMultiple = allowmultiple, Inherited = inherited)]
 * - validon = elements the attribute can be placed
 * - allowmultiple = a bool value if attribute is multiuse or single use
 * - inherited = bool value if attribute in inherited by derived class or not
 * 2) Conditional
 * - marks a method whos execution depends on preprocessor identifier
 * - conditional compilation of method call dpending on specified preprocessor value such as Debug
 * - displays values of variables in debug mode
 * - [Conditional (conditionalSymbol)] 
 * - Example: [Conditional("DEBUG")] - only executes class/functino if debug is defined
 * 3) Obsolete
 * - marks an entity that should not be used
 * - informs compiler to discard a target element
 * - Example a new method is defined and you want to retain the old one you can mark it as obsolete
 * - [Obsolete (message, iserror)] - message describes reason the item is absolete and error makes compiler treat it as error if item is used
 * ======== Custom Attributes =============
 * - lets you define custom attributes that can be used to store declarative info and be retrieved at run time
 * - 4 steps:
 * 1) declare attribute
 * 2) construct attribute
 * 3) Apply attribute to an element
 * 4) Access attribute through reflection - create program to read through meradata
 * 1) Declaring attribute - attribute is derived from System.Attribute
 * 2) - constructing attribute - must have at least one constructor. Positional parameters are passed through constructor
 */
namespace CSharp_tutorial
{

    //declaring attribute
    [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Constructor |
        AttributeTargets.Method |
        AttributeTargets.Property |
        AttributeTargets.Field,
        AllowMultiple = true)]
    public class DebugInfo : System.Attribute
    {
        private int bugNo;          //positional parameter
        private string developer;   //positional parameter
        private string lastReview;  //positional parameter
        public string message;      //optional parameter

        public DebugInfo(int bg, string dev, string d)
        {
            this.bugNo = bg;
            this.developer = dev;
            this.lastReview = d;
        }

        public int BugNo
        {
            get { return bugNo; }
        }

        public string Developer
        {
            get { return developer; }
        }

        public string LastReview
        {
            get { return lastReview; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }

    [DebugInfo(1,"Ben Dadd", "2/24/2022", Message = "Return type mismatch")]
    class MRectangle
    {
        protected double length;
        protected double width;

        public MRectangle(double l, double w)
        {
            length = l;
            width = w;
        }

        [DebugInfo(2, "Ben Dadd", "2/24/2022", Message = "Return type mismatch")]
        public double area()
        {
            return length * width;
        }

        [DebugInfo(3, "Ben Dadd", "2/24/2022", Message = "parameter mismatch")]
        public void display()
        {
            Console.WriteLine("Length: {0], Width: {1}, Area: {2}",length,width, area());
        }
    }
    
    class MyClass
    {
        //only executes if test is defined
        [Conditional("TEST")]
        public static void Message(string m)
        {
            Console.WriteLine(m);
        }

        [Obsolete ("Dont use old method use new", true)]

        public static void oldMethod()
        {
            Console.WriteLine("Old method");
        }
        public static void newMethod()
        {
            Console.WriteLine("New method");
        }
    }

    class AttributeExample
    {

        
        static void func1()
        {
            Console.WriteLine("In func 1");
            func2();
        }
        [Conditional("TEST")]
        static void func2()
        {
            Console.WriteLine("In func 2");
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Attributes: ");
            MyClass.Message("in main");
            func1();

            //MyClass.oldMethod();      //creates error at compile time because oldMethod is obsolete
            MyClass.newMethod();

            MRectangle r = new MRectangle(5, 5);
            r.area();
        }
    }
}
