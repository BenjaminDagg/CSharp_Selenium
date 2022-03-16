using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_tutorial
{
    enum Color
    {
        RED = 0,
        GREEN = 1,
        BLUE = 2,
    }

    class DecisionMaking
    {
        /*
         * If Statement - if boolean expression is true, the block of code inside the
         * if statement is executed. If statement is false, the code block is skipped and
         * the code after the end of the if statement is executed
         * 
         * if an else if succeeds none of the remaining else ifs are tested
         */

        static void Main(string[] args)
        {
            int a = 20;

            //if an else if is true no other statements are tested. It picks the first true else if
            if (a < 10)
            {
                Console.WriteLine("A is greater than 10");
            }
            else if (a >= 10)
            {
                Console.WriteLine("a is greater than or equal to 20");
            }
            else if (a > 11)
            {
                Console.WriteLine("This is not executed");
            }
            else
            {
                Console.WriteLine("a = " + a);
            }

            //all statements should be executed
            if (a > 5)
            {
                Console.WriteLine("a greater than 5");

            }
            else if(a > 10)
            {
                Console.WriteLine("a greater than 5");
            }
            else if (a > 15)
            {
                Console.WriteLine("a greater than 15");
            }

            int num = 10;


            //each case needs to be the type of the variable being switched
            //if a case is left without a break it "falls through" to the next case that does have a break
            //default case it selected if no other case matches
            //value being switched must be integral or enum type
            switch(num)
            {
                case 9:
                    Console.WriteLine("in");
                    break;
                case 10:
                    
                case 11:
                case 12:
                    Console.WriteLine("12");
                    break;
                default:
                    Console.WriteLine("defaul");
                    break;
            }

            Color color;
            color = Color.BLUE;

            switch (color)
            {
                case Color.RED:
                    Console.WriteLine("red");
                    break;
                case Color.GREEN:
                    Console.WriteLine("Green");
                    break;
                default:
                    Console.WriteLine("blue");
                    break;
            }

            

        }
       
    }
}
