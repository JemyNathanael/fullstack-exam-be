using CGV.Contracts.Movie.Requests;
using CGV.Contracts.Movie.Response;
using CGV.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CGV.Services.Handlers.MovieHandler
{
    public class GetUpcomingMoviesHandler : IRequestHandler<GetUpcomingMoviesRequest, GetUpcomingMoviesResponse>
    {
        private readonly CinemaDbContext _db;
        public GetUpcomingMoviesHandler(CinemaDbContext db)
        {
            _db = db;
        }
        public async Task<GetUpcomingMoviesResponse> Handle(GetUpcomingMoviesRequest request, CancellationToken cancellationToken)
        {
            var data = await (from movie in _db.Movies
                              where movie.IsShowing == false
                              select new UpcomingMovie
                              {
                                  MovieId = movie.Id,
                                  PosterUrl = movie.PosterUrl
                              }).AsNoTracking().ToListAsync(cancellationToken);

            var response = new GetUpcomingMoviesResponse
            {
                UpcomingMovieS = data
            };

            return response;
        }
    }
}
