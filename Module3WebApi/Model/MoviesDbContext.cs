using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Module3WebApi.Model
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 1, FullName = "Aragorn II", Alias = "Elessar", Gender = "Male", Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ-nmKWSWArrznZJ6k4_fxgROIXe-PJzM5ftA&usqp=CAU" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 2, FullName = "Gimli", Alias = "Lockbearer", Gender = "Male", Picture = "https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/de/de43f55bd8eae369bbfe24e828a76295e9445126_full.jpg" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 3, FullName = "Bilbo Baggins", Gender = "Male", Picture = "https://steamuserimages-a.akamaihd.net/ugc/795385183690202105/14AD7025C102913BB7E86371F8678B915F057B16/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 4, FullName = "Harry Potter", Alias = "The boy who lived", Gender = "Male", Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkJe2TpGHZYj-yLDZw-rstQfMA61hs6OEutw&usqp=CAU" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 5, FullName = "Hermione Granger", Gender = "Female", Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSrFSwIAz5GfZVSgi2Z_2r3oVfCkM_PYp1bTg&usqp=CAU" });

            modelBuilder.Entity<Franchise>().HasData(new Franchise() { Id = 1, Name = "The Lord of the Rings", Description = "The Lord of the Rings is a series of three epic fantasy adventure films directed by Peter Jackson, based on the novel written by J. R. R. Tolkien." });
            modelBuilder.Entity<Franchise>().HasData(new Franchise() { Id = 2, Name = "Harry Potter", Description = "Harry Potter is a film series based on the eponymous novels by J. K. Rowling." });

            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 1,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Genre = "Epic, Fantasy, Adventure",
                ReleaseYear = 2001,
                Director = "Peter Jackson",
                FranchiseId = 1,
                Trailer = "https://www.youtube.com/watch?v=V75dMMIW2B4&ab_channel=Movieclips",
                Picture = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Lord_of_the_Rings_The_Fellowship_of_the_Ring_%282001%29.jpg",
            });
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 2,
                Title = "Harry Potter and the Chamber of Secrets",
                Genre = "Fantasy, Adventure",
                ReleaseYear = 2002,
                Director = "Chris Columbus",
                FranchiseId = 2,
                Trailer = "https://www.youtube.com/watch?v=jBltxS8HfQ4&ab_channel=KinoCheckInternational",
                Picture = "https://static.wikia.nocookie.net/harrypotter/images/c/c5/Harry_Potter_and_the_Chamber_of_Secrets_UK_Poster.jpg/revision/latest?cb=20150209181936",
            });
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 3,
                Title = "The Hobbit",
                Genre = "Fantasy, Adventure",
                ReleaseYear = 2012,
                Director = "Peter Jackson",
                FranchiseId = 1,
                Trailer = "https://www.youtube.com/watch?v=JTSoD4BBCJc&t=18s&ab_channel=MovieclipsComingSoon",
                Picture = "https://www.discshop.fi/img/front_large/125948/the_hobbit_an_unexpected_journey_blu_ray.jpg",
            });
            modelBuilder.Entity<Movie>()
                .HasMany(c => c.Characters)
                .WithMany(m => m.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MoviesCharacters",
                    r => r.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    je =>
                    {
                        je.HasKey("MovieId", "CharacterId");
                        je.HasData(
                            new { MovieId = 1, CharacterId = 1 },
                            new { MovieId = 1, CharacterId = 2 },
                            new { MovieId = 2, CharacterId = 4 },
                            new { MovieId = 2, CharacterId = 5 },
                            new { MovieId = 3, CharacterId = 3 }
                        );
                    });
            modelBuilder.Entity<Movie>()
               .HasOne(f => f.Franchise)
               .WithMany(m => m.Movies)
               .HasForeignKey(f => f.FranchiseId);
        }
    }
}

