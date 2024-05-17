using CGV.Contracts.Movie.Requests;
using CGV.Contracts.Movie.Response;
using CGV.Entities;
using MediatR;

namespace CGV.Services.Handlers.MovieHandler
{
    public class AddMovieHandler : IRequestHandler<AddMovieRequest, AddMovieResponse>
    {
        private readonly CinemaDbContext _db;
        public AddMovieHandler(CinemaDbContext db)
        {
            _db = db;
        }
        public async Task<AddMovieResponse> Handle(AddMovieRequest request, CancellationToken cancellationToken)
        {
            var data = new Movie
            {
                Id = Guid.NewGuid(),
                Title = request.MovieTitle,
                DirectorId = request.DirectorId,
                GenreId = request.GenreId,
                CensorRating = request.CensorRating,
                Duration = request.Duration,
                IsShowing = request.IsShowing,
                Language = request.Language,
                PosterUrl = request.PosterUrl,
                Subtitle = request.Subtitle,
                TrailerUrl = request.TrailerUrl,
                UpdatedBy = request.UpdatedBy,
                CreatedBy = request.CreatedBy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Synopsys = request.Synopsis
            };

            _db.Movies.Add(data);
            await _db.SaveChangesAsync(cancellationToken);

            return new AddMovieResponse
            {
                MovieId = data.Id,
            };
        }
    }
}
