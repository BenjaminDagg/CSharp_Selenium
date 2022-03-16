using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* String can be an array of chracters or string literal
 */
namespace CSharp_tutorial
{
    class Strings
    {
        static void modifyString(string s)
        {
            char[] temp = s.ToCharArray();
            temp[0] = 'x';
            string newString = new string(temp);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("====== Strings ========");

            //string literal
            string name = "Ben";
            string last = "Dagg";

            //array of characters
            char[] letters = { 'h', 'e', 'l', 'l', 'o', ',',' ', 'w', 'o', 'r', 'l', 'd' };
            string greeint = new string(letters);
            Console.WriteLine("String from chars = " + greeint);

            //string from method that returns a string
            string[] words = { "test", "concat", "string" };
            string message = String.Join(" ", words);
            Console.WriteLine("string from join = " + message);

            //string properties
            //char - returns char at position in string
            string s1 = "this is a test string";
            char c1 = s1[3];
            Console.WriteLine("char at index 3 = " + c1);
            //get length of string
            Console.WriteLine(s1 + " is " + s1.Length + " characters long");

            string s2 = "test";
            modifyString(s2);
            Console.WriteLine("s2 = " + s2);

            //string concatination
            string fname = "Ben";
            string lname = "Dagg";
            string fullName = fname + lname;
            Console.WriteLine("Full n ame is " + fullName);
            Console.WriteLine("full name is " + string.Concat(fname, lname));

            //string interpolation
            string me = $"My name is {fname} {lname}";
            Console.WriteLine("Me = " + me);

            //accessing string characters
            Console.WriteLine(fullName[2]);

            //substring returns substring starting from the given index
            //1st parameter is start index, 2nd parameter is length
            string substring = fullName.Substring(3,2);
            Console.WriteLine("substring = " + substring);
        }
    }
}
