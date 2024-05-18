using CGV.Contracts.Movie.Response;
using MediatR;

namespace CGV.Contracts.Movie.Requests
{
    public class GetIsShowingMoviesRequest : IRequest<GetIsShowingMoviiesResponse>
    {
    }
}
