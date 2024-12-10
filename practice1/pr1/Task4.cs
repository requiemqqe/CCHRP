using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr1
{
    class Task4 : ITask
    {
        public void Execute()
        {
            Console.Write("Введіть останню цифру порядкового номеру: ");

            int groupNumberLastDigit = int.Parse(Console.ReadLine());
            int upperBound = 10 + groupNumberLastDigit;

            int[] X = new int[upperBound];
            Random random = new Random();

            for (int i = 0; i < upperBound; i++)
            {
                X[i] = random.Next(-100, 100);
            }

            Console.WriteLine("Введіть число М:");
            int M = int.Parse(Console.ReadLine());
            int[] Y = X.Where(x => Math.Abs(x) > M).ToArray();

            Console.WriteLine("Число М: " + M);
            Console.WriteLine("Масив X: " + string.Join(", ", X));
            Console.WriteLine("Масив Y: " + string.Join(", ", Y));
        }
    }
}
