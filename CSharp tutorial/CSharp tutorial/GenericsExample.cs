using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * ========= Generics ==========
 * - generics allow you to write a class or method that works for any data type
 * - you write class or method implpementation with substituted parameters for data types
 * - the comiler generates code to handle specific data type when the class or function is called
 * 
 * ========= Generic methods ===========
 * - declare a generic method with a type paramemter
 * MethodName<T>(T param1, T param2) {}
 */
namespace CSharp_tutorial
{
    public class GenericArray<T>
    {
        private T[] array;

        public GenericArray(int size)
        {
            array = new T[size];
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length - 1)
                {
                    return array[index];
                }
                return default(T);
            }
            set
            {
                if (index >= 0 && index < array.Length - 1)
                {
                    array[index] = value;
                }
            }
        }

        public T getItem(int i)
        {
            return array[i];
        }

        public void setItem(int i, T value)
        {
            array[i] = value;
        }
    }

    class GenericsExample
    {
        public static int num = 5;

        public delegate T NumberChanger<T>(T value);

        static void GenericSwap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static T GenericAdd<T>(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;

            return x + y;
        }

        static int AddNum(int a)
        {
            num += a;
            return num;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("======== Generics ==========");
            GenericArray<int> intArray = new GenericArray<int>(5);

            for (int i = 0; i < 5; i++)
            {
                intArray.setItem(i, (i + 1) * 100);
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("intArray[{0}] = {1}",i, intArray.getItem(i));
            }

            GenericArray<char> charArray = new GenericArray<char>(5);
            for(int i = 0; i < 5; i++)
            {
                charArray.setItem(i, (char)(i + 97));
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("charArray[{0}] = {1}",i, charArray.getItem(i));
            }

            char charA = 'a';
            char charB = 'b';
            int intA = 1;
            int intB = 2;

            Console.WriteLine("chars before swap a = {0}, b = {1}",charA,charB);
            GenericSwap<char>(ref charA, ref charB);
            Console.WriteLine("chars after swap a = {0}, b = {1}", charA, charB);

            Console.WriteLine("int before swap a = {0}, b = {1}", intA, intB);
            GenericSwap<int>(ref intA, ref intB);
            Console.WriteLine("int after swap a = {0}, b = {1}", intA, intB);

            NumberChanger<int> NumberChangerInt = new NumberChanger<int>(AddNum);
            NumberChangerInt(5);
            Console.WriteLine("Num = " + num);

            Console.WriteLine("Add integers: 1 + 2 = {0}", GenericAdd(1, 2));
            Console.WriteLine("Add doubles 4.5 + 5.5 = {0}", GenericAdd(4.5, 5.5));

            dynamic d = 1;
            d += 2.5;
            Console.WriteLine("i = " +d);
        }
    }
}
