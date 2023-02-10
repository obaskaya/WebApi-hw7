using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.Commands.CreateCommand;
using WebApi.Application.BookOperations.Commands.UpdateCommand;
using WebApi.UnitTests.TestsSetup;
using static WebApi.Application.BookOperations.Commands.CreateCommand.CreateBookCommand;
using static WebApi.Application.BookOperations.Commands.UpdateCommand.UpdateBookCommand;

namespace WebApi.UnitTests.Application.BookOperations.Commands.UpdateBookCommands
{
	public class UpdateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
	{
		[Theory]
		[InlineData("Game of Thrones", 1, 1, -10)]
		[InlineData("Game of Thrones", 0, 1, 0)]
		[InlineData("Game", 1, 0, 1)]
		[InlineData("Gam", 1, 1, 1)]
		[InlineData("Gam", 0, 0, 0)]
		[InlineData(" ", 1, 1, 1)]
		public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int genreId, int authorId, int bookId)
		{
			UpdateBookCommand command = new UpdateBookCommand(null);
			command.BookId = bookId;
			command.Model = new UpdateBookModel()
			{
				AuthorId = authorId,
				GenreId = genreId,
				Title = title,
			};
			var validator = new UpdateBookCommandValidator();
			var result = validator.Validate(command);
			//assert
			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
