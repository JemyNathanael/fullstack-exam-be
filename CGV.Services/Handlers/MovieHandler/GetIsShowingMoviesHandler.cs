using CGV.Contracts.Movie.Requests;
using CGV.Contracts.Movie.Response;
using CGV.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CGV.Services.Handlers.MovieHandler
{
    public class GetIsShowingMoviesHandler : IRequestHandler<GetIsShowingMoviesRequest, GetIsShowingMoviiesResponse>
    {
        private readonly CinemaDbContext _db;
        public GetIsShowingMoviesHandler(CinemaDbContext db)
        {
            _db = db;
        }
        public async Task<GetIsShowingMoviiesResponse> Handle(GetIsShowingMoviesRequest request, CancellationToken cancellationToken)
        {
            var data = await (from movie in _db.Movies
                             where movie.IsShowing == true
                             select new IsShowingMovie
                             {
                                 MovieId = movie.Id,
                                 PosterUrl = movie.PosterUrl
                             }).AsNoTracking().ToListAsync(cancellationToken);

            var response = new GetIsShowingMoviiesResponse
            {
                IsShowingMovies = data
            };

            return response;
        }
    }
}
