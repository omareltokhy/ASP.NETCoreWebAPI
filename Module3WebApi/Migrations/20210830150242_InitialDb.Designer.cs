﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Module3WebApi.Model;

namespace Module3WebApi.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    [Migration("20210830150242_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Module3WebApi.Model.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Elessar",
                            FullName = "Aragorn II",
                            Gender = "Male",
                            Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ-nmKWSWArrznZJ6k4_fxgROIXe-PJzM5ftA&usqp=CAU"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Lockbearer",
                            FullName = "Gimli",
                            Gender = "Male",
                            Picture = "https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/de/de43f55bd8eae369bbfe24e828a76295e9445126_full.jpg"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Bilbo Baggins",
                            Gender = "Male",
                            Picture = "https://steamuserimages-a.akamaihd.net/ugc/795385183690202105/14AD7025C102913BB7E86371F8678B915F057B16/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "The boy who lived",
                            FullName = "Harry Potter",
                            Gender = "Male",
                            Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkJe2TpGHZYj-yLDZw-rstQfMA61hs6OEutw&usqp=CAU"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Hermione Granger",
                            Gender = "Female",
                            Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSrFSwIAz5GfZVSgi2Z_2r3oVfCkM_PYp1bTg&usqp=CAU"
                        });
                });

            modelBuilder.Entity("Module3WebApi.Model.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Franchises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The Lord of the Rings is a series of three epic fantasy adventure films directed by Peter Jackson, based on the novel written by J. R. R. Tolkien.",
                            Name = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Harry Potter is a film series based on the eponymous novels by J. K. Rowling.",
                            Name = "Harry Potter"
                        });
                });

            modelBuilder.Entity("Module3WebApi.Model.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Director")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trailer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Peter Jackson",
                            FranchiseId = 1,
                            Genre = "Epic, Fantasy, Adventure",
                            Picture = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Lord_of_the_Rings_The_Fellowship_of_the_Ring_%282001%29.jpg",
                            ReleaseYear = 2001,
                            Title = "The Lord of the Rings: The Fellowship of the Ring",
                            Trailer = "https://www.youtube.com/watch?v=V75dMMIW2B4&ab_channel=Movieclips"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Chris Columbus",
                            FranchiseId = 2,
                            Genre = "Fantasy, Adventure",
                            Picture = "https://static.wikia.nocookie.net/harrypotter/images/c/c5/Harry_Potter_and_the_Chamber_of_Secrets_UK_Poster.jpg/revision/latest?cb=20150209181936",
                            ReleaseYear = 2002,
                            Title = "Harry Potter and the Chamber of Secrets",
                            Trailer = "https://www.youtube.com/watch?v=jBltxS8HfQ4&ab_channel=KinoCheckInternational"
                        },
                        new
                        {
                            Id = 3,
                            Director = "Peter Jackson",
                            FranchiseId = 1,
                            Genre = "Fantasy, Adventure",
                            Picture = "https://www.discshop.fi/img/front_large/125948/the_hobbit_an_unexpected_journey_blu_ray.jpg",
                            ReleaseYear = 2012,
                            Title = "The Hobbit",
                            Trailer = "https://www.youtube.com/watch?v=JTSoD4BBCJc&t=18s&ab_channel=MovieclipsComingSoon"
                        });
                });

            modelBuilder.Entity("MoviesCharacters", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("MoviesCharacters");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CharacterId = 1
                        },
                        new
                        {
                            MovieId = 1,
                            CharacterId = 2
                        },
                        new
                        {
                            MovieId = 2,
                            CharacterId = 4
                        },
                        new
                        {
                            MovieId = 2,
                            CharacterId = 5
                        },
                        new
                        {
                            MovieId = 3,
                            CharacterId = 3
                        });
                });

            modelBuilder.Entity("Module3WebApi.Model.Movie", b =>
                {
                    b.HasOne("Module3WebApi.Model.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("MoviesCharacters", b =>
                {
                    b.HasOne("Module3WebApi.Model.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Module3WebApi.Model.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Module3WebApi.Model.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
