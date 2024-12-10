using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    class Task1 : ITask
    {
       
        public void Execute()
        {
            Console.Write("Введіть останню цифру порядкового номеру: ");
            int groupNumberLastDigit = int.Parse(Console.ReadLine());
            int upperBound = 10 + groupNumberLastDigit;
            Console.WriteLine("Task 1: Введіть три цілих числа:");
            int[] numbers = new int[3];
            for (int i = 0; i < 3; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            var result = numbers.Where(n => n >= 1 && n <= 10 + upperBound).ToArray();
            Console.WriteLine("Числа, що належать інтервалу [1, " + (upperBound) + "]: " + string.Join(", ", result));
        }
    }
}
