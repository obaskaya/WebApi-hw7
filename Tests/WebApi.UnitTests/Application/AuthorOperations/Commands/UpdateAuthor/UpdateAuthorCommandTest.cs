using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.BookOperations.Commands.CreateCommand;
using WebApi.Application.BookOperations.Commands.UpdateCommand;
using WebApi.DBOperations;
using WebApi.Entitites;
using WebApi.UnitTests.TestSetup;
using WebApi.UnitTests.TestsSetup;
using static WebApi.Application.BookOperations.Commands.CreateCommand.CreateBookCommand;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.UpdateAuthor
{
	public class UpdateAuthorCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;


		public UpdateAuthorCommandTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;

		}

		//this is a  test
		// This will give error because faker will provide us 20 books [InlineData(20)]
		[Theory]
		[InlineData(500)]
		public void WhenAuthorIsNull_InvalidOperationException_ShouldBeReturn(int authorId)
		{
			// setting bookId 
			UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
			command.AuthorId = authorId;

			//act & assert (çalıştırma)
			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Author couldn't found");
		}
		[Fact]
		public void WhenAuthorNameExist_InvalidOperationException_ShouldBeReturn()
		{
			var author = new Author() { Name = "Johnson", BirthDay = "20.03.1900" };
			_context.Authors.Add(author);
			_context.SaveChanges();

			UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
			command.AuthorId = author.Id;
			command.Model =	new UpdateAuthorModel() { Name = author.Name };

			//act & assert (çalıştırma)
			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("There is a same Author name exists in database");
		}
	}
}
