namespace VOD.Film.Data.Entities.Models
{
    public class SimilarFilmModel
    {
        public int ParentFilmId { get; set; }
        public FilmModel ParentFilm { get; set; } = null!;
        public int SimilarFilmId { get; set; }
        public FilmModel SimilarFilm { get; set; } = null!;
    }
}
