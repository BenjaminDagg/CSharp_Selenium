using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * ========= Delegates ===========
 * - similar to pointers to function in c++
 * - reference type variable
 * - holds reference to a method
 * - used to implement events and callback methods
 * - refers to a method with the same signature as the delegate
 * - delegate <returnType> <delegateName> <parameterList>
 * - delegate object is created with new keyword and be associated to a method
 * 
 * ============ Multicasting delegate ==========
 * - composed delegate calls the two delegates it was composed from
 * - delegate objects are composed with + operator
 * - only delegates of same type can be composed
 * - "-" is used to remove a delegate object from a delegate composition
 * - composed delegates creates an invokation list that is called when the composed delegate is called
 * - this is called multicasting a delegate
 */
namespace CSharp_tutorial
{
    delegate int NumberCalculater(int n);

    

    class DelegatesExample
    {
        static int num = 10;
       

        public delegate void PrintString(string s);

        public static void printToConsole(string s)
        {
            Console.WriteLine(s);
        }

        public static void printToFile(string s)
        {
            FileStream fs = new FileStream(@"C:\Users\Ben\Documents\c# tutorial\CSharp tutorial\newDir\newText.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public static void sendString(PrintString ps, string s)
        {
            ps(s);
        }

        public static int addNum(int x)
        {
            num += x;
            return num;
        }

        public static int multiplyNum(int x)
        {
            num *= x;
            return num;
        }

        public static int getNum()
        {
            return num;
        }

        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Delegates: ");

            //create delegate instances
            NumberCalculater nc1 = new NumberCalculater(addNum);
            NumberCalculater nc2 = new NumberCalculater(multiplyNum);
            NumberCalculater nc3 = nc1 + nc2;

            //call methods using delegate objects
            nc1(10);
            Console.WriteLine("Num = " + num);
            nc2(2);
            Console.WriteLine("Num = " + num);

            num = 10;
            nc3(5); // calls addNum then multiplyNum
            Console.WriteLine("Num = " + num);

            PrintString ptf = new PrintString(printToFile);
            PrintString ptc = new PrintString(printToConsole);
            ptc("test");
            sendString(ptc, "hello world");
            sendString(ptf, "print to file");
        }
    }
}
