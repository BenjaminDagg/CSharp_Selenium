using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/*
 * ========= Regular Expression ===========
 * - matches pattern against an input text
 * 
 * =========Character classes ===========
 * [group] = matches any single character in the group (Example [mn] matrches m or n in  any word
 * [^group] matches any character not in the group
 * [first-last] matches any characters in range from first to last [b-d] birds, cirds, dirds
 * \w matches alphanumeric
 * \W matches not alphanumeric
 * \s matches white space characters (Example \W\s matches "D " in "ID A1.3"
 * \S matches non white space character
 * \d matches numeric value
 * \D matches any other character other than decimal
 * 
 * ========= anchors =============
 * ^ match must be at beginning
 * $ match must be at end of string
 * \A match must be at start of string
 * \Z match must occur at end of string
 * \z match must occur at end of string
 * \G match must be at point where prev match ended
 * 
 * ========= quantifiers =========
 * * zero or more times \d*\.\d = any # of digits then . and one digit
 * + one or more times
 * ? matches previous element zero or one time
 * {n} matches previous element exactly n times
 * {n,} matthces previous element at least n times
 * {n,m} matches previous element at least n times but less than m times
 * *? matches zero or more times but as few as possible
 * +? matches one or more times but as few as possible
 * ?? matches zero or 1 time but as few as possible
 * {n,}? matches previous element at least n times but as few as possbile
 * {n,m} matches previous element between an and m times but as few as possible 
 * 
 * ========= alternate constructs "either or" =============
 * | matches any one element seperate by | character (example the(e|is|at)
 * (?(expression)yes|no)
 */
namespace CSharp_tutorial
{
    

    class RegularExpressions
    {

        public static void showMatch(string text, string expr)
        {
            MatchCollection mc = Regex.Matches(text,expr);

            foreach (Match m in mc)
            {
                Console.WriteLine(m);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Regular expressions:");
            string str = "A thousand Splendid Suns";

            string pattern = @"\bS\w*s";
            showMatch(str, pattern);

            string input = "Hello  World space";
            string patterns = "\\s+";
            string replacement = ",";

            Regex reg = new Regex(patterns);
            string result = reg.Replace(input, replacement);
            Console.WriteLine(result);

        }
    }
}
