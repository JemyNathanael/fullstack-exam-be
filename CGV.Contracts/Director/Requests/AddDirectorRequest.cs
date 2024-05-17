using CGV.Contracts.Director.Responses;
using MediatR;

namespace CGV.Contracts.Director.Requests
{
    public class AddDirectorRequest: IRequest<AddDirectorResponse>
    {
        public string DirectorName { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string UpdatedBy { get; set; } = null!;
    }
}
