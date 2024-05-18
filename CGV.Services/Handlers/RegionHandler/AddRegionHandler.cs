using CGV.Contracts.Region.Request;
using CGV.Contracts.Region.Response;
using CGV.Entities;
using MediatR;

namespace CGV.Services.Handlers.RegionHandler
{
    public class AddRegionHandler : IRequestHandler<AddRegionRequest, AddRegionResponse>
    {
        private readonly CinemaDbContext _db;
        public AddRegionHandler(CinemaDbContext db)
        {
            _db = db;
        }
        public async Task<AddRegionResponse> Handle(AddRegionRequest request, CancellationToken cancellationToken)
        {
            var region = new Region
            {
                Id = Guid.NewGuid(),
                Name = request.RegionName,
                CreatedBy = request.CreatedBy,
                UpdatedBy = request.UpdatedBy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _db.Regions.Add(region);
            await _db.SaveChangesAsync();

            return new AddRegionResponse
            {
                RegionId = region.Id,
                CreatedAt = region.CreatedAt,
                UpdatedAt = region.UpdatedAt
            };
        }
    }
}
