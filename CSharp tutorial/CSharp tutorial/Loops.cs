using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Loops let you execute a statement or group of statements multiple times
 */
namespace CSharp_tutorial
{
    class Loops
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========= Loops ===============");

            /*
             * While loops executes the code block as long as the condition is true
             * When condition is false the loops ends and goes to next line after loop
             * While loop may never start if condition starts out false
             */

            int i = 1;
            while(i != 10)
            {
                Console.WriteLine("i = {0}", i);
                i += 1;
            }

            //wont enter this loop
            while (i <= 10)
            {
                i++;
            }
            Console.WriteLine("i = " + i);

            /*
             * For loop
             * 3 parts: init: set loop control variable; condition: if true execute loop body if false leave loop; increment update loop
             * control variables
             * 1.init - set loop control variables
             * 2. condition - if true execute loop, if false do not execute loop
             * 3. increment - update loop control variable
             * 4. repeate steps 2 and 3
             */
            for (int j = 0; j < 5;j+=2)
            {
                Console.WriteLine("j = " + j);
            }

            /*
             * Do while loop
             * - guaranteed to execute at least one time because the condition check is at the end
             * 1. execute code block
             * 2. checks condition - if true execute again, if false end the loop
             */

            //only executes once
            int k = 0;
            do
            {
                Console.WriteLine("k = " + k);
                k += 1;
            } while (k < 10);
            //Console.WriteLine("k = " + k);

            for(int a = 2; a <= 100;a++)
            {
                for (int b = 2; b <= a;b++)
                {
                    if (a % b == 0 && b != a)
                    {
                        break;
                    }
                    if (a == b)
                    {
                        Console.WriteLine("{0} is prime", a);
                    }
                }
                
            }

            /*
             * Break statement terminates loop and control resumes to next statement following the loop
             * If used inside a nested loop the innermost loop breaks and goes to next tieration of outtermostloop
             */

            //print 1-7
            for (int c = 1; c <= 10; c++)
            {
                if (c > 7)
                {
                    break;
                }
                Console.WriteLine("c = " + c);
            }

            /*
             * Continue key work forces next iteration of loop skipping the current code and going to next condition check
             * - for for loops it skips to condition check and iteration
             * - for do while loops it skips to condition check
             */

            //print 1-10 but skips 5-7
            int d = 1;
            do
            {
                if (d >= 5 & d <= 7)
                {
                    d += 1;
                    continue;
                }
                
                Console.WriteLine("d = " + d);
                d += 1;
            } while (d <= 10);

            // continue - only prints even #
            for (int l = 1; l <= 10;l++)
            {
                if (l % 2 != 0)
                {
                    continue;
                }
                Console.WriteLine("{0} is even", l);
            }


            /*
             * Foreach loop loops through elements of an array
             */
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int num in nums)
            {
                Console.WriteLine("num = " + num);
            }
            //empty array
            int[] num2 = { };
            foreach(int num in num2)
            {
                Console.WriteLine("num2 = " + num);
            }
            
        }
    }
}
