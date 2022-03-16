using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * - anonymousmethods allow you to pass a code block as a delegate parameter
 * - anonymous method is amethod without a name just a body
 * - need to specift return type of anon method. Its inferred by the rturn statement in the code block
 */


namespace CSharp_tutorial
{
    public delegate void NumberMod(int n);
    class AnonymousMethods
    {
        public static int num = 10;

        public static void addNum(int n)
        {
            num += n;
        }

        public static void multNum(int n)
        {
            num *= n;
        }

        public static void displayNumberMod(NumberMod nm)
        {
            nm(50);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Anonymous methods: ");

            //anonymous method
            NumberMod nm = delegate (int x)
            {
                Console.WriteLine(x);
            };
            nm(100);
            displayNumberMod(nm);
            nm = new NumberMod(addNum);
            nm(100);
            Console.WriteLine(num);
            NumberMod nm2 = new NumberMod(multNum);
            nm += nm2;
            nm(5);
            Console.WriteLine(num);
        }
    }
}
