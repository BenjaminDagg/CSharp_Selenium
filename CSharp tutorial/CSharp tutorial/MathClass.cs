using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_tutorial
{
    class MathClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======== Math library ===============");

            int x = 5, y = 10;

            // finds max of 2 values
            int max = Math.Max(x, y);
            Console.WriteLine("Max = " + max);

            //finds min of 2 values
            int min = Math.Min(x,y);
            Console.WriteLine("Min = " + min);

            // square root
            Console.WriteLine("square of 100 = {0}", Math.Sqrt(100));
            Console.WriteLine("square of 75 = {0}", Math.Sqrt(75));
            Console.WriteLine("square of 100 = {0}", Math.Sqrt(-100));

            //absolute value
            Console.WriteLine("abs of -45 = {0}", Math.Abs(-45));

            //round to nearest whole number
            Console.WriteLine("round 2.75 = {0}", Math.Round(2.75));
            Console.WriteLine("round 2.5 = {0}", Math.Round(2.5));
            Console.WriteLine("round 2.25 = {0}", Math.Round(2.25));
            Console.WriteLine("round -2.75 = {0}", Math.Round(-2.75));
        }
    }
}
