namespace NonogramSolver.Core.Models
{
    public class LineNumber
    {
        public int NumberIndex { get; set; }
        public int Number { get; set; }
        public bool IsResolved { get; private set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public void Resolve(int start, int end)
        {
            IsResolved = true;
            StartIndex = start;
            EndIndex = end;
        }
        
        public void Resolve()
        {
            IsResolved = true;
        }
    }
}