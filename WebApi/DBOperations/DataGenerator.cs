using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using WebApi.Entitites;
using static AutoMapper.Internal.ExpressionFactory;


namespace WebApi.DBOperations
{
	public class DataGenerator
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new BookStoreDbContext(
			serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))

			{

				// Look for any book.
				if (context.Books.Any())
				{
					return;   // Data was already seeded
				}

				//Authors
				context.Authors.AddRange(
				new Author
				{
					Name = "Tolstoy",
					BirthDay = "20.11.1910"
				},
				new Author
				{
					Name = "Orhan Pamuk",
					BirthDay = "07.06.1952"
				},
				new Author
				{
					Name = "Yaşar Kemal",
					BirthDay = "28.02.1923"
				},
				new Author
				{
					Name = "Sabahattin Ali",
					BirthDay = "25.02.1907"
				}
				);

				//Genres
				context.Genres.AddRange(
				new Genre
				{
					Name = "Personal Growth"

				},
				new Genre
				{
					Name = " Science Fiction"

				},
				new Genre
				{
					Name = "Romance"

				});

				//Books
				context.Books.AddRange(
				new Faker<Book>()

					.RuleFor(c => c.Title, f => f.Lorem.Letter(4))
					.RuleFor(c => c.GenreId, f => f.Random.Number(1, 3))
					.RuleFor(c => c.PageCount, f => f.Random.Number(50, 600))
					.RuleFor(c => c.PublishDate, f => f.Date.Past())
					.RuleFor(c => c.AuthorId, f => f.Random.Number(2, 4))
					.Generate(20)

				);
				context.SaveChanges();
			}

		}
	}
}
