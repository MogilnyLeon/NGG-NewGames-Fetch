using Microsoft.EntityFrameworkCore;

namespace NGG.NewGames.Api.DataAccess
{
    public class NGG_NewGamesDbContext(DbContextOptions<NGG_NewGamesDbContext> options): DbContext(options)
    {
        public DbSet<NewGame> NewGames { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                [
                    new Genre{Id = 1,  Name = "First-Person Shooter" },
                    new Genre{ Id = 2, Name = "Third-Person Shooter" },
                    new Genre{ Id = 3, Name = "Metroidvania" },
                    new Genre{ Id = 4, Name = "4X Strategy" },
                    new Genre{ Id = 5, Name = "Role-Playing Game" },
                    new Genre{ Id = 6, Name = "Action-Adventure" },
                    new Genre{ Id = 7, Name = "Survival" },
                    new Genre{ Id = 8, Name = "Horror" },
                    new Genre{ Id = 9, Name = "Real-Time Strategy" },
                    new Genre{ Id = 10, Name = "Turn-Based Strategy" },
                    new Genre{ Id = 11, Name = "MOBA" },
                    new Genre{ Id = 12, Name = "Fighting" },
                    new Genre{ Id = 13, Name = "Simulation" },
                    new Genre{ Id = 14, Name = "Racing" },
                    new Genre{ Id = 15, Name = "Sports" },
                    new Genre{ Id = 16, Name = "Puzzle" },
                    new Genre{ Id = 17, Name = "Platformer" },
                    new Genre{ Id = 18, Name = "Roguelike / Roguelite" },
                    new Genre{ Id = 19, Name = "MMORPG" },
                    new Genre{ Id = 20, Name = "Card / Deckbuilder" }
                ]
            );

            modelBuilder.Entity<NewGame>().HasData(
                [
                    new NewGame {
                        Id = 1,
                        Name = "Baldur's Gate 3",
                        Description = "Baldur’s Gate 3 is a story-rich, party-based RPG set in the universe of Dungeons & Dragons, where your choices shape a tale of fellowship and betrayal, survival and sacrifice, and the lure of absolute power.",
                        ReleaseDate = new DateTime(2023, 8, 3),
                        GenreId = 5
                    },
                    new NewGame {
                        Id = 2,
                        Name = "Hollow Knight: Silksong",
                        Description = "Discover a vast, haunted kingdom in Hollow Knight: Silksong! Explore, fight and survive as you ascend to the peak of a land ruled by silk and song.",
                        ReleaseDate = new DateTime(2025, 9, 4),
                        GenreId = 3
                    },
                    new NewGame {
                        Id = 3,
                        Name = "HELLDIVERS 2",
                        Description = "The Galaxy’s Last Line of Offence. Enlist in the Helldivers and join the fight for freedom across a hostile galaxy in a fast, frantic, and ferocious third-person shooter.",
                        ReleaseDate = new DateTime(2024, 2, 8),
                        GenreId = 2
                    },
                    new NewGame {
                        Id = 4,
                        Name = "Hades II",
                        Description = "Battle beyond the Underworld using dark sorcery to take on the Titan of Time in this bewitching sequel to the award-winning rogue-like dungeon crawler.",
                        ReleaseDate = new DateTime(2025, 9, 25),
                        GenreId = 18
                    },
                    new NewGame {
                        Id = 5,
                        Name = "Stellaris",
                        Description = "Explore a galaxy full of wonders in this sci-fi grand strategy game from Paradox Development Studios. Interact with diverse alien races, discover strange new worlds with unexpected events and expand the reach of your empire. Each new adventure holds almost limitless possibilities.",
                        ReleaseDate = new DateTime(2016, 5, 9),
                        GenreId = 4
                    },
                    new NewGame {
                        Id = 6,
                        Name = "Ori and the Will of the Wisps",
                        Description = "Play the critically acclaimed masterpiece. Embark on a new journey in a vast, exotic world where you’ll encounter towering enemies and challenging puzzles on your quest to unravel Ori’s destiny.",
                        ReleaseDate = new DateTime(2020, 3, 11),
                        GenreId = 17
                    }
                ]
            );
        }
    }

    public static class NGG_NewGameDbContextExtensions
    {
        public static void EnsureDbIsCreated (this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<NGG_NewGamesDbContext>();
            context!.Database.EnsureCreated();
        }
    }

    public class NewGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
