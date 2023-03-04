namespace VOD.Film.Common.Parameters
{
    public class FilmParameter

    {
        public string? Title { get; set; }
        public string? Director { get; set; }
        public uint MinYear { get; set; } = 0;
        public uint MaxYear { get; set; } = (uint)DateTime.UtcNow.Year;
        public bool Free { get; set; } = default;
        public bool IncludeAll { get; set; }
        public bool GetByGenre { get; set; }
        public bool GetByDirector { get; set; }

    }
}
