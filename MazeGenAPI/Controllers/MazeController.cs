using MazeGenAPI.Models;
using MazeGenAPI.Generators;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MazeGenAPI.Controllers
{
    [Route("api/maze")]
    [ApiController]
    public class MazeController : ControllerBase
    {
        // GET: api/maze
        /// <summary>
        /// Generates a random maze using the supplied parameters
        /// </summary>
        /// <param name="corridorsX">The number of corridors in a row (`2 * corridorsX + 1` ASCII characters in a row), defaulting to 10</param>
        /// <param name="corridorsY">The number of corridors in a column (`2 * corridorsY + 1` ASCII characters in a column), defaulting to 10</param>
        /// <param name="algorithm">The algorithm to use, defaulting to `Prim`</param>
        /// <param name="startSymbol">The symbol indicating the starting point (required), defaulting to `O`</param>
        /// <param name="endSymbol">The symbol indicating the goal (required), defaulting to `X`</param>
        /// <param name="wallSymbol">The symbol indicating a wall (required), defaulting to `#`</param>
        /// <param name="floorSymbol">The symbol indicating a walkable cell (optional), defaulting to a space</param>
        /// <returns>A `Maze` object containing the maze's properties and contents</returns>
        [HttpGet]
        public ActionResult<Maze> Generate(uint corridorsX = 10,
                                           uint corridorsY = 10,
                                           Algorithm algorithm = Algorithm.Prim,
                                           char startSymbol = 'O',
                                           char endSymbol = 'X',
                                           char wallSymbol = '#',
                                           char? floorSymbol = null)
        {
            if (corridorsX <= 0)
            {
                return BadRequest("corridorsX must be 1 or larger.");
            }

            if (corridorsY <= 0)
            {
                return BadRequest("corridorsY must be 1 or larger.");
            }

            return new Maze(corridorsX,
                            corridorsY,
                            algorithm,
                            startSymbol,
                            endSymbol,
                            wallSymbol,
                            floorSymbol ?? '\x020');
        }
    }
}
