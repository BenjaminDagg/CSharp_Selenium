using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * - names defined in one namespace do not conflict with the same class names declared in another
 * - used to keep one set of names separate from another
 * - to call namespace specific version of a name use namespace.variable_name
 * ======== using keyword ==========
 * - states the program uses the names in the given namespace
 * - we use the System namespace to print to console
 * - using keyword lets you leave out the namespace name in namespace.variable_name because it tells the
 * compiler that to make use of the names in the namespace
 */

using Third;

//nested namespace
using Inner = Outter.Inner;

namespace First
{
    class NamespaceClass
    {
        public void func()
        {
            Console.WriteLine("First namespace func");
        }
    }
}

namespace Second
{
    class NamespaceClass
    {
        public void func()
        {
            Console.WriteLine("Second namespace func");
        }
    }
}

namespace Third
{
    class ThirdClass
    {
        public void func()
        {
            Console.WriteLine("third namespace func");
        }
    }
}

//nested namespace
namespace Outter
{
    class OutterClass
    {
        public void func()
        {
            Console.WriteLine("Outter namespace func");
        }
    }

    namespace Inner
    {
        class InnerClass
        {
            public void func()
            {
                Console.WriteLine("Inner namespace func");
            }
        }
    }
}



namespace CSharp_tutorial
{


    class ExampleNamespace
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== Namespace =============");

            First.NamespaceClass first = new First.NamespaceClass();
            Second.NamespaceClass second = new Second.NamespaceClass();
            first.func();
            second.func();

            //included third namespace in using keyword so dont need to specify namespace
            ThirdClass third = new ThirdClass();
            third.func();

            //nested namespace
            Outter.OutterClass o = new Outter.OutterClass();
            Inner.InnerClass i = new Inner.InnerClass();
        }
    }
}
