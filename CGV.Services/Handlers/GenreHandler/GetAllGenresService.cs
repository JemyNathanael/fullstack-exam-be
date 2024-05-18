using CGV.Contracts.Director.Responses;
using CGV.Contracts.Genre.Requests;
using CGV.Contracts.Genre.Responses;
using CGV.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CGV.Services.Handlers.GenreHandler
{
    public class GetAllGenresService : IRequestHandler<GetAllGenresRequest, GetAllGenresResponse>
    {
        private readonly CinemaDbContext _db;
        public GetAllGenresService(CinemaDbContext db)
        {
            _db = db;
        }
        public async Task<GetAllGenresResponse> Handle(GetAllGenresRequest request, CancellationToken cancellationToken)
        {
            var data = await _db.Genres.Select(Q => new GenreData
            {
                GenreId = Q.Id,
                GenreName = Q.Name
            }).AsNoTracking().ToListAsync();

            var response = new GetAllGenresResponse
            {
                Genres = data
            };

            return response;
        }
    }
}
