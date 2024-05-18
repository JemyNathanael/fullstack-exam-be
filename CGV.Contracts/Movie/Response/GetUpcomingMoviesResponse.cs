namespace CGV.Contracts.Movie.Response
{
    public class GetUpcomingMoviesResponse
    {
        public List<UpcomingMovie> UpcomingMovieS {  get; set; } = new List<UpcomingMovie>();
    }

    public class UpcomingMovie
    {
        public Guid MovieId { get; set; }
        public string PosterUrl { get; set; } = null!;
    }
}
