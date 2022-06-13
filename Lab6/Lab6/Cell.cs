#nullable enable

namespace Lab6
{
    public class Cell
    {
        public Cell(char value)
        {
            Value = value;
        }
        
        private char Value { get; }
        public Cell? LeftLeaf { get; set; }
        public Cell? RightLeaf { get; set; }
        public override string ToString() => $"{Value}";
    }
}