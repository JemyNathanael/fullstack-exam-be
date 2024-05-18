using CGV.Contracts.Region.Request;
using CGV.Contracts.Region.Response;
using CGV.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGV.Services.Handlers.RegionHandler
{
    public class GetAllRegionsHandler : IRequestHandler<GetAllRegionsRequest, GetAllRegionsResponse>
    {
        private readonly CinemaDbContext _db;
        public GetAllRegionsHandler(CinemaDbContext db)
        {
            _db = db;
        }
        public async Task<GetAllRegionsResponse> Handle(GetAllRegionsRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Regions.Select(Q => new RegionData
            {
                RegionId = Q.Id,
                RegionName = Q.Name,
            }).AsNoTracking().ToListAsync();

            var response = new GetAllRegionsResponse
            {
                RegionDatas = data
            };

            return response;
        }
    }
}
