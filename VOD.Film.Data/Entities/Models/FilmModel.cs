namespace VOD.Film.Data.Entities.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Released { get; set; }
        public bool Free { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? FilmUrl { get; set; }
        public string? FilmPosterUrl { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; } = default!;
        public virtual ICollection<SimilarFilmModel>? SimilarFilms { get; set; }
        public virtual ICollection<FilmGenre> FilmGenres { get; set; } = default!;
    }
}
