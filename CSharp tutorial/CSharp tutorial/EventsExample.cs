using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * ============= Events ============
 * events are user actions like key presses, clicks or system generated notifications
 * - applications need to respond to events
 * - events are declared in a class and have event handlers which use delgates
 * - class containing the event is called publisher and publishes the event
 * - a class that eccepts the event is called a subscriber
 * publisher: class that has definition of event and event delegate. Publisher invokes event and notifies other objects (subscribers)
 * subscriber: class that accepts the event and provides event handler. The delegate in the publisher class invokes the event handler in the subscriber
 */
namespace CSharp_tutorial
{
    public delegate  void Notify(string s); //delegate

    class EventPublisher
    {
        public event Notify EventComplete; //event

        public void startEvent()
        {
            Console.WriteLine("Event started");
            string userInput = Console.ReadLine();
            onEventCompleted(userInput);
        }

        public void onEventCompleted(string s)
        {
            EventComplete(s); //invoke delegate
            
        }
    }

    class EventsExample
    {

        //event handler
        public static void ep_EventComplete(string s)
        {
            Console.WriteLine("Event ended. You entered: " + s);
            
        }

        // subscriber class
        static void Main(string[] args)
        {
            Console.WriteLine("Events: ");
            EventPublisher ep = new EventPublisher();
            ep.EventComplete += ep_EventComplete;
            ep.startEvent();
        }
    }
}
