using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * You can use pointers in a block of code marked "unsafe"
 * ======== Pointers ===========
 * - pointer is a vriable whose value is the address of another variable (address of the memory location)
 * - type *variable_name
 * - * = dereference operator - displays value at the memory address the pointer points to
 * - pointers can only be used to hold address of value types  and arrays
 * - & = reference operator - used to get memory address of a variable
 * - (type)ptr gives the memory addresss of the variable the pointer points to
 * ========= Pointer to arrays ===========
 * - c# garbage collector can move objects in memory during the program garbage collection process
 * -"fixed" keyword tells garbage collector not to move the object in memory
 * - fixes the memory location of the value the pointer points to
 * - this is called pinning
 */
namespace CSharp_tutorial
{
    class PStruct
    {
        public int x;
        public int y;

        public void SetXY(int a, int b)
        {
            x = a;
            y = b;
        }

        public void display()
        {
            Console.WriteLine("X: {0}, Y:{1}", x, y);
        }
    }

    class UnsafePointers
    {
        static unsafe void unsafeSwap(int* x, int* y)
        {
            int temp = *x;
            *x = *y;
            *y = temp;
        }

        static unsafe void Main(string[] args)
        {
            Console.WriteLine("Unsafe code: ");

            int var = 20;
            int* p = &var;
            Console.WriteLine("Data: {0}", var);
            Console.WriteLine("Data *: {0}", *p);
            Console.WriteLine("Data ->:", p->ToString());
            Console.WriteLine("Address: {0}", (int)p);

            int x = 1, y = 2;
            int* px = &x;
            int* py = &y;
            Console.WriteLine("Values before swap: x = {0}, y={1}", x,y);
            unsafeSwap(px,py);
            Console.WriteLine("Values after swap: x = {0}, y={1}", x, y);

            int* pz = &x;
            *pz = 3;
            Console.WriteLine("px = {0}, x = {1}", *px, x);

            int[] array = { 100, 200, 300 };
            fixed (int* arr = array)

            for(int i = 0; i < array.Length; i++)
            {
                Console.Write("Address of array[{0}] = {1}, ",i, (int)(arr + i));
                Console.Write("Value of array[{0}] = {1}, ",i, *(arr + i));
                Console.WriteLine();
            }

          
        }
    }
}
