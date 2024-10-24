using System;
using System.IO;

namespace ConsoleApp8
{
    class ShapesArray
    {
        Shape[] shapes = new Shape[2];
        int size = 0;

        public int Size => size;

        public Shape this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException("Индекс вне диапазона.");
                return shapes[index];
            }
        }

        public void Add(Shape shape)
        {
            if (size == shapes.Length)
            {
                Array.Resize(ref shapes, shapes.Length * 2);
            }
            shapes[size++] = shape;
        }

        public void Remove(Shape shape)
        {
            int index = Array.IndexOf(shapes, shape, 0, size);
            if (index >= 0)
            {
                for (int i = index; i < size - 1; i++)
                {
                    shapes[i] = shapes[i + 1];
                }
                shapes[--size] = null;
                Console.WriteLine("Фигура удалена.");
            }
            else
            {
                Console.WriteLine("Фигура не найдена.");
            }
        }

        public void Print()
        {
            for (int i = 0; i < size; i++)
            {
                shapes[i].Show();
            }
        }

        public void OutputSpecifiedFigure(string figure)
        {
            bool found = false;
            for (int i = 0; i < size; i++)
            {
                Shape shape = shapes[i];
                if ((figure == "Triangle" && shape is Triangle) ||
                    (figure == "Rectangle" && shape is Rectangle) ||
                    (figure == "Circle" && shape is Circle))
                {
                    shape.Show();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Такой фигуры нет.");
            }
        }

        public void AreaFigure()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Площадь фигуры {i}: {shapes[i].Area()}");
            }
        }

        public void AreaTypeFigure(string figure)
        {
            bool found = false;
            for (int i = 0; i < size; i++)
            {
                Shape shape = shapes[i];
                if ((figure == "Triangle" && shape is Triangle) ||
                    (figure == "Rectangle" && shape is Rectangle) ||
                    (figure == "Circle" && shape is Circle))
                {
                    Console.WriteLine($"Площадь {figure.ToLower()}: {shape.Area()}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Такой фигуры нет.");
            }
        }

        public void Save()
        {
            using (StreamWriter writer = new StreamWriter("Figure.txt"))
            {
                for (int i = 0; i < size; i++)
                {
                    shapes[i].Save(writer);
                }
            }
            Console.WriteLine("Фигуры сохранены в файл.");
        }

        public void Load()
        {
            size = 0;
            using (StreamReader reader = new StreamReader("Figure.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string shapeType = reader.ReadLine();
                    Shape shape = null;

                    if (shapeType == "Triangle")
                    {
                        shape = new Triangle(0, 0);
                    }
                    else if (shapeType == "Rectangle")
                    {
                        shape = new Rectangle(0, 0, 0, 0);
                    }
                    else if (shapeType == "Circle")
                    {
                        shape = new Circle(0, 0, 0);
                    }

                    if (shape != null)
                    {
                        shape.Load(reader);
                        Add(shape);
                    }
                }
            }
            Console.WriteLine("Фигуры загружены из файла.");
        }
    }
}
