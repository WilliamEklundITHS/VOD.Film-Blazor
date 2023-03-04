namespace VOD.Film.Common.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Released { get; set; }
        public bool Free { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? FilmUrl { get; set; }
        public string? FilmPosterUrl { get; set; }
        public int DirectorId { get; set; }
        public DirectorDTO? Director { get; set; }
        public List<SimilarFilmDTO>? SimilarFilms { get; set; }
        public virtual List<GenreDTO>? FilmGenres { get; set; }
    }
}
