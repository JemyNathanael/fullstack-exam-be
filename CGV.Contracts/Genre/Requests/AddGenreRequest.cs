using CGV.Contracts.Genre.Responses;
using MediatR;

namespace CGV.Contracts.Genre.Requests
{
    public class AddGenreRequest : IRequest<AddGenreResponse>
    {
        public string GenreName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string UpdatedBy { get; set; } = null!;
    }
}
