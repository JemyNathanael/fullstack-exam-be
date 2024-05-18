using CGV.Contracts.Genre.Requests;
using CGV.Contracts.Genre.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CGV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<GenreController>
        [HttpGet]
        public async Task<ActionResult<GetAllGenresResponse>> Get(CancellationToken cancellationToken)
        {
            var request = new GetAllGenresRequest();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // GET api/<GenreController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<GenreController>
        [HttpPost]
        public async Task<ActionResult<AddGenreResponse>> Post([FromBody] AddGenreRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // PUT api/<GenreController>/5
       /* [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<GenreController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
