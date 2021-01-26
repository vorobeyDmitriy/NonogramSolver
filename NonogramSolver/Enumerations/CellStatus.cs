using System.ComponentModel;

namespace NonogramSolver.Enumerations
{
    public enum CellStatus
    {
        [Description("")]
        Empty,
        [Description("X")]
        Filled,
        [Description("O")]
        Crossed
    }
}