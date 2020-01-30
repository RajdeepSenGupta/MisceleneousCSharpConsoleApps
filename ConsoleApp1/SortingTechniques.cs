using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    // No Repeated Values
    // Sorted ascendingly
    public static class SortingTechniques
    {
        private static int[] InitialArray;
        private static readonly int n = 15;
        private static readonly int minVal = 1;
        private static readonly int maxVal = 20;

        public static void SortingTechniquesMain()
        {
            Stopwatch sw = new Stopwatch();

            /* _____________________________Bubble Sort____________________________________ */
            InitialArray = ArrayHandler.GetPopulatedArray(n, minVal, maxVal);

            Console.WriteLine("Initial Array: \n");
            ArrayHandler.PrintArray(InitialArray);
            Console.WriteLine();

            Console.WriteLine("Bubble Sort: \n");
            sw.Start();
            BubbleSort();

            Console.WriteLine("\nTime taken: " + sw.Elapsed);
            sw.Reset();
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            /* _____________________________Selection Sort____________________________________ */
            InitialArray = ArrayHandler.GetPopulatedArray(n, minVal, maxVal);

            Console.WriteLine("Initial Array: \n");
            ArrayHandler.PrintArray(InitialArray);
            Console.WriteLine();

            Console.WriteLine("Selection Sort: \n");
            sw.Start();
            SelectionSort();

            Console.WriteLine("\nTime taken: " + sw.Elapsed);
            sw.Reset();
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            /* _____________________________Insertion Sort____________________________________ */
            InitialArray = ArrayHandler.GetPopulatedArray(n, minVal, maxVal);

            Console.WriteLine("Initial Array: \n");
            ArrayHandler.PrintArray(InitialArray);
            Console.WriteLine();

            Console.WriteLine("Insertion Sort: \n");
            sw.Start();
            InsertionSort();

            Console.WriteLine("\nTime taken: " + sw.Elapsed);
            sw.Reset();
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            /* _____________________________Merge Sort____________________________________ */
            InitialArray = ArrayHandler.GetPopulatedArray(n, minVal, maxVal);

            Console.WriteLine("Initial Array: \n");
            ArrayHandler.PrintArray(InitialArray);
            Console.WriteLine();

            Console.WriteLine("Merge Sort: \n");
            sw.Start();
            MergeSort(0, n - 1);

            Console.WriteLine("\nTime taken: " + sw.Elapsed);
            sw.Reset();
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            /* _____________________________Quick Sort____________________________________ */
            InitialArray = ArrayHandler.GetPopulatedArray(n, minVal, maxVal);

            Console.WriteLine("Initial Array: \n");
            ArrayHandler.PrintArray(InitialArray);
            Console.WriteLine();

            Console.WriteLine("Quick Sort: \n");
            sw.Start();
            QuickSort(0, n - 1, true);

            Console.WriteLine("\nTime taken: " + sw.Elapsed);
            sw.Reset();
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to continue...");
        }

        public static int[] SortForExternal(int[] array)
        {
            InitialArray = array;
            QuickSort(0, array.Length - 1, false);
            return InitialArray;
        }

        /* _____________________________Bubble Sort____________________________________ */

        // Largest goes at the last position
        private static void BubbleSort()
        {
            for (int i = n - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (InitialArray[i] < InitialArray[j])
                        ArrayHandler.SwapArrayElements(InitialArray, i, j);
                }

                ArrayHandler.PrintArray(InitialArray);
            }
        }

        /* _____________________________Selection Sort____________________________________ */

        // Smallest goes at the first position
        private static void SelectionSort()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (InitialArray[i] > InitialArray[j])
                        ArrayHandler.SwapArrayElements(InitialArray, i, j);
                }
                ArrayHandler.PrintArray(InitialArray);
            }
        }

        /* _____________________________Insertion Sort____________________________________ */

        // Element goes at its proper position
        private static void InsertionSort()
        {
            for (int i = 1; i < n; i++)
            {
                int key = InitialArray[i];
                int j = i - 1;

                /* Move elements of arr[0..i-1], that are greater than key, to one position ahead of their current position */
                while (j >= 0 && InitialArray[j] > key)
                {
                    InitialArray[j + 1] = InitialArray[j];
                    j = j - 1;
                }
                InitialArray[j + 1] = key;

                ArrayHandler.PrintArray(InitialArray);
            }
        }

        /* _____________________________Merge Sort____________________________________ */

        // Divide and Conquer (1)
        private static void MergeSort(int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                //int mid = low + (high - low) / 2;

                MergeSort(low, mid);
                MergeSort(mid + 1, high);

                Merge(low, mid, high);
                ArrayHandler.PrintArray(InitialArray);
            }
        }

        private static void Merge(int low, int mid, int high)
        {
            int i, j, k;
            int n1 = mid - low + 1;
            int n2 = high - mid;

            // Create temp arrays
            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            // Copy data to temp arrays L[] and R[]
            for (i = 0; i < n1; i++)
                leftArr[i] = InitialArray[low + i];

            for (j = 0; j < n2; j++)
                rightArr[j] = InitialArray[mid + 1 + j];

            // Merge the temp arrays back into arr[l..r]
            i = 0;        // Initial index of first subarray 
            j = 0;        // Initial index of second subarray 
            k = low;      // Initial index of merged subarray 

            while (i < n1 && j < n2)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    InitialArray[k] = leftArr[i];
                    i++;
                }
                else
                {
                    InitialArray[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            // Copy the remaining elements of L[], if there are any
            while (i < n1)
            {
                InitialArray[k] = leftArr[i];
                i++;
                k++;
            }

            // Copy the remaining elements of R[], if there are any
            while (j < n2)
            {
                InitialArray[k] = rightArr[j];
                j++;
                k++;
            }
        }

        /* _____________________________Quick Sort____________________________________ */

        // Divide and Conquer (2)
        private static void QuickSort(int low, int high, bool toBePrinted)
        {
            if (low < high)
            {
                // pi is partitioning index, InitialArray[p] is now at right place
                int pi = Partition(low, high);

                // Separately sort elements before partition and after partition  
                QuickSort(low, pi - 1, toBePrinted);
                QuickSort(pi + 1, high, toBePrinted);

                if (toBePrinted)
                    ArrayHandler.PrintArray(InitialArray);
            }
        }

        private static int Partition(int low, int high)
        {
            int pivot = InitialArray[high];             // pivot  
            int i = low - 1;                            // Index of smaller element  

            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller than the pivot  
                if (InitialArray[j] < pivot)
                {
                    i++;                                // increment index of smaller element  
                    ArrayHandler.SwapArrayElements(InitialArray, i, j);
                }
            }

            ArrayHandler.SwapArrayElements(InitialArray, i + 1, high);
            return i + 1;
        }
    }
}
