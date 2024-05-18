using CGV.Contracts.Cast.Requests;
using CGV.Contracts.Cast.Responses;
using CGV.Contracts.Director.Responses;
using CGV.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CGV.Services.Handlers.CastHandler
{
    public class GetAllCastsHandler : IRequestHandler<GetAllCastsRequest, GetAllCastsResponse>
    {
        private readonly CinemaDbContext _db;
        public GetAllCastsHandler(CinemaDbContext db)
        {
            _db = db;
        }
        public async Task<GetAllCastsResponse> Handle(GetAllCastsRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Casts.Select(Q => new CastData
            {
                CastId = Q.Id,
                CastName = Q.Name,
            }).AsNoTracking().ToListAsync();

            var response = new GetAllCastsResponse
            {
                CastDatas = data
            };

            return response;
        }
    }
}
