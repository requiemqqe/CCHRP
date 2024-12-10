using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    class Task3 : ITask
    {
        public void Execute()
        {
            Console.Write("Введіть останню цифру порядкового номеру: ");
            int groupNumberLastDigit = int.Parse(Console.ReadLine());
            int upperBound = 10 + groupNumberLastDigit;
            int[] array = new int[upperBound];
            Random random = new Random();
            for (int i = 0; i < upperBound; i++)
            {
                array[i] = random.Next(-100, 100);
            }

            int minValue = array.Min();
            int maxValue = array.Max();

            Console.WriteLine("Масив: " + string.Join(", ", array));
            Console.WriteLine("Мінімальне значення: " + minValue);
            Console.WriteLine("Максимальне значення: " + maxValue);
        }
    }
}
