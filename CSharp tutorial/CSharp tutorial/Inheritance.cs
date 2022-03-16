using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * - used to reuse code to speed up implementation
 * Inheritance is defining a class in terms of an existing class
 * - the new class inheritcs members of the existing class
 * - base class = existing class
 * - derived class is the new class that inherits the base classs
 * - implements "Is a" relationsship. Example: mammal IS A animal, dog IS A mammal, so dog IS A animal
 * - derived class inherits member variables and method
 * - you can give instructions for base initialization in the derived class initialization list
 * - c# does not support multiple inheritance (derived class inherits 2 classes)
 * - use interface to implement multiple inheritance
 */
namespace CSharp_tutorial
{
    //base class
    class Shape
    {
        protected int width;
        protected int height;

        public Shape(int w, int h)
        {
            width = w;
            height = h;
        }

        public void setWidth(int w)
        {
            width = w;
        }

        public void setHeight(int h)
        {
            height = h;
        }
    }

    //derived class
    class Rectangle : Shape
    {
        //calling base constructor
        public Rectangle(int l, int h) : base(l, h)
        {

        }
        
        public int getArea()
        {
            return width * height;
        }

        public void display()
        {
            Console.WriteLine("Width: " + width);
            Console.WriteLine("Height: " + height);
            Console.WriteLine("Area: " + getArea());
        }
    }

    /*
     * You can use interfaces to implement multiple inheritance
     */
    public interface IShape
    {

        public int getCircumference();
    }

    class TableTop : Rectangle, IShape
    {
        private double cost;

        //calling base constructor
        public TableTop(int l, int h, double c) : base(l, h)
        {
            cost = c;
        }

        public double getCost()
        {
            return getArea() * cost;
        }

        public void display()
        {
            base.display();
            Console.WriteLine("Cost: " + getCost());    
        }

        //implement interface
        public int getCircumference()
        {
            return (width * 2) + (height * 2);
        }
    }

    class Inheritance
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========= Inheritance =============");
            Rectangle r = new Rectangle(5,10);
            //calling shape bade class methods which are inherited by derived class
            r.setHeight(5);
            r.setWidth(10);
            //getArea mwthod is only base class
            int area = r.getArea();
            r.display();
            TableTop t = new TableTop(5, 10, 5);
            t.display();

            TableTop tt2 = new TableTop(5, 10, 5);
            Rectangle r2 = new Rectangle(5,10);

            TableTop tt3 = (TableTop)r2;
            tt3.getCost();
            
        }
    }
}
