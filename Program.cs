using System;

namespace LabWork
{
    // Asieiev Kostiantyn KN-22 V1

    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 

    /*
        1. Створити клас "Трикутник".
        Створити відповідні методи:

        завдання координат вершин;
        виведення координат вершин на екран;
        обчислення площі.
        Описати похідний від нього клас "Опуклий чотирикутник" з відповідними перевантаженими методами:

        завдання координат вершин;
        виведення координат вершин на екран;
        обчислення площі.
        Створити об'єкти "трикутник" і "опуклий чотирикутник" та обчислити їх площі.
    */


    public class Triangle
    {
        protected double X1, Y1;
        protected double X2, Y2;
        protected double X3, Y3;

        public void SetCoordinates()
        {
            Console.WriteLine("Enter coordinates for the triangle:");
            Console.Write("X1: "); X1 = double.Parse(Console.ReadLine());
            Console.Write("Y1: "); Y1 = double.Parse(Console.ReadLine());
            Console.Write("X2: "); X2 = double.Parse(Console.ReadLine());
            Console.Write("Y2: "); Y2 = double.Parse(Console.ReadLine());
            Console.Write("X3: "); X3 = double.Parse(Console.ReadLine());
            Console.Write("Y3: "); Y3 = double.Parse(Console.ReadLine());
        }

        public void DisplayCoordinates()
        {
            Console.WriteLine($"Triangle vertices: ({X1}, {Y1}), ({X2}, {Y2}), ({X3}, {Y3})");
        }

        public double CalculateArea()
        {
            return Math.Abs((X1 * (Y2 - Y3) + X2 * (Y3 - Y1) + X3 * (Y1 - Y2)) / 2.0);
        }
    }

    public class ConvexQuadrilateral : Triangle
    {
        private double X4, Y4;

        public new void SetCoordinates()
        {
            bool isConvex = false;
            while (!isConvex)
            {
                base.SetCoordinates();
                Console.Write("X4: "); X4 = double.Parse(Console.ReadLine());
                Console.Write("Y4: "); Y4 = double.Parse(Console.ReadLine());

                if (CheckConvexity())
                {
                    isConvex = true;
                }
                else
                {
                    Console.WriteLine("The quadrilateral is not convex. Please enter coordinates again.");
                }
            }
        }

        public new void DisplayCoordinates()
        {
            base.DisplayCoordinates();
            Console.WriteLine($"Fourth vertex: ({X4}, {Y4})");
        }

        public double CalculateArea()
        {
            double area1 = base.CalculateArea();
            double area2 = Math.Abs((X1 * (Y3 - Y4) + X3 * (Y4 - Y1) + X4 * (Y1 - Y3)) / 2.0);
            return area1 + area2;
        }

        private bool CheckConvexity()
        {
            double cross1 = CrossProduct(X1, Y1, X2, Y2, X3, Y3);
            double cross2 = CrossProduct(X2, Y2, X3, Y3, X4, Y4);
            double cross3 = CrossProduct(X3, Y3, X4, Y4, X1, Y1);
            double cross4 = CrossProduct(X4, Y4, X1, Y1, X2, Y2);

            return (cross1 > 0 && cross2 > 0 && cross3 > 0 && cross4 > 0) ||
                   (cross1 < 0 && cross2 < 0 && cross3 < 0 && cross4 < 0);
        }
        private double CrossProduct(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return (x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Triangle:");
            Triangle triangle = new Triangle();
            triangle.SetCoordinates();
            triangle.DisplayCoordinates();
            Console.WriteLine($"Triangle area: {triangle.CalculateArea()}");

            Console.WriteLine("\nConvex Quadrilateral:");
            ConvexQuadrilateral quad = new ConvexQuadrilateral();
            quad.SetCoordinates();
            quad.DisplayCoordinates();
            Console.WriteLine($"Quadrilateral area: {quad.CalculateArea()}");
        }
    }
}



/*
    private void SortVertices()
{
    (double x, double y)[] vertices = { (X1, Y1), (X2, Y2), (X3, Y3), (X4, Y4) };

    double centerX = (X1 + X2 + X3 + X4) / 4.0;
    double centerY = (Y1 + Y2 + Y3 + Y4) / 4.0;

    Array.Sort(vertices, (a, b) =>
    {
        double angleA = Math.Atan2(a.y - centerY, a.x - centerX);
        double angleB = Math.Atan2(b.y - centerY, b.x - centerX);
        return angleA.CompareTo(angleB);
    });

    (X1, Y1) = vertices[0];
    (X2, Y2) = vertices[1];
    (X3, Y3) = vertices[2];
    (X4, Y4) = vertices[3];
}



    public new void SetCoordinates()
{
    base.SetCoordinates();
    Console.Write("X4: "); X4 = double.Parse(Console.ReadLine());
    Console.Write("Y4: "); Y4 = double.Parse(Console.ReadLine());

    SortVertices();

    if (!CheckConvexity())
    {
        Console.WriteLine("The quadrilateral is not convex. Please enter coordinates again.");
        SetCoordinates();
    }
}
*/
