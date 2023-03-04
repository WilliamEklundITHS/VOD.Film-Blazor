namespace VOD.Film.Data.Entities.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<FilmGenre> FilmGenres { get; set; } = null!;
    }
}
