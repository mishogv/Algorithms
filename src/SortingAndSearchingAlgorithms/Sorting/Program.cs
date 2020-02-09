namespace Sorting
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine()?
                               .Split(' ')
                               .Select(int.Parse)
                               .ToArray();

            MergeSort(array, 0, array.Length - 1);

            Console.WriteLine(string.Join(" ", array));
        }

        private static void MergeSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var middle = start + (end - start) / 2;

            MergeSort(array, start, middle);
            MergeSort(array, middle + 1, end);

            Merge(array, start, middle, end);
        }

        private static void Merge(int[] array, int start, int middle, int end)
        {
            if (array.Length == 0)
            {
                return;
            }

            var firstArrElementsCount = middle - start + 1;
            var secondArrElementsCount = end - middle;

            var firstTempArray = new int[firstArrElementsCount]; 
            for (int n = 0; n < firstArrElementsCount; n++)
            {
                firstTempArray[n] = array[start + n];
            }
            var secondTempArray = new int[secondArrElementsCount];
            for (int n = 0; n < secondArrElementsCount; n++)
            {
                secondTempArray[n] = array[middle + 1 + n];
            }

            var i = 0;
            var j = 0;
            var k = start;
            while (i < firstArrElementsCount && j < secondArrElementsCount)
            {
                if (firstTempArray[i] <= secondTempArray[j])
                {
                    array[k] = firstTempArray[i];
                    i++;
                }
                else
                {
                    array[k] = secondTempArray[j];
                    j++;
                }
                k++;
            }

            while (i < firstArrElementsCount)
            {
                array[k] = firstTempArray[i];
                i++;
                k++;
            }

            while (j < secondArrElementsCount)
            {
                array[k] = secondTempArray[j];
                j++;
                k++;
            }
        }
    }
}
