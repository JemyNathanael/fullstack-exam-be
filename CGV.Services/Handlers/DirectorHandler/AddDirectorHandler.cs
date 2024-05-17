using CGV.Contracts.Director.Requests;
using CGV.Contracts.Director.Responses;
using CGV.Entities;
using MediatR;
namespace CGV.Services.Handlers.DirectorHandler
{
    public class AddDirectorHandler : IRequestHandler<AddDirectorRequest, AddDirectorResponse>
    {
        private readonly CinemaDbContext _db;
        public AddDirectorHandler(CinemaDbContext db)
        {
            _db = db;
        }
        public async Task<AddDirectorResponse> Handle(AddDirectorRequest request, CancellationToken cancellationToken)
        {
            var director = new Entities.Director
            {
                Id = Guid.NewGuid(),
                Name = request.DirectorName,
                CreatedBy = request.CreatedBy,
                UpdatedBy = request.UpdatedBy,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _db.Directors.Add(director);
            await _db.SaveChangesAsync();

            var response = new AddDirectorResponse
            {
                DirectorId = director.Id
            };

            return response;
        }
    }
}
