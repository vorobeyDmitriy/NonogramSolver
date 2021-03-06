using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NonogramSolver.API.Models
{
    public class PuzzleModel
    {
        [Required]
        public int Rows { get; set; }
        [Required]
        public int Columns { get; set; }
        [Required]
        public List<List<int>> VerticalNumbers { get; set; }
        [Required]
        public List<List<int>> HorizontalNumbers { get; set; }
    }
}