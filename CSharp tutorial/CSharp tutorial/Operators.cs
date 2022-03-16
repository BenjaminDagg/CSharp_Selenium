using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Types of operators
 * 1. arithmetic
 * 2. relational
 * 3. logical
 * 4. bitwise
 * 5. assignmment
 * 6. misc
 * 
 * 
 * =========== Operator Overloading ============
 * - you can overlaps most built in operators in c# allows the use of operaotrs with user defined types
 */
namespace CSharp_tutorial
{
    class IBox
    {
        public int length;
        public int width;
        public int height;

        public IBox()
        {
            length = 0;
            width = 0;
            height = 0;
        }

        public IBox(int l, int w, int h)
        {
            this.length = l;
            this.width = w;
            this.height = h;
        }

        public int volume()
        {
            return length * width * height;
        }

        public static IBox operator+ (IBox x, IBox y)
        {
            IBox a = new IBox();
            a.length = x.length + y.length;
            a.width = x.width + y.width;
            a.height = x.height + y.height;

            return a;
        }

        public override string ToString()
        {
            return String.Format("Length: {0}, Width: {1}, Height:{2}, Volume: {3}",length,width,height, volume());
        }
    }

    class Operators
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======== Operators ============");
            int a = 10, b = 20;

            // + addition
            Console.WriteLine(a + " + " + b + " = {0}", a + b);
            // - subtraction
            Console.WriteLine(a + " - " + b + " = {0}", a - b);
            // * multiply
            Console.WriteLine(a + " X " + b + " = {0}", a * b);
            // + addition
            Console.WriteLine(b + " % " + a + " = {0}", b % a);
            //increment
            a++;
            Console.WriteLine("a++ = " + a);
            //decrement
            b--;
            Console.WriteLine("b-- = " + b);

            bool c = true, d = false;
            //&& (and) is true if both conditions are true
            Console.WriteLine("C && D = {0}" , c && d);
            // || (or) is true if either value is true
            Console.WriteLine("C || D = {0}", c || d);
            // ! (not) reverses the llgical state of the operand
            Console.WriteLine("!C = {0}, !D = {1}", !c, !d);

            //bitwise operators
            //  & binary AND 
            // | binary OR
            // ^ binary XOR
            // ~ ones compliment
            // << left shift (moved left by specific # of bits)
            // >> left shift (moved right by specific # of bits)

            //assignment operators
            int x = 10, y = 20, z = 30;
            // += adds right value to left then assigns left the value
            x += y;
            Console.WriteLine("x += y = " + x);

            x = 10;
            // -= subtracts right value to left then assigns left the value
            x -= y;
            Console.WriteLine("x -= y = " + x);

            x = 10;
            // *= multiply right value to left then assigns left the value
            x *= y;
            Console.WriteLine("x *= y = " + x);

            x = 10;
            // /= device right value to left then assigns left the value
            y /= 10;
            Console.WriteLine("y /= x = " + y);

            // & returns address of a variable
            //Console.WriteLine("Address of x: {0}", &x);

            // ? ternery operator
            int h = x > 10 ? 1 : 0;
            Console.WriteLine("h = " + h);

            // as cast without raising anexceptin if fails
            Object obj = new StringReader("Hello");
            StringReader r = obj as StringReader;
            Console.WriteLine("========= Overloading operators ==========");
            IBox b1 = new IBox(5,5,5);
            Console.WriteLine(b1.ToString());
            IBox b2 = new IBox(10, 10, 10);
            Console.WriteLine("b2 volume = " + b2.volume());
            IBox b3 = b1 + b2;
            Console.WriteLine("b3 volume = " + b3.volume());
        }
    }
}
