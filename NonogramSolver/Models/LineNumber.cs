namespace NonogramSolver.Models
{
    public class LineNumber
    {
        public int Number { get; set; }
        private bool IsResolved { get; set; }

        public void Resolve()
        {
            IsResolved = true;
        }

    }
}