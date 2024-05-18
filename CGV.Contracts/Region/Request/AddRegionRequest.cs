using CGV.Contracts.Region.Response;
using MediatR;

namespace CGV.Contracts.Region.Request
{
    public class AddRegionRequest : IRequest<AddRegionResponse>
    {
        public string RegionName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string UpdatedBy { get; set; } = null!;
    }
}
