using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
	public static void Initialize(IServiceProvider serviceProvider)
	{
		using (var context = new RazorPagesMovieContext(
			serviceProvider.GetRequiredService<
				DbContextOptions<RazorPagesMovieContext>>()))
		{
			if (context == null || context.Movie == null)
			{
				throw new ArgumentNullException("Null RazorPagesMovieContext");
			}

			// Look for any movies.
			if (context.Movie.Any())
			{
				return;   // DB has been seeded
			}

			context.Movie.AddRange(
				new Movie
				{
					Title = "L123123",
					ReleaseDate = DateTime.Parse("1969-4-20"),
					Genre = "Romantic Comedy",
					Price = 7.99M,
					Rating = "F"
				},

				new Movie
				{
					Title = "Ghostbusters :)))) ",
					ReleaseDate = DateTime.Parse("1934-11-12"),
					Genre = "Comedy",
					Price = 8.99M,
                    Rating = "L"
                },

				new Movie
				{
					Title = "Ghostbusters 2",
					ReleaseDate = DateTime.Parse("1986-2-23"),
					Genre = "Comedy",
					Price = 9.99M,
					Rating = "L"
				},

				new Movie
				{
					Title = "Rio Bravo",
					ReleaseDate = DateTime.Parse("1959-4-15"),
					Genre = "Western",
					Price = 3.99M,
					Rating = "L"
				}
			);
			context.SaveChanges();
		}
	}
}
