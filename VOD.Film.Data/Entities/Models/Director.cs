namespace VOD.Film.Data.Entities.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<FilmModel> Film { get; set; } = null!;
    }
}
