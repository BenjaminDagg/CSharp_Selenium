using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Nullables can assign a normal range of values or null value
 * syntax <data_type> ? <variable_name> = null or  <data_type> ? <variable_name> = new <data_type>?()
 */
namespace CSharp_tutorial
{
    class NullableExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======= Nullables ===========");
            int? num1 = null;
            double? num2 = null;
            bool? bool1 = new bool?();
            Console.WriteLine("Null int = " + num1);

            /* Null Coalescing operator - if you want to assign a nullable to non nullable type
             * - converts nullkable to value of another nullable 
             * - if value in left operand is null it returns the value of the second operand otherwise it returns the value
             * of the first operand
             * 
             */
            int? x = null;
            int? y = 1;
            int z;

            z = x ?? 2;
            Console.WriteLine("z = " + z);

            //you can assigns a nullable to a variable of its non nullable type but not the other way arround
            int a = 1;
            int? b = a;
            int? c = null;
            //int d = c; error

            //checking value of nullable
            int? e = null;
            int? f = null;
            if (e.HasValue) 
            {
                Console.WriteLine("E is not null e = " + e);
            }
            else
            {
                Console.WriteLine("E is null");
            }
            
            //or compare value of nullable to null
            if (f != null)
            {
                Console.WriteLine("F is not null f = " + f);
            }
            else
            {
                Console.WriteLine("f is null");
            }

            //coalescing operator assigns nullable to non nullable
            int? g = null;
            int? h = 1;
            int i = g ?? 2;
            Console.WriteLine("i = " + i);
            int j = h ?? 3;
            Console.WriteLine("j = " + j);

            //operators on nullable can be done. Return null is one or both of the operands are null
            int? k = 1;
            int? l = null;
            int m = 2;
            int? n = k + l;
            Console.WriteLine("n = " + n);
            int? o = k * m;
            Console.WriteLine("o = " + o);

            //comparison operators return false if at least one is null. Else it compares the operators
            int? p = null;
            int? q = 1;
            int? r = 2;
            if (p < q) Console.WriteLine("p < q");
            else Console.WriteLine("p < q false");
            if (q < r) Console.WriteLine("q < r");
            else Console.WriteLine("false q < r");

            //unboxing to a nullable type
            int s = 42;
            object obj = s;
            int? t = (int?)obj;
            Console.WriteLine("t = " + t);
            //boxing a nullable
            object obj2 = t;
            if (obj2 != null) Console.WriteLine("Obj2 = " + obj2);
            else Console.WriteLine("obh is null");
        }
    }
}
