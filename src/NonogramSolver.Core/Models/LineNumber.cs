namespace NonogramSolver.Core.Models
{
    public class LineNumber
    {
        public int NumberIndex { get; set; }
        public int Number { get; init; }
        public bool IsResolved { get; private set; }

        public void Resolve()
        {
            IsResolved = true;
        }
    }
}