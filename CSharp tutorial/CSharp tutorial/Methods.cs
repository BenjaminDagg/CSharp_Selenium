using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Method: group of statements to perform a task
 * Structure:
 * <Access Specifier> <Return Type> <Method Name>(Parameter List){}
 * -
 */
namespace CSharp_tutorial
{

    class MyPoint
    {
        public int x;
        public int y;
    }

    class Methods
    {
        static int defaultParameter(int x, int y = 2)
        {
            return x + y;
        }

        public int findMax(int num1, int num2)
        {
            if(num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }

        //recursive function
        public long factorial(long n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }

        /*
         * Pass parameters by value
         *  - values of the parameters are copied into the function
         *  - changes made to the parameters inside the method dont effect the values 
         *  - default method for passing paprameters
         */
        public void swapByValue(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        /*
         * Pass parameters by reference
         * -passes reference to the memory location of the variable
         * - changes made to parameterse inside the method change the actual values
         * - use ref keyword
         *  - ref required variable be initialized before it is passed
         */
        public void swapByRef(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        /*
         * Out keyword
         * - like ref in that is passes by reference
         * - variable doesn't have to be initialized before being passed
         * - parameter must be modified
         */
        public void outExample(out int num)
        {
            num = 100;
        }

        /*
         * In parameter
         * - passes by reference
         * - parameter cannot be modified
         * - variable must be initialted before passing
         * - used for performance to avoid the overhead of copying the parameter by value (for structs or objects for example)
         */

        public void inExample(in int x)
        {
            //x = 100; generated error when attempt o modify in parameter
            int y = x;
        }


        /*
         * When reference data type a variable contains a reference to the object.
         * Passing an object to a method creates a copy of the reference. Both the actual variable
         * and the parameter contain reference to the same object so changing the object in the method
         * will actually change the pbject
         */
        public void pointExample(MyPoint p)
        {
            p.x = 2;
        }

        public void arrayExample(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 1;
            }
        }

        /*
         * Method overloading is when multiple methods have the same name with different signatures (parameters)
         */
        static int add(int x, int y)
        {
            return x + y;
        }

        static int add(int x, int y, int z)
        {
            return x + y + z;
        }

        static double add (double x, double y)
        {
            return x + y;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("========= Methods ========");
            Methods m = new Methods();
            Console.WriteLine("Recursive factorial = {0}", m.factorial(8));

            //default parameter
            Console.WriteLine("Default = {0}", defaultParameter(1));
            Console.WriteLine("Default = {0}", defaultParameter(1,1));

            //swap by value - no effect
            int a = 1, b = 2;
            Console.WriteLine("Before swap by value a={0} b = {1}", a, b);
            m.swapByValue(a, b);
            Console.WriteLine("After swap by value a={0} b = {1}", a, b);

            //swap by reference - memory location is passed to method parameter and changes the variable value
            Console.WriteLine("Before swap by reference a={0} b = {1}", a, b);
            m.swapByRef(ref a, ref b);
            Console.WriteLine("After swap by reference a={0} b = {1}", a, b);

            //out example
            int outNum;
            m.outExample(out outNum);
            Console.WriteLine("Outnum after calling out = {0}", outNum);

            /* passing object to function
             * Both the variable refering to the object and the method parameter contani a reference
             * to the same object. So changing the object in the method actually changes the object
             */
            MyPoint p = new MyPoint();
            p.x = 1;
            p.y = 1;
            m.pointExample(p);
            Console.WriteLine("new p = {0}", p.x);

            //array example;
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            m.arrayExample(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]);
            }

        }
    }
}
