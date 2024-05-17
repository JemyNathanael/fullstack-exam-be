using CGV.Contracts.Genre.Requests;
using CGV.Contracts.Genre.Responses;
using CGV.Entities;
using MediatR;

namespace CGV.Services.Handlers.GenreHandler
{
    public class AddGenreHandler : IRequestHandler<AddGenreRequest, AddGenreResponse>
    {
        private readonly CinemaDbContext _db;
        public AddGenreHandler(CinemaDbContext db)
        {
            _db = db;
        }
        public async Task<AddGenreResponse> Handle(AddGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = request.GenreName,
                CreatedBy = request.CreatedBy,
                UpdatedBy = request.UpdatedBy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _db.Genres.Add(genre);
            await _db.SaveChangesAsync(cancellationToken);

            return new AddGenreResponse
            {
                GenreId = genre.Id,
            };
        }
    }
}
