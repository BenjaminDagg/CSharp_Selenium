using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Console.ReadLine() gets user input
 * -returns a string so cant assign numeric value to it
 * - user Conert.To methods to convert string to expected data type
 * 
 */
namespace CSharp_tutorial
{
   

    class UserInput
    {
        
        public void getString()
        {
            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Your username is " + username);
        }

        public void convertExample()
        {
            Console.WriteLine("Enter your age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your age is " + age);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("======= User Input =============");
            UserInput ui = new UserInput();
            ui.getString();
            ui.convertExample();
        }
    }
}
