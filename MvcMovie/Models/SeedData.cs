using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "Back from the Brink",
                    ReleaseDate = DateTime.Parse("2023-05-09"),
                    Genre = "Fantasy, Historical, Costume, Romance",
                    Rating = "TV-14",
                    Price = 8.00M
                },
                new Movie
                {
                    Title = "My Love from the Star",
                    ReleaseDate = DateTime.Parse("2013-12-18"),
                    Genre = "Romantic Comedy",
                    Rating = "TV-14",
                    Price = 10.00M
                },
                new Movie
                {
                    Title = "Where Love Lives",
                    ReleaseDate = DateTime.Parse("2025-12-28"),
                    Genre = "Comedy, Drama",
                    Rating = "TV-PG",
                    Price = 20.00M
                }
            );
            context.SaveChanges();
        }
    }
}
