﻿using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static CinemaApp.Data.Common.EntityConstants.Movie;

namespace CinemaApp.Data.Configuration
{
    public class MovieConfigration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> entity)
        {
            entity
                .HasKey(m => m.Id);

            entity
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            entity
                .Property(m => m.Genre)
                .IsRequired()
                .HasMaxLength(GenreMaxLength);

            entity
                .Property(m => m.ReleaseDate)
                .IsRequired();

            entity
                .Property(m => m.Director)
                .IsRequired()
                .HasMaxLength(DirectorNameMaxLength);

            entity
                .Property(m => m.Duration)
                .IsRequired();

            entity
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            entity
                .Property(m => m.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(m => m.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            entity
                .HasData(this.SeedMovies());
        }

        private List<Movie> SeedMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie
                {
                    Id = Guid.Parse("4571bf2f-dbb3-446c-a92a-07cb77f47ed0"),
                    Title = "Inception",
                    Genre = "Sci-Fi",
                    ReleaseDate = new DateOnly(2010, 07, 16),
                    Director = "Christopher Nolan",
                    Duration = 148,
                    Description = "A skilled thief is given a chance at redemption if he can successfully perform an inception on a target's mind.",
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0057/3728/3618/files/inception.mpw.123395_9e0000d1-bc7f-400a-b488-15fa9e60a10c_500x749.jpg?v=1708527589",
                },
                new Movie
                {
                    Id = Guid.Parse("e673a37c-8ffc-46bf-a66d-18b8078d7c94"),
                    Title =  "The Godfather",
                    Genre = "Crime",
                    ReleaseDate = new DateOnly(1972, 03, 24),
                    Director =  "Francis Ford Coppola",
                    Duration = 175,
                    Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/products/b5282f72126e4919911509e034a61f66_6ce2486d-e0da-4b7a-9148-722cdde610b8_480x.progressive.jpg?v=1573616025"
                },
                new Movie
                {
                    Id = Guid.Parse("2f22c0dd-f7b9-46c3-a753-0d076dafb489"),
                    Title =  "Interstellar",
                    Genre = "Adventure",
                    ReleaseDate = new DateOnly(2014, 11, 07),
                    Director =  "Christopher Nolan",
                    Duration = 169,
                    Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/files/interstellar-139399_480x.progressive.jpg?v=1708527823"
                },
                new Movie
                {
                    Id = Guid.Parse("eb13b5e6-b8fd-4e11-99ef-446e9e752558"),
                    Title =  "The Dark Knight",
                    Genre = "Action",
                    ReleaseDate = new DateOnly(2008 , 07, 18),
                    Director =  "Christopher Nolan",
                    Duration = 152,
                    Description = "Batman faces the Joker, a criminal mastermind bent on causing chaos in Gotham City.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/files/darkknight.building.24x36_20e90057-f673-4cc3-9ce7-7b0d3eeb7d83_480x.progressive.jpg?v=1707491191"
                },
                new Movie
                {
                    Id = Guid.Parse("94e73f37-e260-4c6f-930b-8bd65c9c8a11"),
                    Title =  "Pulp Fiction",
                    Genre = "Crime",
                    ReleaseDate = new DateOnly(1994,10,14),
                    Director =  "Quentin Tarantino",
                    Duration = 154,
                    Description = "The lives of two mob hitmen, a boxer, and others intertwine in a series of unexpected incidents.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/products/pulpfiction.2436_480x.progressive.jpg?v=1620048742"
                },
                new Movie
                {
                    Id = Guid.Parse("96fcb0c2-807e-4f7d-a28b-14ba6f9cb9b4"),
                    Title =  "The Matrix",
                    Genre = "Sci-Fi",
                    ReleaseDate = new DateOnly(1999, 03, 31),
                    Director =  "The Wachowskis",
                    Duration = 136,
                    Description = "A computer hacker learns the shocking truth about the reality he lives in and joins a rebellion.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/files/Matrix.mpw.102176_bb2f6cc5-4a16-4512-881b-f855ead3c8ec_480x.progressive.jpg?v=1708703624"
                },
                new Movie
                {
                   Id = Guid.Parse("75fb6394-ab90-4b78-9802-7ff3c9afdbc0"),
                   Title =  "Schindler's List",
                   Genre = "Drama",
                   ReleaseDate = new DateOnly(1993, 01, 15),
                   Director =  "Steven Spielberg",
                   Duration = 195,
                   Description = "A businessman saves the lives of hundreds of Jews during the Holocaust by employing them in his factories.",
                   ImageUrl = "https://www.movieposters.com/cdn/shop/products/9a1f9ea4a27071481cc1263e3ea11f7b_7bdb2deb-dd50-41b5-beab-8fc1cb3c895d_480x.progressive.jpg?v=1573651233"
                },
                new Movie
                {
                    Id = Guid.Parse("8c5904a9-bfab-4b0f-b12b-b5fc795e6231"),
                    Title =  "Forrest Gump",
                    Genre = "Drama",
                    ReleaseDate = new DateOnly(1994, 07, 06),
                    Director =  "Robert Zemeckis",
                    Duration = 142,
                    Description = "The story of Forrest Gump, a man with a low IQ, whose kind heart shapes the lives of those around him.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/products/forrest-gump---24x36_480x.progressive.jpg?v=1645558337"
                },
                new Movie
                {
                    Id = Guid.Parse("f1342f7d-ff72-4bfb-8a36-8368dec7b088"),
                    Title =  "The Shawshank Redemption",
                    Genre = "Drama",
                    ReleaseDate = new DateOnly(1994, 09, 23),
                    Director =  "Frank Darabont",
                    Duration = 142,
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of decency.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/files/shawshank_eb84716b-efa9-44dc-a19d-c17924a3f7df_480x.progressive.jpg?v=1709821984"
                },
                new Movie
                {
                    Id = Guid.Parse("c994999b-02dd-46c2-abc4-00c4787e629f"),
                    Title =  "Avatar",
                    Genre = "Sci-Fi",
                    ReleaseDate = new DateOnly(2009, 12, 18),
                    Director =  "James Cameron",
                    Duration = 162,
                    Description = "A paraplegic Marine dispatched to the moon Pandora becomes torn between following orders and protecting his home.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/files/avatar.adv.24x36_480x.progressive.jpg?v=1707410703"
                },
                new Movie
                {
                    Id = Guid.Parse("4b760743-8d49-48d5-bca6-15f5236e3f7b"),
                    Title =  "Gladiator",
                    Genre = "Action",
                    ReleaseDate = new DateOnly(2000, 05, 05),
                    Director =  "Ridley Scott",
                    Duration = 155,
                    Description = "A betrayed Roman general seeks revenge against the corrupt emperor who murdered his family and sent him into slavery.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/files/Gladiator.mpw.102813_480x.progressive.jpg?v=1707500493"
                },
                new Movie
                {
                    Id = Guid.Parse("9912f515-b2aa-4d19-9d2f-c2c94cb1212e"),
                    Title =  "The Avengers",
                    Genre = "Action",
                    ReleaseDate = new DateOnly(2012, 05, 04),
                    Director =  "Joss Whedon",
                    Duration = 143,
                    Description = "Earth's mightiest heroes must come together to stop a mischievous Loki and his alien army.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/files/avengers.24x36_480x.progressive.jpg?v=1707410714"
                },
                new Movie
                {
                   Id = Guid.Parse("e0d85412-0717-4648-a972-f393a6aafaa8"),
                   Title =  "The Lion King",
                   Genre = "Animation",
                   ReleaseDate = new DateOnly(1994, 06, 15),
                   Director =  "Roger Allers, Rob Minkoff",
                   Duration = 88,
                   Description = "A lion prince flees his kingdom after the death of his father, only to learn the true meaning of responsibility and bravery.",
                   ImageUrl = "https://www.movieposters.com/cdn/shop/files/the-lion-king_273b54a5_480x.progressive.jpg?v=1725905168"
                },
                new Movie
                {
                    Id = Guid.Parse("bec8f441-5b73-4f11-87b8-a47fbc1d140f"),
                    Title =  "Jurassic Park",
                    Genre = "Adventure",
                    ReleaseDate = new DateOnly(1993, 06, 11),
                    Director =  "Steven Spielberg",
                    Duration = 127,
                    Description = "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/files/jurassicpark.mpw_480x.progressive.jpg?v=1713805481"
                },
                new Movie
                {
                   Id = Guid.Parse("3fcdb107-dc27-45a0-8514-e2b40714100e"),
                   Title =  "The Silence of the Lambs",
                   Genre = "Thriller",
                   ReleaseDate = new DateOnly(1991, 02, 14),
                   Director =  "Jonathan Demme",
                   Duration = 118,
                   Description = "A young FBI trainee seeks the help of an imprisoned cannibalistic serial killer to catch another serial killer.",
                   ImageUrl = "https://www.movieposters.com/cdn/shop/files/silencelambs.C.17449.mpw_480x.progressive.jpg?v=1727097024"
                },
                new Movie
                {
                     Id = Guid.Parse("7dd82b97-1eb2-4c37-9c3d-e26dd84878a0"),
                     Title =  "The Green Mile",
                     Genre = "Drama",
                     ReleaseDate = new DateOnly(1999,12,10),
                     Director =  "Frank Darabont",
                     Duration = 189,
                     Description = "The lives of guards on Death Row are affected by one of their charges, a black man accused of child murder and rape, yet who has a mysterious gift.",
                     ImageUrl = "https://www.movieposters.com/cdn/shop/products/033152cb8ba4518411a359686f4a194e_e51d49fa-d8b2-4aaf-82dd-9779f297352c_480x.progressive.jpg?v=1573585373"
                },
                new Movie
                {
                    Id = Guid.Parse("25163666-81d7-4829-9931-b6bd44eb2b23"),
                    Title =  "Fight Club",
                    Genre = "Drama",
                    ReleaseDate = new DateOnly(1999,10,15),
                    Director =  "David Fincher",
                    Duration = 139,
                    Description = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much more.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/files/FightClub.mpw.125100_480x.progressive.jpg?v=1707497058"
                },
                new Movie
                {
                    Id = Guid.Parse("b0c21023-aa37-49cb-ad91-3ba005d8550d"),
                    Title =  "Django Unchained",
                    Genre = "Western",
                    ReleaseDate = new DateOnly(2012,12,25),
                    Director =  "Quentin Tarantino",
                    Duration = 165,
                    Description = "With the help of a German bounty hunter, a freed slave sets out to rescue his wife from a brutal Mississippi plantation owner.",
                    ImageUrl = "https://www.movieposters.com/cdn/shop/products/ff35c38cb67f47a5f4cbec6c92a5d5a8_acb37f4c-8110-4bc9-b597-01e75e565a60_480x.progressive.jpg?v=1573587558"
                },
            };

            return movies;
        }
    }
}