namespace CGV.Contracts.Genre.Responses
{
    public class GetAllGenresResponse
    {
        public List<GenreData> Genres { get; set; } = new List<GenreData>();
    }

    public class GenreData
    {
        public Guid GenreId { get; set; }
        public string GenreName { get; set; } = null!;
    }
}
