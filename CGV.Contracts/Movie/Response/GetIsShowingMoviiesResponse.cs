using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGV.Contracts.Movie.Response
{
    public class GetIsShowingMoviiesResponse
    {
        public List<IsShowingMovie> IsShowingMovies { get; set; } = new List<IsShowingMovie>();
    }

    public class IsShowingMovie
    {
        public Guid MovieId { get; set; }
        public string PosterUrl { get; set; } = null!;
    }
}
