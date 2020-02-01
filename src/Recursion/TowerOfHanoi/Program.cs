namespace TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static Stack<int> spare = new Stack<int>();
        public static Stack<int> destination = new Stack<int>();
        public static Stack<int> source = new Stack<int>();

        public static int stepsTaken = 0;
        public static void Main()
        {
            var disks = int.Parse(Console.ReadLine());
            var range = Enumerable.Range(1, disks);
            source = new Stack<int>(Enumerable.Range(1, disks).Reverse());
            PrintRoads();
            MoveDisks(disks, source, destination, spare);
        }
            
        public static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                stepsTaken++;
                destination.Push(source.Pop());
                PrintStepWithRoads(bottomDisk);
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                stepsTaken++;
                destination.Push(source.Pop());
                PrintStepWithRoads(bottomDisk);
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }

        private static void PrintStepWithRoads(int diskNumber)
        {
            Console.WriteLine($"Step #{stepsTaken}: Moved disk {diskNumber}");
            PrintRoads();
        }

        private static void PrintRoads()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }
    }
}
