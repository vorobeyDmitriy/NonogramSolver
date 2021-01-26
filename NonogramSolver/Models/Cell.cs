using System.ComponentModel;
using System.Linq;
using NonogramSolver.Enumerations;

namespace NonogramSolver.Models
{
    public class Cell
    {
        public CellStatus Status { get; private set; }

        public void Fill()
        {
            Status = CellStatus.Filled;
        }

        public void Cross()
        {
            Status = CellStatus.Crossed;
        }

        public override string ToString()
        {
            var fieldInfo = Status.GetType().GetField(Status.ToString());

            if (fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
            {
                return attributes.First().Description;
            }

            return Status.ToString();
        }
    }
}