#define PI
#define DEBUG


//#define ONE
//#define TWO




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * ======= Proprocessor Directives =============
 * - give instructions to compiler to preprocess information before compilation
 * - begin with #
 * - used to help in conditional compilation
 * 
 * ========== #DEFINE ==================
 * - creates symbolic constant
 * -use symbol in #IF directive 
 * 
 * =========== #IF checks if symbol is defined ==============
 * - #if specificed symbol is defined, code is compiled
 * - #elif opens new conditional compilation and closes #IF
 * - #else closes preceding conditional and opens a new conditional if previous symbol ISNT defined
 * - #endif closes the conditional compilation
 * - #IF only tests if symbol is defined not value of symbol
 * 
 * ========== Operators ============
 * - && checks if either 1 exists
 * - || checks if both or neither exist
 * 
 * =========== #REGION ===========
 * - defines a block of code that can be expaned or collapsed
 * 
 * ============ Errors & Warnings ==========
 * - #error generates compile time error
 * - #warning generates compile time warning
 * #line change line # printed with error messages/warnings
 */



namespace CSharp_tutorial
{
    #region Class definition
    class PreprocessorExample
    {

        static void Main(string[] args)
        {
            int x = 0;
            Console.WriteLine("=========== Preproccessor =============");

#if DEBUG
            Console.WriteLine("Debug is enabled");
#elif VC8
            Console.WriteLine("else if debug is defined");
#else
            Console.WriteLine("No other symbols were defined");
#endif

#if (ONE && TWO)
    Console.WriteLine("one and two is defined");
#elif (ONE && !TWO)
            Console.WriteLine("only one is defined");
#elif (!ONE && TWO)
            Console.WriteLine("only two is defined");
#else
    Console.WriteLine("neither one or two is defined");
#endif

#if (THREE || FOUR)
    Console.WriteLine("three or four is defined");
#elif (!(THREE || FOUR))
            Console.WriteLine("neither 3 or four");
#elif (!ONE && TWO)
            Console.WriteLine("only two is defined");
#else
            Console.WriteLine("neither one or two is defined");
#endif

            if(x == 0)
            {
#warning x is 0
            }
        }
    }
    #endregion
}
