using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 2 types
 * 1) at run time an object of a derived class is treated as a object of the base class in methods, parameters, arrays etc
 * - object no longer identicle to its run time type
 * 2) dervied class overrides a base class method and provides its own implemntation
 * - at run time CLR invokes override of the virtual method
 * - calling base virtual method invokes the proper dervied override method based on type
 * ======= virtual members ============
 * - dervied class can override base class member implementation
 * - base class member to be overriden must have virtual keyword and othe derived class must use override keyword
 * - fields (variables) cannot be virtual
 * - allows derived classes to extend or change the functionality of the base class implementation
 * ========= hide base class members with new ==========
 * -if you want derived  class to have same name as member of base class use new to hide base class member
 */
namespace CSharp_tutorial
{
    class ShapeDraw
    {
        public int x { get; set; }
        public int y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public string color = "red";

        public virtual void Draw()
        {
            Console.WriteLine("Drawing base  shape");
        }
    }
    class CircleDraw : ShapeDraw
    {
        public new string color = "blue";

        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
            base.Draw();
        }
    }
    class RectDraw : ShapeDraw
    {
        public override  void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
            
        }
    }
    class TriangleDraw : ShapeDraw
    {
        public override  void Draw()
        {
            Console.WriteLine("Drawing a triangle");
            base.Draw();
        }
    }

    class SquareDraw : RectDraw
    {
        public new void Draw()
        {
            Console.WriteLine("Drawing a square");
        }
    }

    class Polymorphism2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======== Polymorphism 2 ============");
            //list of shapes
            var shapes = new List<ShapeDraw> { new RectDraw(), new TriangleDraw(), new CircleDraw() };

            //each item in list is declared as type shape but the CLR invokes the draw method in each derived class
            foreach (ShapeDraw shape in shapes)
            {
                shape.Draw();
            }
            ShapeDraw s = new ShapeDraw();
            CircleDraw c = new CircleDraw();
            Console.WriteLine("Cirlce color = " + c.color);
            //use bade class value by casting object to base class
            ShapeDraw s2 = (ShapeDraw)c;
            Console.WriteLine("Shape color = " + s2.color);

            RectDraw r = new RectDraw();
            TriangleDraw t = new TriangleDraw();
            SquareDraw sq = new SquareDraw();
            sq.Draw();
            RectDraw r2 = (RectDraw)sq;
            r2.Draw();
            //sq.Draw();

            
        }
    }
}
