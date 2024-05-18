using CGV.Contracts.Director.Requests;
using CGV.Contracts.Director.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CGV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DirectorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<DirectorController>
        [HttpGet]
        public async Task<ActionResult<GetAllDirectorResponse>> Get(CancellationToken cancellationToken)
        {
            var request = new GetAllDirectorsRequest();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // GET api/<DirectorController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<DirectorController>
        [HttpPost]
        public async Task<ActionResult<AddDirectorResponse>> Post([FromBody] AddDirectorRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // PUT api/<DirectorController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<DirectorController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
