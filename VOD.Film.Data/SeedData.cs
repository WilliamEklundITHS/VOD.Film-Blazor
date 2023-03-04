using VOD.Film.Data.Entities.Models;

namespace VOD.Film.Data
{
    public static class SeedData
    {
        public static Director[] CreateDirectors()
        {
            Director[] directors = new Director[] {
                new Director
                {
                    Id = 1,
                    Name = "James Cameron"
                },
                new Director
                {
                    Id = 2,
                    Name = "Christopher Nolan"

                },
                new Director
                {
                    Id = 3,
                    Name = "Steven Spielberg",
                },
                new Director
                {
                    Id = 4,
                    Name = "Quentin Tarantino"
                },
                new Director
                {
                    Id = 5,
                    Name = "Martin Scorsese"
                }
            };
            return directors;
        }
        public static Genre[] CreateGenres()
        {
            Genre[] genres = new Genre[] {
                   new Genre
                {
                    Id = 1,
                    Name = "Action"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Adventure"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Drama"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Comedy"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Crime"
                }

            };
            return genres;
        }

        public static FilmModel[] CreateFilmModels()
        {
            FilmModel[] FilmModels = new FilmModel[]
            {
                new FilmModel
                {
                    Id = 1,
                    Title = "Avatar",
                    Released = new DateTime(2009, 12, 18),
                    Free = true,
                    Description = "A paraplegic marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.",
                    FilmUrl = "https://www.youtube.com/watch?v=5PSNL1qE6VY",
                    FilmPosterUrl = "https://i.ebayimg.com/images/g/CwEAAOSwv4xf5cdv/s-l1600.jpg",
                    DirectorId = 1,
                },
                new FilmModel
                {
                    Id = 2,
                    Title = "The Dark Knight",
                    Released = new DateTime(2008, 7, 18),
                    DirectorId = 2,
                    Free = false,
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, the caped crusader must come to terms with one of the greatest psychological tests of his ability to fight injustice.",
                    FilmUrl = "https://www.youtube.com/watch?v=EXeTwQWrcwY",
                    FilmPosterUrl = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_.jpg"
                },
                new FilmModel
                {
                    Id = 3,
                    Title = "Jurassic Park",
                    Released = new DateTime(1993, 6, 11),
                    DirectorId = 3,
                    Free = true,
                    Description = "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                    FilmUrl = "https://www.youtube.com/watch?v=lc0UehYemQA",
                    FilmPosterUrl = "https://m.media-amazon.com/images/M/MV5BMjM2MDgxMDg0Nl5BMl5BanBnXkFtZTgwNTM2OTM5NDE@._V1_.jpg"
                },
                new FilmModel
                {
                    Id = 4,
                    Title = "The Shawshank Redemption",
                    Released = new DateTime(1994, 9, 14),
                    DirectorId = 3,
                    Free = false,
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    FilmUrl = "https://www.youtube.com/watch?v=NmzuHjWmXOc",
                    FilmPosterUrl = "https://m.media-amazon.com/images/M/MV5BMDFkYTc0MGEtZmNhMC00ZDIzLWFmNTEtODM1ZmRlYWMwMWFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_FMjpg_UX1000_.jpg"
                },
            new FilmModel
            {
                Id = 5,
                Title = "The Godfather",
                Released = new DateTime(1972, 3, 24),
                DirectorId = 1,
                Free = false,
                Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                FilmUrl = "https://www.youtube.com/watch?v=UaVTIH8mujA",
                FilmPosterUrl = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg"
            },
            new FilmModel
            {
                Id = 6,
                Title = "Inception",
                Released = new DateTime(2010, 7, 16),
                DirectorId = 2,
                Free = false,
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
                FilmUrl = "https://www.youtube.com/watch?v=YoHD9XEInc0",
                FilmPosterUrl = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_.jpg"

            },
           new FilmModel
            {
                Id = 7,
                Title = "12 Angry Men",
                Released = new DateTime(1957, 4, 10),
                DirectorId = 4,
                Free = false,
                Description = "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.",
                FilmUrl = "https://www.youtube.com/watch?v=TEN-2uTi2c0",
                FilmPosterUrl = "https://upload.wikimedia.org/wikipedia/commons/b/b5/12_Angry_Men_%281957_film_poster%29.jpg"

            },
            new FilmModel
            {
                Id = 8,
                Title = "Schindler's List",
                Released = new DateTime(1993, 11, 30),
                DirectorId = 5,
                Free = false,
                Description = "In German-occupied Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazi Germans.",
                FilmUrl = "https://www.youtube.com/watch?v=gG22XNhtnoY",
                FilmPosterUrl ="https://m.media-amazon.com/images/M/MV5BNDE4OTMxMTctNmRhYy00NWE2LTg3YzItYTk3M2UwOTU5Njg4XkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg"

            },
            new FilmModel
            {
                Id = 9,
                Title = "The Lord of the Rings: The Return of the King",
                Released = new DateTime(2003, 12, 17),
                DirectorId = 5,
                Free = false,
                Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                FilmUrl = "https://www.youtube.com/watch?v=r5X-hFf6Bwo",
                FilmPosterUrl = "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg"
            },
            new FilmModel
            {
                Id = 10,
                Title = "Pulp Fiction",
                Released = new DateTime(1994, 9, 14),
                DirectorId = 4,
                Free = false,
                Description = "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                FilmUrl = "https://www.youtube.com/watch?v=s7EdQ4FqbhY",
                FilmPosterUrl = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg"
            },
            new FilmModel
            {
                Id = 11,
                Title = "The Good, the Bad and the Ugly",
                Released = new DateTime(1966, 12, 29),
                DirectorId = 1,
                Free = false,
                Description = "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                FilmUrl = "https://www.youtube.com/watch?v=IFNUGzCOQoI",
                FilmPosterUrl = "https://m.media-amazon.com/images/M/MV5BNjJlYmNkZGItM2NhYy00MjlmLTk5NmQtNjg1NmM2ODU4OTMwXkEyXkFqcGdeQXVyMjUzOTY1NTc@._V1_.jpg"
            },
            new FilmModel
            {
                Id = 12,
                Title = "Forest Gump",
                Released = new DateTime(1994, 7, 6),
                DirectorId = 2,
                Free = false,
                Description = "Forrest Gump, while not intelligent, has accidentally been present at many historic moments, but his true love, Jenny Curran, eludes him.",
                FilmUrl = "https://www.youtube.com/watch?v=bLvqoHBptjg",
                FilmPosterUrl = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg"
            },
             new FilmModel
                {
                    Id = 13,
                    Title = "Goodfellas",
                    Released = new DateTime(1990, 9, 19),
                    DirectorId = 5,
                    Free = false,
                    Description = "The story of Henry Hill and his life in the mafia, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.",
                    FilmUrl = "https://www.youtube.com/watch?v=qo5jJpHtI1Y",
                    FilmPosterUrl = "https://upload.wikimedia.org/wikipedia/en/7/7b/Goodfellas.jpg",
             }

        };
            return FilmModels;
        }
        public static SimilarFilmModel[] CreateSimilarFilmModels()
        {
            SimilarFilmModel[] SimilarFilmModels = new[]
            {
                 new SimilarFilmModel
                {
                    ParentFilmId = 1,
                    SimilarFilmId = 2,
                },
                  new SimilarFilmModel
                {
                    ParentFilmId = 1,
                    SimilarFilmId =4,
                },
                new SimilarFilmModel
                {
                    ParentFilmId = 2,
                    SimilarFilmId = 3
                },
                new SimilarFilmModel
                {
                    ParentFilmId = 3,
                    SimilarFilmId = 1
                },
                new SimilarFilmModel
                {
                    ParentFilmId = 4,
                    SimilarFilmId = 5
                },
                     new SimilarFilmModel
                {
                    ParentFilmId = 5,
                    SimilarFilmId =11,
                },
                new SimilarFilmModel
                {
                    ParentFilmId = 5,
                    SimilarFilmId = 6
                },
                new SimilarFilmModel
                {
                    ParentFilmId = 11,
                    SimilarFilmId = 4
                },
                   new SimilarFilmModel
                {
                    ParentFilmId = 4,
                    SimilarFilmId = 7
                },
                new SimilarFilmModel
                {
                    ParentFilmId = 5,
                    SimilarFilmId = 8
                },
                new SimilarFilmModel
                {
                    ParentFilmId = 6,
                    SimilarFilmId = 5
                },
                  new SimilarFilmModel
                {
                    ParentFilmId = 13,
                    SimilarFilmId = 5
                },
                     new SimilarFilmModel
                {
                    ParentFilmId = 13,
                    SimilarFilmId = 4
                }

            };
            return SimilarFilmModels;
        }

