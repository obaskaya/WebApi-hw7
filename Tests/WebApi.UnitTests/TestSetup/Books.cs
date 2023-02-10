using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entitites;

namespace WebApi.UnitTests.TestSetup
{
	public static class Books
	{
		public static void AddBooks(this BookStoreDbContext context)
		{
		context.Books.AddRange(
			new Faker<Book>()
				.RuleFor(c => c.Title, f => f.Lorem.Letter(4))
				.RuleFor(c => c.GenreId, f => f.Random.Number(1, 3))
				.RuleFor(c => c.PageCount, f => f.Random.Number(50, 600))
				.RuleFor(c => c.PublishDate, f => f.Date.Past())
				.RuleFor(c => c.AuthorId, f => f.Random.Number(2, 4))
				.Generate(20)
			);
		}

	}
}
