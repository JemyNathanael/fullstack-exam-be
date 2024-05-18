using CGV.Contracts.Cast.Responses;
using MediatR;

namespace CGV.Contracts.Cast.Requests
{
    public class AddCastRequest: IRequest<AddCastResponse>
    {
        public string CastName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string UpdatedBy { get; set; } = null!;
    }
}
