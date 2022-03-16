using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * one interface many functions
 * - polymorphism can be static or dynamic
 * - static = response to function is determined at compile time
 * - dynamic = response to function is decided at run time
 * ======== static ========
 * -early binding - linking a function with an object during compile time (aka static binding)
 * - 2 techniques to implement static polymorphism: function overloading, operator overloading
 * -function overloading = same function name with multiple definitions
 * - functions must differ from each other by tyoe or # of arguments
 * - can overload function by return type
 * ========= dynamic polymorphism ============
 * - abstract clases provide partial class implememntation
 * - abstract methods are implemented by a derived class
 * - you cannot create an instance of an abstract class
 * - you cant declare an abstract method outside of an abstract class
 * - a sealed class cannot be derived from
 * ======= virtual ==========
 * - virtual method defined in base class can be overriden in the inherrited class 
 * - inherited class provides different implementation than base
 */
namespace CSharp_tutorial
{
    //function overloading - same function name with different arguments
    class PrintData
    {
        public void print(int i)
        {
            Console.WriteLine("printing integer {0} ",i);
        }

        public void print(double d)
        {
            Console.WriteLine("printing double {0} ", d);
        }

        public void print(string s)
        {
            Console.WriteLine("printing string {0} ", s);
        }

        public void print(int i , int j)
        {
            Console.WriteLine("printing integers {0}, {1} ", i,j);
        }

       


    }

    //abstract class
    public abstract class ShapeA
    {
        protected int length;
        protected int width;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public ShapeA(int l, int w)
        {
            length = l;
            width = w;
        }

        //abstract method
        public abstract int area();

        //base method to be overriden
        //calculates perimeter of rectangle
        public virtual int permimeter()
        {
            return (length * 2) + (width * 2);
        }
    }
    class RectangleA : ShapeA
    {
       
        public RectangleA(int l, int w) : base(l,w)
        {

        }

        //override abstract method
        public override int area()
        {
            return length * width;
        }

        //overide permiter
        public override int permimeter()
        {
            return (length * 2) + (width * 2);
        }
    }

    class CircleA : ShapeA
    {
        public CircleA(int r) : base(0,0)
        {
            radius = r;
        }

        private int radius;
        public int Radius
        {
            get { return radius;}
            set { radius = value; }
        }

        public override int area()
        {
            return (int)3.14 * radius * radius;
        }

        public override int permimeter()
        {
            return (int)3.14 * 2 * radius;
        }
    }

    class TriangleA : ShapeA
    {
        public TriangleA(int l, int w) : base(l, w)
        {

        }

        public override int area()
        {
            return (length * width) / 2;
        }

        public override int permimeter()
        {
            return length * 3;
        }
    }

    class Polymorphism
    {
        static void area(ShapeA[] s)
        {
            foreach (ShapeA shape in s)
            {
                Console.WriteLine("Area of {0} = {1}", shape.ToString(), shape.area());
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("========= Polymorphism ===========");
            PrintData pd = new PrintData();
            pd.print(5);
            pd.print(5.5);
            pd.print("hello");
            pd.print(5, 10);

            //ShapeA s = new ShapeA(); error cannot instantiate abstract class
            RectangleA r = new RectangleA(5,10);
            r.Length = 5;
            r.Width = 10;
            Console.WriteLine("Area: " + r.area());

            ShapeA[] shapes = { new RectangleA(5, 10), new CircleA(5), new TriangleA(1,2) };
            area(shapes);
        }
    }
}
