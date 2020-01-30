using System;
using System.Linq;

namespace ConsoleApp1
{
    public static class ArrayHandler
    {
        /// <summary>
        /// Returns populated array
        /// </summary>
        /// <param name="n"></param>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public static int[] GetPopulatedArray(int size, int minVal, int maxVal)
        {
            int[] array = new int[size];
            Random random = new Random();
            for (int i = 0; i < size;)
            {
                int randomNumber = random.Next(minVal, maxVal + 1);
                if (!array.Any(x => x == randomNumber))
                {
                    array[i] = randomNumber;
                    i++;
                }
            }

            return array;
        }

        /// <summary>
        /// Prints an array
        /// </summary>
        /// <param name="array"></param>
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write("   " + array[i]);

            Console.WriteLine();
        }

        /// <summary>
        /// Swaps the elements of an array of the given indices
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static int[] SwapArrayElements(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;

            return array;
        }
    }
}
