namespace CombinationWithRepetition
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = 3;
            var k = 2;

            PrintAllCombinations(n, k);
        }

        public static void PrintAllCombinations(int n, int k)
        {
            PrintAllCombinations(n, k, new int[k]);
        }

        private static void PrintAllCombinations(int n, int k, int[] result, int index = 0, int element = 1)
        {
            if (index == result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }
            else
            {
                for (int i = element; i <= n; i++)
                {
                    result[index] = i;
                    PrintAllCombinations(n, k, result, index + 1, i);
                }
            }
        }
    }
}
