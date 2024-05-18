using CGV.Contracts.Movie.Requests;
using CGV.Contracts.Movie.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CGV.WebApi.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<MovieController>
        [HttpGet("upcoming")]
        public async Task<ActionResult<GetUpcomingMoviesResponse>> GetUpcomingMovies(CancellationToken cancellationToken)
        {
            var request = new GetUpcomingMoviesRequest();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("showing")]
        public async Task<ActionResult<GetIsShowingMoviiesResponse>> GetIsShowingMovies(CancellationToken cancellationToken)
        {
            var request = new GetIsShowingMoviesRequest();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // GET api/<MovieController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<MovieController>
        [HttpPost]
        public async Task<ActionResult<AddMovieResponse>> Post([FromBody] AddMovieRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // PUT api/<MovieController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<MovieController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
