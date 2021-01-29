using System.ComponentModel;

namespace NonogramSolver.Core.Enumerations
{
    public enum CellStatus
    {
        [Description(".")]
        Empty,
        [Description("X")]
        Filled,
        [Description("O")]
        Crossed
    }
}