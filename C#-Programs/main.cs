using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace myApp

{
    class Shape
    {
        public virtual void Draw()
        {
            //...
            Console.WriteLine("base class draw method");
        }
    }

    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("drawing a circle");
            base.Draw();
        }
    }

    class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("drawing a traiangle");
            base.Draw();
        }
    }

    class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("drawing a circle");
            base.Draw();
        }
    }

    class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("drawing a circle");
            base.Draw();
        }

    }
    class Program
    {
        public static void Main(String[] args)
        {
            Shape s= null;

            int ui;

            do
            {
            Console.WriteLine("choose an option to draw the shapes");
            Console.WriteLine("1: Rectangle");
            Console.WriteLine("2: Circle");
            Console.WriteLine("3: Triangle");
            Console.WriteLine("4: Square");
            Console.WriteLine("5: Exit");
            Console.WriteLine("Enter your input");

            ui= Convert.ToInt32(Console.ReadLine());

            switch (ui)
            {
                case 1:
                    s = new Rectangle();
                    break;
                case 2:
                    s = new Circle();
                    break;
                case 3:
                    s = new Triangle();
                    break;
                case 4:
                    s = new Square();
                    break;
                /*case 5:
                    break;*/
                default:
                    Console.WriteLine("wrong option");
                    break;

            }
            s.Draw();

        }
         while(ui >= 1 && ui <= 4);
        
            var drawObjects = new List<Shape>
            {
                new Rectangle(),
                new Circle(),
                new Triangle(),
                new Square(),

            };

            foreach(Shape S in drawObjects )
            {
                s.Draw();
            }
            Console.ReadLine();
        }
    }
}
