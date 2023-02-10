using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.BookOperations.Commands.CreateCommand;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using static WebApi.Application.BookOperations.Commands.CreateCommand.CreateBookCommand;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.CreateAuthor
{
	public class CreateAuthorCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;
		public CreateAuthorCommandTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
		}
		//this is a test

		[Fact]
		public void WhenValidInputsAreGiven_ShouldBeCreated()
		{
			//arrange(Hazırlık)
			CreateAuthorCommand command = new CreateAuthorCommand(_context);

			CreateAuthorModel model = new CreateAuthorModel() { Name = "Johnson", BirthDay = "20.03.1900" };
			command.Model = model;


			//act 
			FluentActions.Invoking(() => command.Handle()).Invoke();

			//assert
			var author = _context.Authors.FirstOrDefault(author => author.Name == model.Name);
			author.Name.Should().Be(model.Name);
			author.BirthDay.Should().Be(model.BirthDay);
		}

	}
}
