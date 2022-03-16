// See https://aka.ms/new-console-template for more information



using System; //using includes System namespace

/* block comment */
//single line comment

namespace HelloWorldApplication //namespace = collection of classes/structs/interfaces etc
{

    class Rectangle
    {
        //member variables
        double length;
        double width;

        public void AcceptDetails() //member function (declared within a class)
        {
            length = 4.5;
            width = 3.5;
        }

        public double getArea() //member function (declared within a class)
        {
            return this.length * this.width;
        }

        public void Display() //member function (declared within a class)
        {
            Console.WriteLine("length = {0}", length); 
            Console.WriteLine("width= {0}", width);
            Console.WriteLine("Area = {0}", getArea());
        }

        
    }

    class HelloWorld
    {
        static void Main(string[] args) //entry point of program
        {
            //instantiate rectangle class
            Rectangle r = new Rectangle();
            r.AcceptDetails();
            r.Display();  
            Console.WriteLine("Hello");
        }
    }

}


//top level entry point
//Console.WriteLine("top level");

/* top level main 
static void Main(string[] args)
{
    Console.WriteLine("Hello");
}
*/