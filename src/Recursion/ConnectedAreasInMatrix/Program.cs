namespace ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static char[][] matrix;
        private static int totalsAreas;
        private const char Delimiter = '*';
        private const char Dash = '-';
        private const char MarkedCell = '0';
        private static readonly List<Area> areas = new List<Area>();

        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            FindAreas();

            Console.WriteLine($"Total areas found: {totalsAreas}");
            areas
                .OrderByDescending(x => x.Size)
                .ThenBy(x => x.StartRow)
                .ThenBy(x => x.StartRow)
                .Select((x, i) => new Area(x.Size, i + 1, x.StartRow, x.StartCol))
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }

        public static void FindAreas()
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                while (matrix[i].Contains(Dash))
                {
                    var index = Array.IndexOf(matrix[i], Dash);
                    totalsAreas++;
                    var size = 0;
                    FindArea(i, index, ref size);
                    var area = new Area(size, totalsAreas, i, index);
                    areas.Add(area);
                }
            }
        }

        private static void FindArea(int row, int col, ref int size)
        {
            if (!IsInBounds(row, col) || matrix[row][col] == Delimiter || matrix[row][col] == MarkedCell)
            {
                return;
            }

            Mark(row, col, ref size);
            FindArea(row + 1, col, ref size);
            FindArea(row, col + 1, ref size);
            FindArea(row - 1, col, ref size);
            FindArea(row, col - 1, ref size);
        }

        private static void Mark(int row, int col, ref int size)
        {
            if (IsInBounds(row, col) && matrix[row][col] == Dash)
            {
                matrix[row][col] = MarkedCell;
                size++;
            }
        }

        public static void PrintMatrix()
            => matrix
                .ToList()
                .ForEach(x => Console.WriteLine(string.Join("", x)));

        public static bool IsInBounds(int row, int col)
            => row < matrix.Length && row >= 0 &&
            col < matrix[row].Length && col >= 0;
    }
}
