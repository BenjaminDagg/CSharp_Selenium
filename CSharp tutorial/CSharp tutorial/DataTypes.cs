using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_tutorial
{
    /* 
     * Value data types can be directly assigned a value
     * Stores int,char,float etcs
     * value types directly contain their data
     * 2 categories of valye types: struct and enum
     * */
    class ValueDataType
    {
        //first type of value type is struct
        public struct Coords
        {
            public int x, y;

        }

        //enum is second value type
        public enum Permission
        {
            Read = 0,
            Write = 1,
            Excecute = 2
        }

        //value data types
        public void display()
        {
            bool myBool = false;
            Console.WriteLine("bool = {0} size={1} bytes", myBool, sizeof(bool));

            // 0 to 255
            byte myByte = 255;
            Console.WriteLine("byte = {0} size={1} bytes", myByte,  sizeof(byte));

            char c = 'f';
            Console.WriteLine("char = {0} size={1} bytes", c, sizeof(char));

            //128 bit precise
            decimal d = 2.5m;
            Console.WriteLine("decimal = {0} size={1} bytes", d, sizeof(decimal));

            //double precision
            double doub = 1D/3;
            Console.WriteLine("double = {0} size={1} bytes", doub, sizeof(double));

            //single precision
            float f = 1F/3;
            Console.WriteLine("float = {0}  size={1} bytes", f, sizeof(float));

            //signed integer 32 bit
            int i = 2147483647;
            Console.WriteLine("int = {0} size={1} bytes", i, sizeof(int));

            //64 bit signed integer
            long l = 9223372036854775807;
            Console.WriteLine("loing = {0} size={1} bytes", l, sizeof(long));

            //singned 8 bit
            sbyte sb = -128;
            Console.WriteLine("sbyte = {0} size={1} bytes", sb, sizeof(sbyte));

            //16 but signed integer
            short sh = 32767;
            Console.WriteLine("short = {0} size={1} bytes", sh, sizeof(short));

            //unsigned int 32 bit
            uint a = 4294967295;
            Console.WriteLine("uint = {0} size={1} bytes", a, sizeof(uint));

            //64 bit unsigned int
            ulong ul = 18446744073709551615;
            Console.WriteLine("ul = {0} size={1} bytes", ul, sizeof(ulong));

            //16 but unsigned int
            ushort us = 65535;
            Console.WriteLine("us = {0} size={1} bytes", us, sizeof(ushort));
        }

        /*
         * 2 categories of valye types: struct and enum
         * built in default data types are structs with their own methods
         */
        public void valueCategories()
        {
            //structs have build in fields and methods
            int i = int.MaxValue;


            
        }

        //you can specify how a numeric value should be types by appending letter to end of number
        public void literals()
        {
            float f = 3.14f;
            Console.WriteLine("float = {0}", f);

            double d = 3.1456d;
            Console.WriteLine("double = " + d);

            decimal i = 3.145652M;
            Console.WriteLine("decimal = " + i);
        }

       
    }

    /*
     * 1. Reference types refer to a memory location not an actual value
     * 2. When reference type object is created the variable which the object is
     * assigned to holds a reference to the memory location of the object
     * 3. If multiple variable are assigned to one object, changes in one
     * variable reflec tin the other
     * 4. variable of reference type is null until assigned an instance of
     * that type of instantiate it with new
     * 5. Reference types: class, record, delegate, array, interface, object
     * */
    class ReferenceTypes
    {

        /*
         * Boxing = converting a value type to object (implicit)
         * Unboxing = extracting a value type from an object (explicit)
         * A value of any type can be treated as an object
         */
        public void boxingExample()
        {
            //boxing
            int i = 123;
            Console.WriteLine("int = {0}", i);
            //object references a value of type int
            object o = i;
            o = 654;
            i = 456;
            //oroginal value type and object use different memory location
            //value and object are on stack - the object references integers value on heap
            Console.WriteLine("Int value = {0}", i);
            Console.WriteLine("Object value = {0}", o);

            /*
             * Unboxing conererts type object to a value type
             * Copys value from instance into value type variable
             */
            int j = (int)o;
            Console.WriteLine("Unboxed = {0}",j);

            //object being unboxed mustbe reference to a value type that was boxed
            object o2 = 1;
            //int k = (short)o2; error InvalidCastException
        }

        public void dynamicType()
        {
            dynamic d = 1;
            Console.WriteLine("dynamic d = {0}", dynamicTest(d));

            //implicit conversion to dynamic
            dynamic s = "hello"; Console.WriteLine("dynamic string = {0}", s);
            dynamic i = 123; Console.WriteLine("dynamic int = {0}", i);
            dynamic f = 2.5; Console.WriteLine("dynamic float = {0}", f);

            //conversion of dynamic to value type
            int i2 = i; Console.WriteLine("dynamic to int = {0}", i2);

            //runtime exception is thrown if receiver or argument of method
            //is incorrect type
            dynamic test = "string";
            //dynamicTest(test); throws error
            
        }

        public int dynamicTest(int i)
        {
            return i + 1;
        }
    }

    class DataTypes
    {
        static void Main(string[] args)
        {
       
            
            ValueDataType value = new ValueDataType(); ;
            value.display(); 
            value.literals();

            ReferenceTypes r = new ReferenceTypes();
            //r.boxingExample();
            r.dynamicType();
        }
    }
}
