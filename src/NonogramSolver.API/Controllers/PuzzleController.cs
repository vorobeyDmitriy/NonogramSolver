using Microsoft.AspNetCore.Mvc;
using NonogramSolver.API.Models;
using NonogramSolver.Core.Interfaces;

namespace NonogramSolver.API.Controllers
{
    [ApiController]
    [Route("api/puzzles")]
    public class PuzzleController : ControllerBase
    {
        private readonly IPuzzleSolver _puzzleSolver;
        public PuzzleController(IPuzzleSolver puzzleSolver)
        {
            _puzzleSolver = puzzleSolver;
        }

        [HttpPost("solution")]
        public IActionResult GetSolution(PuzzleModel puzzleModel)
        {
            var puzzle = _puzzleSolver.Solve(puzzleModel.Rows, puzzleModel.Columns, puzzleModel.HorizontalNumbers, 
                puzzleModel.VerticalNumbers);

            return Ok(puzzle.Desk);
        }
    }
}