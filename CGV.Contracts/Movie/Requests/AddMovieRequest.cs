using CGV.Contracts.Movie.Response;
using MediatR;
using System.Collections;

namespace CGV.Contracts.Movie.Requests
{
    public class AddMovieRequest : IRequest<AddMovieResponse>
    {
        public string MovieTitle { get; set; } = null!;
        public Guid DirectorId { get; set; }
        public Guid GenreId { get; set; }
        public string CensorRating { get; set; } = null!;
        public string Language {  get; set; } = null!;
        public string Subtitle { get; set; } = null!;
        public int Duration { get; set; }
        public string Synopsis { get; set; } = null!;
        public string PosterUrl { get; set; } = null!;
        public string TrailerUrl { get; set; } = null!;
        public bool IsShowing { get; set; } 
        public string CreatedBy { get; set; } = null!;
        public string UpdatedBy { get; set; } = null!;
    }
}
