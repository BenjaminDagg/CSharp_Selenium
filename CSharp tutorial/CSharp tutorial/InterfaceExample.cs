using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * defines contract that inheriting classes should follow
 * -interface defines "what" and the inherting classes define "how"
 * - interfaces define properties, methods, events which inheriting members must follow
 * - interface defines declaration and the inherting classes define actual implementation
 * - interface members are public by default
 * - doesnt have instance auto properties, declaring a property must be implemented in class that inherits it
 */
namespace CSharp_tutorial
{

    public interface ITransactions
    {
        void showTransaction();
        double getAmount();

        string getDate();

        //inherting class must implement
        public string Currency { get; set; } //doesnt declare auto implement proprty
    }

    class Transaction : ITransactions
    {
        private string tCode;
        private string date;
        private double amount;

        //implementing interface property
        public string Currency
        {
            get { return tCode; }
            set { tCode = value; }
        }

        public Transaction(string t, string d, double a)
        {
            tCode = t;
            date = d;
            amount = a;
        }

        //implementing interface 
        public double getAmount()
        {
            return amount;
        }

        //implementing interface
        public void showTransaction()
        {
            Console.WriteLine("Code: {0}, Date: {1}, Amount: {2}", tCode, date, amount);
        }

        //explicit interface member implementation
        //can only be accessed from instance of the interface
        string ITransactions.getDate()
        {
            return date;
        }

        public void display()
        {
            Console.WriteLine("displaying class");
        }
    }

    class InterfaceExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======== Interfaces =========");
            Transaction t1 = new Transaction("0001", "2/22/2022", 45.50);
            t1.showTransaction();
            //t1.getDate(); invalid
            //declaring interface instance
            ITransactions t2 = new Transaction("0002", "2/22/2022", 542.34);
            t2.getDate();
            t2.Currency = "USD";
            t2.showTransaction();
            //t2.display(); error ITransaction doesn thave display 
        }
    }
}
