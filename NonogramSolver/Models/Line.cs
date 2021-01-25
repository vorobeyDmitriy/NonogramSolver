using System.Collections.Generic;

namespace NonogramSolver.Models
{
    public class Line
    {
        public List<Cell> Cells { get; set; }
        public List<int> Numbers { get; set; }
    }
}