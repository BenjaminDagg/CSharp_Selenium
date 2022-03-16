using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Variable is a name given to storage that the program can manipulate
 * types of variables:
 * 1. integral: byte,short,int,long,char
 * 2. floating point: float, double
 * 3. Decimal 
 * 4. boolean - true or false
 * 5. nullabe
 * 6. value - struct and enum
 * 7. reference - class
 * 
 */
namespace CSharp_tutorial
{
    class Variables
    {
        static void Main(string[] args)
        {
            //declaring variables <datatype> <variableList>
            //you can declare a variable then  assign a value later
            int i, j, k;
            float f;
            double d;
            bool b;

            //initialize variable (assign a value) variableName = value
            i = 1; j = 2; k = 3;
            f = 2.5F;
            d = 1.5;
            b = false;

            int c = i + j + k;

            //accepting value from user
            int userNum;
            //Readline reads a string so Conertt.ToInt32 converts to int type
            Console.WriteLine("Enter a number: ");
            userNum = Convert.ToInt32(Console.ReadLine());  
            Console.WriteLine("you entered {0}",userNum);

            //you can overwrite the value of a variable
            int myNum = 100;
            myNum = 200;
            Console.WriteLine("Mynum = {0}",myNum);

            //const keywords makes a variable unchangeable
            const double Pi = 3.14;
            //Pi = 4; error when attempting to change constant

            //writeline displays variable value to console
            int num = 5;
            //combine text and variable with +
            Console.WriteLine("My number is " + num);

            //you can combine variables with +
            string fName = "Ben ";
            string Lname = "Dagg";
            string fullName = fName + Lname;
            Console.WriteLine("My name is " + fullName);

            int num1 = 5;
            int num2 = 10;
            Console.WriteLine(num1 + num2);

            //Writeline prints each entry on a new line
            Console.WriteLine("first");
            Console.WriteLine("second");
            Console.WriteLine("third");

            //Write() prints on the same line
            Console.Write("first ");
            Console.Write("second ");
            Console.Write("third");
        }
    }
}
