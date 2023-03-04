namespace VOD.Film.Common.DTOs
{
    public class FilmRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public DateTime Released { get; set; }
        public bool Free { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? FilmUrl { get; set; }
        public string? FilmPosterUrl { get; set; }
        public int DirectorId { get; set; } = 1;
        public int[] GenreIds { get; set; } = Array.Empty<int>();
        public int[] SimilarFilmsIds { get; set; } = Array.Empty<int>();
    }
}
