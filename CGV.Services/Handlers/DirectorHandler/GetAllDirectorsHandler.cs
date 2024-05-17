using CGV.Contracts.Director.Requests;
using CGV.Contracts.Director.Responses;
using CGV.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CGV.Services.Handlers.Director
{
    public class GetAllDirectorsHandler : IRequestHandler<GetAllDirectorsRequest, GetAllDirectorsResponse>
    {
        private readonly CinemaDbContext _db;
        public GetAllDirectorsHandler(CinemaDbContext db)
        {
            _db = db;
        }
        public async Task<GetAllDirectorsResponse> Handle(GetAllDirectorsRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Directors.Select(Q => new DirectorData
            {
                DirectorId = Q.Id,
                DirectorName = Q.Name,
            }).AsNoTracking().ToListAsync();

            var response = new GetAllDirectorsResponse
            {
                DirectorDatas = data
            };

            return response;
        }
    }
}
