using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Arrays store fixed sized collection of elements of the same data type
 * - elements of array are stored in contiguous memory locations
 * - an element of an array is accessed by index
 * - syntax: <data_type>[] variable_name;
 * - [] is the rank (size) of the array
 */
namespace CSharp_tutorial
{
    class Arrays
    {


        /*Params array lets you pass in a variable amount of arguments to the array
         */
        static int add(params int[] a)
        {
            int sum = 0;
            foreach (int i in a)
            {
                sum += i;
            }
            return sum;
        }

        static int[] reverse(int[] arr)
        {
            int[] tmp = new int[arr.Length];

            int j = arr.Length - 1;
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = arr[j];
                j--;
            }
            return tmp;
        }

        static double getAvg(int[] nums)
        {
            double avg = 0;
            int size = nums.Length;

            for(int i = 0; i < nums.Length; i++)
            {
                avg += nums[i];
            }

            avg = avg / size;
            return avg;
        }

      

        static void Main(string[] args)
        {
            Console.WriteLine("======= Arrays =========");

            //declaring array
            double[] balance;
            /*initializing array - declaring it (above) hasnt initiaized it in memory yet
             * array is a reference type so you use the new keyword to create an instance of the array
             */
            balance = new double[10];
            //assign value to individual element of array with index
            balance[0] = 19.99;

            //assign values to array at time of declaration
            double[] balance2 = { 2.5, 1.6, 24.56 };
            //create and initialize array
            int[] marks = new int[5] { 1, 2, 3, 4, 5 };
            //omit size of array on declaration
            int[] marks2 = new int[] { 1, 2, 3 }; //array is size 3;

            //you can assign an existing array variable to a target array variable
            //both variables now refer to the same memory location
            int[] score1 = new int[] { 1, 2, 3 };
            int[] score2 = score1;
            score2[0] = 4;
            Console.WriteLine("Score1[0] = " + score1[0]);

            //access array element by placing indexc # betwee brackets after array name
            int[] n = new int[5];
            //initialize elements of array
            for(int i = 0; i < n.Length; i++)
            {
                n[i] = (i + 1) * 100;
            }
            //output value for each element in the array
            for (int i = 0; i < n.Length; i++)
            {
                Console.WriteLine("n[{0}] = {1}", i, n[i]);
            }
            //using foreach loop to access array
            foreach (int j in n)
            {
                Console.WriteLine("j = " + j);
            }

            /*2 dimensional arrays
             * syntax: <data_type>[row,col] <variable_name>
             * -row = number of arrays in list of arrays (i index)
             * - col - size of each array in list (j index)
            */
            int[,] a = new int[3, 4]
            {
                {4,6,7,1 },
                {5,8,9,2},
                {6,10,11,3}
            };
            Console.WriteLine("3rd row 3rd colums = " + a[2, 2]);
            //displaying 2d array
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4;j++)
                {
                    Console.WriteLine("a[{0}][{1}] = {2}",i,j,a[i,j]);
                }
            }

            //"jagged" array - uneven # of rows and columns
            int[][] jagged = new int[][] { new int[] { 4, 5, 1 }, new int[] { 3, 5, 7, 5, 2 }, new int[] { 1 }, new int[] { 4, 6, 1, 3, 4, 6, 7 } };
            for(int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.WriteLine("jagged[{0}][{1}] = {2}",i,j, jagged[i][j]);
                }
            }

            int[] scores = new int[] { 6, 7, 1, 8, 9 };
            Console.WriteLine("avg of scores = " + getAvg(scores));

            /* Params array lets you pass a variable amound of arguments */
            Console.WriteLine("Sum = " + add(2, 4, 6, 7, 1, 3, 5, 6, 7));
            Console.WriteLine("Sum = " + add(2, 4, 6, 7));

            int[] rev = reverse(scores);
            for(int j = 0; j < rev.Length; j++)
            {
                Console.WriteLine(rev[j]);
            }

        }
    }
}
