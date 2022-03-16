using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


/*
 * Thread = path of execution in a program
 * 
 * ======== Thread life cycle =========
 * - starts when object of System.Threading.Thread is created
 * 1) unstarted state - thread object is creation but start method isnt called
 * 2) ready state - threat is waiting for CPU cycle to run
 * 3) not runnable state: 1) sleep method was called 2) wait method was called 3) blocked by i/o
 * 4) dead state - thread completed execution or is aborted
 * 
 * ========= Main thread ========
 * - system.threading.thread class is used to create and access individual threads
 * -1st thred to be executed is main thread
 * - main thread automaticall created when program starts
 * - threads created using Thread calss are children threads of main thread
 * - Thread.CurrentThread gets currently running thread
 */
namespace CSharp_tutorial
{
    class Multithreading
    {
        public static void CallToChildThread()
        {
            try
            {
                Console.WriteLine("Starting child thread");
                for(int i = 0; i < 100; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(500);
                }
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine("Thread abort exception");
            } finally
            {
                Console.WriteLine("Couldnt catch thread exceptions");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Multithreading");

            Thread mainThread = Thread.CurrentThread;
            Console.WriteLine("Current thread is {0}", mainThread.Name);

            ThreadStart childRef = new ThreadStart(CallToChildThread);
            Console.WriteLine("In main: creating child thread");
            Thread childThread = new Thread(childRef);
            childThread.Start();

            Console.WriteLine("Main sleeping");
            Thread.Sleep(2000);

            Console.WriteLine("In main abording child thread");
            childThread.Interrupt();
        }
    }
}
