using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    class Task2 : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Task 2: Введіть три сторони трикутника:");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            if (a + b > c && a + c > b && b + c > a)
            {
                double perimeter = a + b + c;
                double s = perimeter / 2;
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

                Console.WriteLine("Периметр: " + perimeter);
                Console.WriteLine("Площа: " + area);

                if (a == b && b == c)
                {
                    Console.WriteLine("Трикутник рівносторонній.");
                }
                else if (a == b || a == c || b == c)
                {
                    Console.WriteLine("Трикутник рівнобедрений.");
                }
                else
                {
                    Console.WriteLine("Трикутник різносторонній.");
                }
            }
            else
            {
                Console.WriteLine("Трикутник не існує.");
            }
        }
    }
}
