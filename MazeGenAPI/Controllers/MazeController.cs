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
        [HttpGet("/")]
        public Maze Generate(uint width,
                             uint height,
                             Algorithm algorithm,
                             char startSymbol = 'O',
                             char endSymbol = 'X',
                             char wallSymbol = '#',
                             char? floorSymbol = null)
        {
            return new Maze(width,
                            height,
                            algorithm,
                            startSymbol,
                            endSymbol,
                            wallSymbol,
                            floorSymbol ?? '\x020');
        }
    }
}
