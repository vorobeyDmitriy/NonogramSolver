namespace NonogramSolver.Models
{
    public class LineNumber
    {
        public int Number { get; set; }
        private bool IsResolved { get; set; }
        
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public void Resolve(int start, int end)
        {
            IsResolved = true;
            StartIndex = start;
            EndIndex = end;
        }

    }
}