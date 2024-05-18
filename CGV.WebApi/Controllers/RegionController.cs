using CGV.Contracts.Region.Request;
using CGV.Contracts.Region.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CGV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<RegionController>
        [HttpGet]
        public async Task<ActionResult<GetAllRegionsResponse>> Get(CancellationToken cancellationToken)
        {
            var request = new GetAllRegionsRequest();
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // GET api/<RegionController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<RegionController>
        [HttpPost]
        public async Task<ActionResult<AddRegionResponse>> Post([FromBody] AddRegionRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        // PUT api/<RegionController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<RegionController>/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
