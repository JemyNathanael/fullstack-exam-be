using CGV.Contracts.Cast.Requests;
using CGV.Contracts.Cast.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CGV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CastController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CastController>
        [HttpGet]
        public async Task<ActionResult<GetAllCastsResponse>> Get(CancellationToken cancellationToken)
        {
            var request = new GetAllCastsRequest();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // GET api/<CastController>/5
        /* [HttpGet("{id}")]
         public string Get(int id)
         {
             return "value";
         }*/

        // POST api/<CastController>
        [HttpPost]
        public async Task<ActionResult<AddCastResponse>> Post([FromBody] AddCastRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // PUT api/<CastController>/5
       /* [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<CastController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
