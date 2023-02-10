using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.DeleteGenre
{
	public class DeleteGenreCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;


		public DeleteGenreCommandTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
		}
		[Theory]

		[InlineData(200)]
		public void WhenAuthorIsNull_InvalidOperationException_ShouldBeReturn(int genreId)
		{
			// setting bookId 
			DeleteGenreCommand command = new DeleteGenreCommand(_context);
			command.GenreId = genreId;

			//act & assert (çalıştırma)
			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book Type Couldn't Found");
		}
	}
}
