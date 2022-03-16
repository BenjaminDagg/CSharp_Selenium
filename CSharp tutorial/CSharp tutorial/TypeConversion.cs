using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 1. Type conversion is conversion from one data type to another 
 * 2. Also called type casting
 * 3. 2 forms of type conversion: Implicit and Explicit
 * Implicit: performed by C# in type safe manner (no data is lost)
 * Explicit: done by user using cast operator (also called casting)
 * -casting is done when data might be lost during the conversion or conversion may fail
 * -example of explicit conversion: converting to type with less precision or base class to derived class
 * 
 */


namespace CSharp_tutorial
{
    /*
     * implicit conversin can be done when value to be stores can
     * fit into the source variable without being cut off
     * -range of source is a subset of the range of the target data type
     */
    class ImplicitConversion
    {
        public void convertImplicit()
        {
            int num = 2147483647;
            Console.WriteLine(num);
            long bigNum = num;
            Console.WriteLine(bigNum);
        }
    }

    /*
     * Explicit conversion (cast) is required when a conversion cannot
     * be made without risk of losing data
     * To cast put the data type that you are converting to in parenthesis\
     * in front of the variable being converted
     * 
     * Reference types:
     * Do not need cast if converting from derives to base this is implicit because
     * derived class contains all members of base
     * DO NEED to cast when converting from base to dervied
     * Casting a reference object doesnt change type of object itself, it changes the tyoe
     * of the value that is referencing the object
     */
    class ExplicitConversion
    {
        public void cast()
        {
            double d = 123.45;
            Console.WriteLine("d before = {0}",d);
            int i = (int)d;
            Console.WriteLine("d after = {0}", i);

            int num = 100;
            double d2 = (double)num;
            Console.WriteLine("d2 after = {0}", d2);

            int n = 1;
            string b = n.ToString();
            Console.WriteLine("int->string = {0}", b);

            long l = long.MaxValue;
            int smallL = (int)l;
            Console.WriteLine("long->int = {0}", smallL);

            double d3 = 12345.678943434343;
            float f = (float)d3;
            Console.WriteLine("double->float = {0}", f);

        }

        public void reference()
        {
            //explicit cast not required when converting dervied->base
            Derived d = new Derived();
            Derived a = d;

            Base b = (Base)d; 
            Console.WriteLine(b.baseNum);

        }
    }

    class Base
    {
        public int baseNum = 1;

        virtual public void setNum(int n)
        {
            this.baseNum = n;
        }
    }

    class Derived : Base
    {
        public int derivedNum = 2;
        public override void setNum(int n)
        {
            this.derivedNum = n;
        }
    }
   

    class TypeConversion
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type conversion:");
            ExplicitConversion ec = new ExplicitConversion();
            ec.reference();

            ImplicitConversion ic = new ImplicitConversion();
            //ic.convertImplicit();
            
        }
    }

    
}
