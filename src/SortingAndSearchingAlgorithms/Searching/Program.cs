namespace Searching
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

            //var array = Enumerable.Range(1, 1000).ToArray();

            var element = int.Parse(Console.ReadLine());

            var indexOfElement = Find(element, array, 0, array.Length -1);

            Console.WriteLine(indexOfElement);
        }

        private static int Find(int element, int[] array, int startIndex, int endIndex)
        {
            if (array.Length == 0 || startIndex > endIndex)
            {
                return -1;
            }

            if (array[startIndex] == element)
            {
                return startIndex;
            }

            var middleIndex = startIndex + (endIndex - startIndex) / 2;

            if (array[middleIndex] == element)
            {
                return middleIndex;
            }

            if (element > array[middleIndex])
            {
                return Find(element, array, middleIndex + 1, endIndex);
            }

            return Find(element, array, startIndex, middleIndex - 1);
        }
    }
}
