using CGV.Contracts.Cast.Requests;
using CGV.Contracts.Cast.Responses;
using CGV.Contracts.Director.Responses;
using CGV.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGV.Services.Handlers.CastHandler
{
    public class AddCastHandler : IRequestHandler<AddCastRequest, AddCastResponse>
    {
        private readonly CinemaDbContext _db;
        public AddCastHandler(CinemaDbContext db)
        {
            _db = db;
        }
        public async Task<AddCastResponse> Handle(AddCastRequest request, CancellationToken cancellationToken)
        {
            var cast = new Cast
            {
                Id = Guid.NewGuid(),
                Name = request.CastName,
                CreatedBy = request.CreatedBy,
                UpdatedBy = request.UpdatedBy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _db.Casts.Add(cast);
            await _db.SaveChangesAsync();

            var response = new AddCastResponse
            {
                CastId = cast.Id
            };

            return response;
        }
    }
}
