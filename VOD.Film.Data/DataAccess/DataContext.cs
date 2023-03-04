using Microsoft.EntityFrameworkCore;
using VOD.Film.Data.Entities.Models;

namespace VOD.Film.Data.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<FilmModel> Films { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<SimilarFilmModel> SimilarFilms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.EnableDetailedErrors(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<FilmModel>()
                .Property(f => f.Title)
                .HasMaxLength(50);

            modelBuilder.Entity<FilmModel>()
              .Property(f => f.Description)
              .HasMaxLength(200);

            modelBuilder.Entity<FilmModel>()
              .Property(f => f.FilmUrl)
              .HasMaxLength(1024);

            modelBuilder.Entity<FilmModel>()
             .Property(f => f.FilmPosterUrl)
             .HasMaxLength(1024);

            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Director>()
              .Property(d => d.Name)
              .HasMaxLength(50);


            //modelBuilder.Entity<FilmModel>().HasKey(f => f.Id);
            //modelBuilder.Entity<FilmModel>()
            //    .HasOne(d => d.Director)
            //    .WithMany(f => f.Film)
            //    .HasForeignKey(f => f.DirectorId);

            modelBuilder.Entity<SimilarFilmModel>()
           .HasKey(x => new { x.ParentFilmId, x.SimilarFilmId });

            modelBuilder.Entity<SimilarFilmModel>()
          .HasOne(sf => sf.ParentFilm)
          .WithMany(f => f.SimilarFilms)
          .HasForeignKey(sf => sf.ParentFilmId)
          .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SimilarFilmModel>()
                .HasOne(sf => sf.SimilarFilm)
                .WithMany()
                .HasForeignKey(sf => sf.SimilarFilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            //FilmGenre
            //modelBuilder.Entity<SimilarFilmModel>().Navigation(e => e.SimilarFilm).AutoInclude();
            //modelBuilder.Entity<FilmGenre>().Navigation(e => e.Genre).AutoInclude();
            modelBuilder.Entity<FilmGenre>()
            .HasKey(fg => new { fg.FilmId, fg.GenreId });

            modelBuilder.Entity<FilmGenre>()
                .HasOne(fg => fg.Film)
                .WithMany(f => f.FilmGenres)
                .HasForeignKey(fg => fg.FilmId);

            modelBuilder.Entity<FilmGenre>()
               .HasOne(fg => fg.Genre)
               .WithMany(g => g.FilmGenres)
               .HasForeignKey(fg => fg.GenreId);

            modelBuilder.Entity<Director>().HasData(SeedData.CreateDirectors());
            modelBuilder.Entity<Genre>().HasData(SeedData.CreateGenres());
            modelBuilder.Entity<FilmModel>().HasData(SeedData.CreateFilmModels());
            modelBuilder.Entity<SimilarFilmModel>().HasData(SeedData.CreateSimilarFilmModels());
            modelBuilder.Entity<FilmGenre>().HasData(SeedData.CreateFilmGenres());

        }
    }

}