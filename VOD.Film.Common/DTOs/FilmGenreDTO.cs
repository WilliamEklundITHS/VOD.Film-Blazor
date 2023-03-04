using System.Text.Json.Serialization;

namespace VOD.Film.Common.DTOs
{
    public class FilmGenreDTO
    {
        [JsonIgnore]
        public int FilmId { get; set; }
        [JsonIgnore]
        public FilmDTO Film { get; set; } = new FilmDTO();
        public int GenreId { get; set; }
        public GenreDTO Genre { get; set; } = new GenreDTO();
    }
}
