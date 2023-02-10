using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.BookOperations.Commands.DeleteComand;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.DeleteAuthor
{
	public class DeleteAuthorCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;


		public DeleteAuthorCommandTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
		}
		[Theory]

		[InlineData(200)]
		public void WhenAuthorIsNull_InvalidOperationException_ShouldBeReturn(int authorId)
		{
			// setting bookId 
			DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
			command.AuthorId = authorId;

			//act & assert (çalıştırma)
			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author Couldn't Found");
		}
	}
}
