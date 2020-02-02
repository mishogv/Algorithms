namespace ConnectedAreasInMatrix
{
    public class Area
    {
        public Area(int size, int number, int startRow, int startCol)
        {
           this.Size = size;
           this.Number = number;
           this.StartRow = startRow;
           this.StartCol = startCol;
        }

        public int Size { get; set; }

        public int Number { get; set; }

        public int StartRow { get; set; }

        public int StartCol { get; set; }

        public override string ToString()
        {
            return $"Area #{this.Number} at ({this.StartRow}, {this.StartCol}), size: {this.Size}";
        }
    }
}
