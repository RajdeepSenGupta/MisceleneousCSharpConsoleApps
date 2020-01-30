using System;

namespace ConsoleApp1
{
    public static class SearchingTechniques
    {
        private static int[] InitialArray;
        private static readonly int n = 15;
        private static readonly int minVal = 1;
        private static readonly int maxVal = 20;

        public static void SearchingTechniquesMain()
        {
            /* _____________________________Linear Search____________________________________ */
            linear:
            InitialArray = ArrayHandler.GetPopulatedArray(n, minVal, maxVal);

            Console.WriteLine("Array: \n");
            ArrayHandler.PrintArray(InitialArray);
            Console.WriteLine();

            Console.WriteLine("Linear Search:");

            Console.Write("Enter the element to be found: ");
            if (!int.TryParse(Console.ReadLine(), out int searchElement))
            {
                Console.WriteLine("\nInvalid input. Please try again.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();

                goto linear;
            }

            LinearSearch(searchElement);

            Console.WriteLine("\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            /* _____________________________Binary Search____________________________________ */
            binary:
            InitialArray = ArrayHandler.GetPopulatedArray(n, minVal, maxVal);

            Console.WriteLine("Array: \n");
            ArrayHandler.PrintArray(InitialArray);
            Console.WriteLine();

            Console.WriteLine("Binary Search:");

            Console.Write("Enter the element to be found: ");
            if (!int.TryParse(Console.ReadLine(), out searchElement))
            {
                Console.WriteLine("\nInvalid input. Please try again.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();

                goto binary;
            }

            BinarySearch(SortingTechniques.SortForExternal((int[])InitialArray.Clone()), 0, n - 1, searchElement);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
        }

        /* _____________________________Linear Search____________________________________ */

        private static void LinearSearch(int searchElement)
        {
            bool isFound = false;

            for (int i = 0; i < InitialArray.Length; i++)
            {
                if (searchElement == InitialArray[i])
                {
                    Console.Write("\nElement found at position: " + (i + 1));
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                Console.Write("\nElement not found");
            }
        }

        /* _____________________________Binary Search____________________________________ */

        private static void BinarySearch(int[] arr, int low, int high, int searchElement)
        {
            if(low > high)
            {
                Console.WriteLine("\nElement not found");
                return;
            }
            int mid = (low + high) / 2;

            if (searchElement == arr[mid])
            {
                Console.WriteLine("\nElement found at position: " + (Array.IndexOf(InitialArray, searchElement) + 1));
            }
            else if (searchElement < arr[mid])
            {
                BinarySearch(arr, low, mid, searchElement);
            }
            else
            {
                BinarySearch(arr, mid + 1, high, searchElement);
            }
        }
    }
}
