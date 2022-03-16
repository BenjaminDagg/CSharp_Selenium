using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Constants are variabled that have fixed values that cannot be altered
 * during execution
 * Also called literals
 * 
 */
namespace CSharp_tutorial
{
    class ConstantVariables
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Constants");
            Console.WriteLine("Integer literals:");

            //can be decimal or hex
            const int dec = 1000;
            const int hex = 0x4b;

            //u suffix for unsigned
            const uint udec = 255u;

            //l suffix for long
            const long declong = 999999999L;

            //ul for unsigned long
            ulong ul = 300ul;

            //floating pint literal
            //has integer,decimal point, fractional, exponent parts
            //decimal
            float f1 = 3.14159f;
            Console.WriteLine("Decimal float: " + f1);
            //exponent float is represented with E
            float f2 = 5.0e9f;
            Console.WriteLine("Exponent float: " + f2);
            //negative exponent
            float f3 = 3.05E-5f;
            Console.WriteLine(" Negative Exponent float: " + f3);
            float f4 = 100f;
            Console.WriteLine("Decimal float missing decimal: " + f4);

            //escape characters
            Console.WriteLine("\\"); // backslash
            Console.WriteLine("\'"); // backslash

            //newline
            Console.Write("First line \n");
            Console.Write("Second line \n");

            //tab
            Console.WriteLine("\t This is a tab");

            //alert
            Console.WriteLine("\a"); //plays alert sound

            //carriage return
            Console.WriteLine("Test line \r");

           

            const double pi = 3.1415;
            Console.WriteLine("Enter radius: ");
            double r = Convert.ToDouble(Console.ReadLine());
            double area = pi * r * r;
            Console.WriteLine("Radius = " + area);

        }
    }
}
