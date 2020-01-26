namespace NestedLoopsToRecursion
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = 3;

            NestedLoopsWithRecursion(n);
        }

        private static void NestedLoopsWithRecursion(int n)
        {
            PrintNumbers(n, 0, new int[n]);
        }

        private static void PrintNumbers(int n, int index, int[] result)
        {
            if (index == result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    result[index] = i;
                    PrintNumbers(n, index + 1, result);
                }
            }
        }
    }
}
