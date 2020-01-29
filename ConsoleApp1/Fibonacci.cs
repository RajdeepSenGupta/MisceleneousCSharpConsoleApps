using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    public static class Fibonacci
    {
        static List<KeyValuePair<double, double>> LookAheadForFibonacci = new List<KeyValuePair<double, double>>();
        public static void FibonacciMain()
        {
            LookAheadForFibonacci = new List<KeyValuePair<double, double>>();
            double n = 40;
            Stopwatch sw = new Stopwatch();

            sw.Reset();
            sw.Start();
            Console.WriteLine("Iteration: " + FibonacciWithIteration(n));
            Console.WriteLine("Time taken: " + sw.Elapsed);
            Console.WriteLine();

            sw.Start();
            Console.WriteLine("Recursion with Dynamic Programming: " + FibonacciWithRecursionWithDynamicProgramming(n));
            sw.Stop();
            Console.WriteLine("Time taken: " + sw.Elapsed);
            Console.WriteLine();

            sw.Start();
            Console.WriteLine("Recursion without Dynamic Programming: " + FibonacciWithRecursionWithoutDynamicProgramming(n));
            sw.Stop();
            Console.WriteLine("Time taken: " + sw.Elapsed);
            Console.WriteLine();
        }

        private static double FibonacciWithRecursionWithoutDynamicProgramming(double n)
        {
            return (n == 0 || n == 1) ? 1 : (FibonacciWithRecursionWithoutDynamicProgramming(n - 1) + FibonacciWithRecursionWithoutDynamicProgramming(n - 2));
        }

        private static double FibonacciWithIteration(double n)
        {
            double x = 0, y = 1;

            for (double i = 0; i < n; i++)
            {
                double z = x + y;
                x = y;
                y = z;
            }

            return y;
        }

        private static double FibonacciWithRecursionWithDynamicProgramming(double n)
        {
            if (n == 0 || n == 1)
            {
                if (!LookAheadForFibonacci.Any(x => x.Key == n))
                    LookAheadForFibonacci.Add(new KeyValuePair<double, double>(n, 1));

                return 1;
            };

            KeyValuePair<double, double> data1 = LookAheadForFibonacci.FirstOrDefault(x => x.Key == n - 1);
            if (data1.Key == 0 && data1.Value == 0)
            {
                double value = FibonacciWithRecursionWithDynamicProgramming(n - 1);
                data1 = new KeyValuePair<double, double>(n, value);
            }

            KeyValuePair<double, double> data2 = LookAheadForFibonacci.FirstOrDefault(x => x.Key == n - 2);
            if (data2.Key == 0 && data2.Value == 0)
            {
                double value = FibonacciWithRecursionWithDynamicProgramming(n - 2);
                data2 = new KeyValuePair<double, double>(n, value);
            }

            LookAheadForFibonacci.Add(new KeyValuePair<double, double>(n, data1.Value + data2.Value));
            return data1.Value + data2.Value;
        }
    }
}
