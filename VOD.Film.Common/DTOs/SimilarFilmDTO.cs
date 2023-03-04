namespace VOD.Film.Common.DTOs
{
    public class SimilarFilmDTO
    {
        public int SimilarFilmId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? FilmPosterUrl { get; set; }
    }
}
