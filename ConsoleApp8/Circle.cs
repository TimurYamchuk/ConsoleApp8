using System;
using System.IO;

namespace ConsoleApp8
{
    class Circle : Shape
    {
        double x;
        double y;
        double radius;

        public Circle(double pointX, double pointY, double radiusValue)
        {
            x = pointX;
            y = pointY;
            radius = radiusValue;
        }

        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine("Circle:");
            Console.WriteLine("X: " + x + "\nY: " + y + "\nRadius: " + radius);
        }

        public override double Area()
        {
            return Math.PI * radius * radius;
        }

        public override void Save(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            writer.WriteLine(x);
            writer.WriteLine(y);
            writer.WriteLine(radius);
        }

        public override void Load(StreamReader reader)
        {
            x = double.Parse(reader.ReadLine());
            y = double.Parse(reader.ReadLine());
            radius = double.Parse(reader.ReadLine());
        }
    }
}
