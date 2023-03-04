namespace VOD.Film.Data.Entities.Models
{
    public class FilmGenre
    {
        public int FilmId { get; set; }
        public FilmModel Film { get; set; } = null!;
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
    }
}
