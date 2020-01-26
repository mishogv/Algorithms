namespace ReverseArray
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6 };

            var reversedArray = ReverseArray(array);

            Console.WriteLine(string.Join(", ", reversedArray)); // output : 6, 5, 4, 3, 2, 1
        }

        public static int[] ReverseArray(int[] array)
        {
            var reversedArray = new List<int>();

            Reverse(array, reversedArray, 0);

            return reversedArray.ToArray();
        }

        private static void Reverse(int[] currentArray, List<int> result, int index)
        {
            if (index == currentArray.Length)
            {
                return;
            }

            Reverse(currentArray, result, index + 1);
            result.Add(currentArray[index]);
        }
    }
}
