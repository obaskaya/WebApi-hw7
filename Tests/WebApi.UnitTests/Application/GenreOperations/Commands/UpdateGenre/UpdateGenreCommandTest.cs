using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DBOperations;
using WebApi.Entitites;
using WebApi.UnitTests.TestSetup;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
	public class UpdateGenreCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;


		public UpdateGenreCommandTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;

		}

		//this is a  test
		// This will give error because faker will provide us 20 books [InlineData(20)]
		[Theory]
		[InlineData(500)]
		public void WhenGenreIsNull_InvalidOperationException_ShouldBeReturn(int genreId)
		{
			// setting bookId 
			UpdateGenreCommand command = new UpdateGenreCommand(_context);
			command.GenreId = genreId;

			//act & assert (çalıştırma)
			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book type couldn't found");
		}
		[Fact]
		public void WhenGenreNameExist_InvalidOperationException_ShouldBeReturn()
		{
			var genre = new Genre() { Name = "Documentary" };
			_context.Genres.Add(genre);
			_context.SaveChanges();

			UpdateGenreCommand command = new UpdateGenreCommand(_context);
			command.GenreId = genre.Id;
			command.Model = new UpdateGenreModel() { Name = genre.Name };

			//act & assert (çalıştırma)
			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("There is a same book type name exists in database");
		}
	}
}
