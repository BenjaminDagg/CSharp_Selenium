using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Enum is a set of named integer constants
 * - value data type
 * - cannot inherit or pass inheritence
 * - each item in enum list represents an integer - by default starting int is 0
 */
namespace CSharp_tutorial
{
    class EnumExample
    {
        //declaring enum   0     1    2    3    4    5     6     6
        [Flags]
        enum Days        { Sun = 1, Mon = 2, Tue = 3, Wed = 4, Thur = 5, Fri = 6, Sat = 7, Weekend = Sat | Sun };

        
        enum ErrorCode
        {
            SUCESS = 0,
            NOT_FOUND = 404,
            UNAUTHORIZED = 401,
            SERVER_ERROR = 500
        }

        static void Main(string[] args)
        {
            Console.WriteLine("======= Enums ===========");

            Days today = Days.Sun;
            if (today == Days.Sun)
            {
                Console.WriteLine("Today is sunday");
            }
            Days weekend = Days.Sun;
            if(weekend == Days.Weekend)
            {
                Console.WriteLine(weekend + " is a weekend day");
            }

            int error = 404;
            ErrorCode errorCode = (ErrorCode)error;
            Console.WriteLine("Error code = " + errorCode);
            int errorNumber = (int)errorCode;
            Console.WriteLine("Error number = " + errorNumber);

            //enum in a switch
            ErrorCode e = ErrorCode.UNAUTHORIZED;
            switch (e)
            {
                case ErrorCode.NOT_FOUND:
                    Console.WriteLine("Page not found");
                    break;
                case ErrorCode.UNAUTHORIZED:
                    Console.WriteLine("Unauthorized");
                    break;
                case ErrorCode.SERVER_ERROR:
                    Console.WriteLine("Unexpected server error");
                    break;
                default:
                    Console.WriteLine("Success");
                    break;
            }
            
            
        }
    }
}
