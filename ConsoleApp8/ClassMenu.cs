using System;

namespace ConsoleApp8
{
    class ClassMenu
    {
        ShapesArray shapesArray = new ShapesArray();

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Добавить фигуру\n2. Удалить фигуру\n3. Печать всех фигур");
                Console.WriteLine("4. Печать фигур указанного типа\n5. Площадь всех фигур\n6. Площадь фигур указанного типа");
                Console.WriteLine("7. Сохранить в файл\n8. Загрузить из файла\n0. Выход");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        AddShape();
                        break;
                    case "2":
                        RemoveShape();
                        break;
                    case "3":
                        shapesArray.Print();
                        break;
                    case "4":
                        Console.Write("Введите тип фигуры: ");
                        shapesArray.OutputSpecifiedFigure(Console.ReadLine());
                        break;
                    case "5":
                        shapesArray.AreaFigure();
                        break;
                    case "6":
                        Console.Write("Введите тип фигуры: ");
                        shapesArray.AreaTypeFigure(Console.ReadLine());
                        break;
                    case "7":
                        shapesArray.Save();
                        break;
                    case "8":
                        shapesArray.Load();
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
            }
        }

        private void AddShape()
        {
            Console.Write("Тип фигуры (Triangle, Rectangle, Circle): ");
            string type = Console.ReadLine();

            if (type == "Triangle")
            {
                Console.Write("Введите катеты (a b): ");
                string[] parts = Console.ReadLine().Split();
                double a = double.Parse(parts[0]);
                double b = double.Parse(parts[1]);
                shapesArray.Add(new Triangle(a, b));
            }
            else if (type == "Rectangle")
            {
                Console.Write("Введите координаты углов (x1 y1 x2 y2): ");
                string[] parts = Console.ReadLine().Split();
                double x1 = double.Parse(parts[0]);
                double y1 = double.Parse(parts[1]);
                double x2 = double.Parse(parts[2]);
                double y2 = double.Parse(parts[3]);
                shapesArray.Add(new Rectangle(x1, y1, x2, y2));
            }
            else if (type == "Circle")
            {
                Console.Write("Введите координаты центра и радиус (x y radius): ");
                string[] parts = Console.ReadLine().Split();
                double x = double.Parse(parts[0]);
                double y = double.Parse(parts[1]);
                double radius = double.Parse(parts[2]);
                shapesArray.Add(new Circle(x, y, radius));
            }
            else
            {
                Console.WriteLine("Некорректный тип фигуры.");
            }
        }

        private void RemoveShape()
        {
            Console.Write("Введите тип фигуры для удаления (Triangle, Rectangle, Circle): ");
            string type = Console.ReadLine();

            for (int i = 0; i < shapesArray.Size; i++)
            {
                Shape shape = shapesArray[i];
                if ((type == "Triangle" && shape is Triangle) ||
                    (type == "Rectangle" && shape is Rectangle) ||
                    (type == "Circle" && shape is Circle))
                {
                    shapesArray.Remove(shape);
                    Console.WriteLine($"{type} удалена.");
                    return;
                }
            }

            Console.WriteLine("Фигура не найдена.");
        }
    }
}