        public static FilmGenre[] CreateFilmGenres()
        {
            var FilmGenres = new FilmGenre[]
            {
                 new FilmGenre
                {
                    FilmId = 1,
                    GenreId = 1
                },
                new FilmGenre
                {
                    FilmId = 1,
                    GenreId = 2
                },
                new FilmGenre
                {
                    FilmId = 2,
                    GenreId = 1
                },
                new FilmGenre
                {
                    FilmId = 4,
                    GenreId = 3
                },
                new FilmGenre
                {
                    FilmId = 4,
                    GenreId = 4
                },
                new FilmGenre
                {
                    FilmId = 5,
                    GenreId = 5
                },
                new FilmGenre
                {
                    FilmId = 6,
                    GenreId = 1
                },
                new FilmGenre
                {
                    FilmId = 6,
                    GenreId = 2
                },
                 new FilmGenre
                {
                    FilmId = 7,
                    GenreId = 1
                },
                  new FilmGenre
                {
                    FilmId = 7,
                    GenreId = 2
                },
                   new FilmGenre
                {
                    FilmId = 8,
                    GenreId = 5
                },
                      new FilmGenre
                {
                    FilmId = 8,
                    GenreId = 1
                },
                 new FilmGenre
                {
                    FilmId = 9,
                    GenreId = 3
                },
                new FilmGenre
                {
                    FilmId = 10,
                    GenreId = 4
                },
                new FilmGenre
                {
                    FilmId = 11,
                    GenreId = 2
                },
                new FilmGenre
                {
                    FilmId = 11,
                    GenreId = 4
                }
                ,
                new FilmGenre
                {
                    FilmId = 12,
                    GenreId = 2
                },
                new FilmGenre
                {
                    FilmId = 12,
                    GenreId = 5
                },
                new FilmGenre
                {
                    FilmId = 13,
                    GenreId = 3
                },
                new FilmGenre
                {
                    FilmId = 13,
                    GenreId = 1
                }

            };
            return FilmGenres;
        }
    }
}